-- Create database
CREATE DATABASE smart_emergency_dispatch_system;
USE smart_emergency_dispatch_system;

CREATE USER 'dispatch_user'@'%' IDENTIFIED BY 'TE891DUZ';
GRANT ALL PRIVILEGES ON smart_emergency_dispatch_system.* TO 'dispatch_user'@'%';
FLUSH PRIVILEGES;




-- =========================
-- Users table
-- =========================
CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    role ENUM('Admin','Operator','StationManager') NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO users (username, password_hash, role) VALUES
('admin1', 'hashedpassword123', 'Admin'),
('operator1', 'hashedpassword456', 'Operator'),
('manager1', 'hashedpassword789', 'StationManager');

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

INSERT INTO intersections (name, latitude, longitude) VALUES
('Liberty Chowk', 31.5204, 74.3587),
('MM Alam Road', 31.5145, 74.3560),
('Gulberg Main', 31.5150, 74.3500),
('Services Hospital', 31.5165, 74.3400),
('Mall Road', 31.5490, 74.3430),
('Anarkali Bazaar', 31.5530, 74.3150),
('Shadman Chowk', 31.5330, 74.3400),
('Ferozepur Road', 31.5080, 74.3300),
('Canal Bank', 31.5200, 74.3700),
('Model Town Link Road', 31.4800, 74.3300);

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

INSERT INTO stations (name, latitude, longitude, intersection_id) VALUES
('Central Station', 31.5200, 74.3500, 1),  -- Liberty Chowk
('North Station', 31.5300, 74.3500, 2),    -- MM Alam Road
('East Station', 31.5200, 74.3600, 3),     -- Gulberg Main
('West Station', 31.5200, 74.3400, 4),     -- Services Hospital
('South Station', 31.5100, 74.3500, 5);    -- Mall Road  
select* from stations;
INSERT INTO stations (station_id, name, latitude, longitude, intersection_id)
VALUES
(11, 'Station 1 - Anarkali', 31.5204, 74.3587, 1),
(12, 'Station 2 - Mall Road', 31.5497, 74.3436, 2),
(13, 'Station 3 - Gulberg', 31.5650, 74.3500, 3),
(14, 'Station 4 - Shadman', 31.5800, 74.3700, 4),
(15, 'Station 5 - Cantt', 31.6000, 74.3800, 5),
(6, 'Station 6 - Model Town', 31.6100, 74.4000, 6),
(7, 'Station 7 - Johar Town', 31.6200, 74.4100, 7),
(8, 'Station 8 - Faisal Town', 31.6300, 74.4200, 8),
(9, 'Station 9 - DHA', 31.6400, 74.4300, 9),
(10, 'Station 10 - Wapda Town', 31.6500, 74.4400, 10);



-- =========================
-- Ambulances table
-- =========================
CREATE TABLE ambulances (
    ambulance_id INT AUTO_INCREMENT PRIMARY KEY,
    station_id INT NOT NULL,
    plate_number VARCHAR(50) UNIQUE NOT NULL,
    equipment TEXT,
    status ENUM('Available','Dispatched','OnTheWay','Busy') DEFAULT 'Available',
    latitude DECIMAL(9,6),
    longitude DECIMAL(9,6),
    FOREIGN KEY (station_id) REFERENCES stations(station_id)
);
ALTER TABLE ambulances 
ADD COLUMN current_latitude DOUBLE,
ADD COLUMN current_longitude DOUBLE;
ALTER TABLE ambulances
DROP COLUMN latitude,
DROP COLUMN longitude;
INSERT INTO ambulances (station_id, plate_number, equipment, status, current_latitude, current_longitude)
VALUES
-- Station 1 ambulances
(1, 'LHR-001', 'Basic Kit', 'Available', 31.5204, 74.3587),
(1, 'LHR-002', 'Advanced Kit', 'Available', 31.5220, 74.3600),
(1, 'LHR-003', 'Cardiac Unit', 'Busy', 31.5235, 74.3550),

-- Station 2 ambulances
(2, 'LHR-601', 'Basic Kit', 'Available', 31.5497, 74.3436),
(2, 'LHR-602', 'Advanced Kit', 'Dispatched', 31.5470, 74.3400),
(2, 'LHR-603', 'Trauma Unit', 'Available', 31.5450, 74.3455),

