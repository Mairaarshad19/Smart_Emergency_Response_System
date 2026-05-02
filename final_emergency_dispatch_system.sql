-- Create database and user
CREATE DATABASE final_emergency_dispatch_system;
USE final_emergency_dispatch_system;


-- =========================
-- Users table
-- =========================
CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    role ENUM('Admin','Operator') NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- =========================
-- Intersections table
-- =========================
CREATE TABLE intersections (
    intersection_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    latitude DECIMAL(9,6),
    longitude DECIMAL(9,6)
);
SELECT* FROM intersections;

-- =========================
-- Stations table
-- =========================
CREATE TABLE stations (
    station_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    latitude DECIMAL(9,6) NOT NULL,
    longitude DECIMAL(9,6) NOT NULL,
    intersection_id INT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (intersection_id) REFERENCES intersections(intersection_id)
);

-- =========================
-- Ambulances table
-- =========================
CREATE TABLE ambulances (
    ambulance_id INT AUTO_INCREMENT PRIMARY KEY,
    station_id INT NOT NULL,
    plate_number VARCHAR(50) UNIQUE NOT NULL,
    equipment TEXT,
    status ENUM('Available','Dispatched','OnTheWay','Busy') DEFAULT 'Available',
    current_latitude DOUBLE,
    current_longitude DOUBLE,
    FOREIGN KEY (station_id) REFERENCES stations(station_id),
    is_active TINYINT(1) DEFAULT 1
);



ALTER TABLE dispatches
ADD CONSTRAINT dispatches_ibfk_2
FOREIGN KEY (ambulance_id) REFERENCES ambulances(ambulance_id)
ON DELETE CASCADE;


-- =========================
-- Emergencies table
-- =========================
CREATE TABLE emergencies (
    emergency_id INT AUTO_INCREMENT PRIMARY KEY,
    caller_name VARCHAR(100),
    caller_phone VARCHAR(20),
    latitude DECIMAL(9,6) NOT NULL,
    longitude DECIMAL(9,6) NOT NULL,
    severity ENUM('Critical','High','Medium','Low') NOT NULL,
    description TEXT,
    status ENUM('Waiting','Assigned','Resolved') DEFAULT 'Waiting',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    intersection_id INT,
    priority INT NOT NULL DEFAULT 0,
    enqueued_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    assigned_at TIMESTAMP NULL,
    FOREIGN KEY (intersection_id) REFERENCES intersections(intersection_id)
);

-- ========================
CREATE TABLE dispatches (
    dispatch_id INT AUTO_INCREMENT PRIMARY KEY,
    emergency_id INT NOT NULL,
    ambulance_id INT NOT NULL,
    assigned_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    eta_minutes INT,
    arrival_time TIMESTAMP,
    status ENUM('Assigned','OnTheWay','Arrived','Cancelled') DEFAULT 'Assigned',
    reassigned_from_dispatch_id INT NULL,
    FOREIGN KEY (emergency_id) REFERENCES emergencies(emergency_id),
    FOREIGN KEY (ambulance_id) REFERENCES ambulances(ambulance_id) ON DELETE CASCADE
);

-- =========================
-- Routes table
-- =========================
CREATE TABLE routes (
    route_id INT AUTO_INCREMENT PRIMARY KEY,
    dispatch_id INT NOT NULL,
    path TEXT, -- JSON or text list of intersections
    total_distance DECIMAL(10,2),
    total_time INT,
    FOREIGN KEY (dispatch_id) REFERENCES dispatches(dispatch_id)
);

-- =========================
-- Roads table
-- =========================
CREATE TABLE roads (
    road_id INT AUTO_INCREMENT PRIMARY KEY,
    from_intersection_id INT NOT NULL,
    to_intersection_id INT NOT NULL,
    travel_time_minutes DECIMAL(5,2) NOT NULL,
    status ENUM('Open','Closed') DEFAULT 'Open',
    traffic_factor DECIMAL(3,2) DEFAULT 1.00,
    name VARCHAR(100) NULL,
    distance_km DECIMAL(6,3) NULL,
    FOREIGN KEY (from_intersection_id) REFERENCES intersections(intersection_id),
    FOREIGN KEY (to_intersection_id) REFERENCES intersections(intersection_id)
);

-- =========================
-- Audit logs table
-- =========================
CREATE TABLE audit_logs (
    log_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    action VARCHAR(255),
    details TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE ambulance_locations (
    ambulance_id INT PRIMARY KEY,
    latitude DECIMAL(9,6),
    longitude DECIMAL(9,6),
    last_updated TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- =========================
-- Indexes
-- =========================
CREATE INDEX idx_emergencies_queue ON emergencies (status, severity, priority, enqueued_at);
CREATE INDEX idx_ambulances_station_status ON ambulances (station_id, status);
CREATE INDEX idx_dispatches_status ON dispatches (status);
CREATE INDEX idx_stations_name ON stations (name);