-- Station 3 ambulances
(3, 'LHR-701', 'Basic Kit', 'Available', 31.5650, 74.3500),
(3, 'LHR-702', 'Advanced Kit', 'OnTheWay', 31.5675, 74.3520),
(3, 'LHR-703', 'Cardiac Unit', 'Available', 31.5620, 74.3480),

-- Station 4 ambulances
(4, 'LHR-801', 'Basic Kit', 'Available', 31.5800, 74.3700),
(4, 'LHR-802', 'Advanced Kit', 'Available', 31.5825, 74.3680),
(4, 'LHR-803', 'Trauma Unit', 'Busy', 31.5850, 74.3720),

-- Station 5 ambulances
(5, 'LHR-901', 'Basic Kit', 'Available', 31.6000, 74.3800),
(5, 'LHR-902', 'Advanced Kit', 'Available', 31.6025, 74.3820),
(5, 'LHR-903', 'Cardiac Unit', 'Dispatched', 31.6050, 74.3850);-- Station 1
INSERT INTO ambulances (station_id, plate_number, equipment, status, current_latitude, current_longitude)
VALUES
-- Station 6 ambulances
(6, 'LHR-1001', 'Basic Kit', 'Available', 31.6100, 74.4000),
(6, 'LHR-1002', 'Advanced Kit', 'Dispatched', 31.6125, 74.4020),

-- Station 7 ambulances
(7, 'LHR-1101', 'Trauma Unit', 'Available', 31.6200, 74.4100),
(7, 'LHR-1102', 'Cardiac Unit', 'Busy', 31.6225, 74.4120),

-- Station 8 ambulances
(8, 'LHR-1201', 'Basic Kit', 'Available', 31.6300, 74.4200),
(8, 'LHR-1202', 'Advanced Kit', 'Available', 31.6325, 74.4220),

-- Station 9 ambulances
(9, 'LHR-1301', 'Trauma Unit', 'OnTheWay', 31.6400, 74.4300),
(9, 'LHR-1302', 'Basic Kit', 'Available', 31.6425, 74.4320),

-- Station 10 ambulances
(10, 'LHR-1401', 'Cardiac Unit', 'Available', 31.6500, 74.4400);




INSERT INTO ambulances (station_id, plate_number, equipment, status, latitude, longitude) VALUES
(1, 'LHR-101', 'Basic Kit', 'Available', 31.5201, 74.3501),
(1, 'LHR-102', 'Advanced Kit', 'Busy', 31.5202, 74.3502),
(2, 'LHR-201', 'Basic Kit', 'Available', 31.5301, 74.3501),
(3, 'LHR-301', 'Advanced Kit', 'Dispatched', 31.5201, 74.3601),
(4, 'LHR-401', 'Basic Kit', 'OnTheWay', 31.5201, 74.3401),
(5, 'LHR-501', 'Advanced Kit', 'Available', 31.5101, 74.3501);


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
    FOREIGN KEY (intersection_id) REFERENCES intersections(intersection_id)
);
ALTER TABLE emergencies ADD COLUMN priority INT NOT NULL DEFAULT 0;
ALTER TABLE emergencies ADD COLUMN enqueued_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP;
ALTER TABLE emergencies ADD COLUMN assigned_at TIMESTAMP NULL;

INSERT INTO emergencies (caller_name, caller_phone, latitude, longitude, severity, description, status, intersection_id) VALUES
('Ali Khan', '03001234567', 31.5600, 74.3500, 'Critical', 'Heart attack at Liberty Market', 'Waiting', 1),
('Sara Ahmed', '03007654321', 31.5800, 74.3600, 'High', 'Car accident near Mall Road', 'Assigned', 5),
('Bilal Hussain', '03009876543', 31.5000, 74.3300, 'Medium', 'Minor fire in Gulberg', 'Resolved', 3),
('Ayesha Malik', '03001112233', 31.5400, 74.3700, 'Low', 'Small cut injury', 'Waiting', 9);
INSERT INTO emergencies (caller_name, caller_phone, latitude, longitude, severity, description,status, intersection_id)
VALUES ('Test Caller', '03001234567', 31.5200, 74.3500, 'Critical', 'Test emergency','null', 1);


-- =========================
-- Dispatches table
-- =========================
CREATE TABLE dispatches (
    dispatch_id INT AUTO_INCREMENT PRIMARY KEY,
    emergency_id INT NOT NULL,
    ambulance_id INT NOT NULL,
    assigned_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    eta_minutes INT,
    arrival_time TIMESTAMP,
    FOREIGN KEY (emergency_id) REFERENCES emergencies(emergency_id),
    FOREIGN KEY (ambulance_id) REFERENCES ambulances(ambulance_id)
);
ALTER TABLE dispatches ADD COLUMN status ENUM('Assigned','OnTheWay','Arrived','Cancelled') DEFAULT 'Assigned';

ALTER TABLE dispatches ADD COLUMN reassigned_from_dispatch_id INT NULL;
INSERT INTO dispatches (emergency_id, ambulance_id, eta_minutes, arrival_time) VALUES
(1, 1, 8, NULL),   -- Emergency 1 assigned to ambulance 1
(2, 3, 12, NULL),  -- Emergency 2 assigned to ambulance 3
(3, 4, 15, '2025-12-25 20:30:00'), -- Emergency 3 resolved
(4, 5, 10, NULL);  -- Emergency 4 assigned to ambulance 5

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
INSERT INTO routes (dispatch_id, path, total_distance, total_time) VALUES
(1, '["Liberty Chowk","MM Alam Road","Services Hospital"]', 5.2, 8),
(2, '["Mall Road","Anarkali Bazaar","Services Hospital"]', 7.5, 12),
(3, '["Gulberg Main","MM Alam Road","Fire Station"]', 8.0, 15),
(4, '["Canal Bank","Model Town Link Road","Central Station"]', 6.5, 10);

-- =========================
-- Roads table (ID-based)
-- =========================
CREATE TABLE roads (
    road_id INT AUTO_INCREMENT PRIMARY KEY,
    from_intersection_id INT NOT NULL,
    to_intersection_id INT NOT NULL,
    travel_time_minutes DECIMAL(5,2) NOT NULL,
    FOREIGN KEY (from_intersection_id) REFERENCES intersections(intersection_id),
    FOREIGN KEY (to_intersection_id) REFERENCES intersections(intersection_id)
);
ALTER TABLE roads ADD COLUMN status ENUM('Open','Closed') DEFAULT 'Open';

ALTER TABLE roads ADD COLUMN traffic_factor DECIMAL(3,2) DEFAULT 1.00;

ALTER TABLE roads ADD COLUMN name VARCHAR(100) NULL;

ALTER TABLE roads ADD COLUMN distance_km DECIMAL(6,3) NULL;
INSERT INTO roads (from_intersection_id, to_intersection_id, travel_time_minutes) VALUES
(1, 2, 4.5),  -- Liberty Chowk → MM Alam Road
(2, 3, 3.0),  -- MM Alam Road → Gulberg Main
(3, 4, 5.0),  -- Gulberg Main → Services Hospital
(1, 4, 9.0),  -- Liberty Chowk → Services Hospital
(5, 6, 4.0),  -- Mall Road → Anarkali Bazaar
(6, 7, 6.0),  -- Anarkali Bazaar → Shadman Chowk
(7, 8, 7.5),  -- Shadman Chowk → Ferozepur Road
(8, 9, 5.5),  -- Ferozepur Road → Canal Bank
(9, 10, 8.0); -- Canal Bank → Model Town Link Road

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
INSERT INTO audit_logs (user_id, action, details) VALUES
(1, 'Login', 'Admin logged in'),
(2, 'Dispatch Assigned', 'Operator assigned ambulance LHR-102 to emergency 1'),
(3, 'Station Updated', 'StationManager updated Central Station coordinates'),
(2, 'Emergency Closed', 'Operator marked emergency 3 as resolved');

CREATE INDEX idx_emergencies_queue ON emergencies (status, severity, priority, enqueued_at);

CREATE INDEX idx_ambulances_station_status ON ambulances (station_id, status);

CREATE INDEX idx_dispatches_status ON dispatches (status);

CREATE INDEX idx_stations_name ON stations (name);
