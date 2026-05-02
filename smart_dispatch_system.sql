-- Create database and user
CREATE DATABASE smart_dispatch_system;
USE smart_dispatch_system;


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
select* from users;
-- =========================
-- Intersections table
-- =========================
CREATE TABLE intersections (
    intersection_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    latitude DECIMAL(9,6),
    longitude DECIMAL(9,6)
);
select* from intersections;
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
select* from stations;

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

select* from ambulances;

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
select* from emergencies;
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
select* from dispatches;
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
select* from routes;
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
select* from roads;
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
select* from audit_logs;
CREATE TABLE ambulance_locations (
    ambulance_id INT PRIMARY KEY,
    latitude DECIMAL(9,6),
    longitude DECIMAL(9,6),
    last_updated TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
select* from ambulance_locations;
-- =========================
-- Indexes
-- =========================
CREATE INDEX idx_emergencies_queue ON emergencies (status, severity, priority, enqueued_at);
CREATE INDEX idx_ambulances_station_status ON ambulances (station_id, status);
CREATE INDEX idx_dispatches_status ON dispatches (status);
CREATE INDEX idx_stations_name ON stations (name);

INSERT INTO intersections (name, latitude, longitude)
VALUES
('Liberty Roundabout, Gulberg', 31.5065, 74.3569),
('MM Alam & Main Blvd', 31.5078, 74.3552),
('Kalma Chowk', 31.5051, 74.3404),
('Ferozepur Rd & Canal Bank', 31.4979, 74.3386),
('Model Town Link Rd & Ferozepur', 31.4853, 74.3307),
('Thokar Niaz Beg Interchange', 31.4706, 74.2653),
('Canal Rd & Johar Town', 31.4692, 74.2908),
('Wahdat Rd & Canal', 31.5098, 74.3010),
('Mall Rd & Canal', 31.5403, 74.3306),
('Zaman Park & Canal', 31.5502, 74.3434),
('Mall Rd & Lakshmi Chowk', 31.5459, 74.3226),
('Anarkali Bazaar Junction', 31.5450, 74.3210),
('Data Darbar Junction', 31.5732, 74.3094),
('Railway Station Roundabout', 31.5654, 74.3165),
('Allama Iqbal Town Main Blvd', 31.5136, 74.3002);

INSERT INTO stations (name, latitude, longitude, intersection_id)
VALUES
('Rescue Station Liberty', 31.5066, 74.3568, 1),
('Rescue Station MM Alam', 31.5080, 74.3551, 2),
('Rescue Station Kalma Chowk', 31.5049, 74.3406, 3),
('Rescue Station Ferozepur-Canal', 31.4981, 74.3388, 4),
('Rescue Station Model Town Link', 31.4855, 74.3305, 5),
('Rescue Station Thokar Niaz Beg', 31.4708, 74.2651, 6),
('Rescue Station Johar Town Canal', 31.4690, 74.2910, 7),
('Rescue Station Wahdat-Canal', 31.5096, 74.3012, 8),
('Rescue Station Mall-Canal', 31.5401, 74.3304, 9),
('Rescue Station Zaman Park', 31.5500, 74.3432, 10),
('Rescue Station Lakshmi Chowk', 31.5461, 74.3228, 11),
('Rescue Station Anarkali', 31.5452, 74.3212, 12),
('Rescue Station Data Darbar', 31.5730, 74.3096, 13),
('Rescue Station Railway', 31.5656, 74.3167, 14),
('Rescue Station Iqbal Town', 31.5138, 74.3004, 15);

INSERT INTO ambulances (station_id, plate_number, equipment, status, current_latitude, current_longitude, is_active)
VALUES
(1,  'LHR-AMB-001', 'Defib, O2, Trauma kit', 'Available', 31.5067, 74.3567, 1),
(2,  'LHR-AMB-002', 'Defib, O2, Ventilator', 'Available', 31.5081, 74.3550, 1),
(3,  'LHR-AMB-003', 'Trauma kit, Splints', 'Available', 31.5050, 74.3405, 1),
(4,  'LHR-AMB-004', 'Defib, O2', 'Available', 31.4982, 74.3387, 1),
(5,  'LHR-AMB-005', 'Defib, O2, Trauma kit', 'Available', 31.4856, 74.3306, 1),
(6,  'LHR-AMB-006', 'Defib, O2, Ventilator', 'Available', 31.4709, 74.2650, 1),
(7,  'LHR-AMB-007', 'Trauma kit, Splints', 'Available', 31.4689, 74.2911, 1),
(8,  'LHR-AMB-008', 'Defib, O2', 'Available', 31.5097, 74.3011, 1),
(9,  'LHR-AMB-009', 'Defib, O2, Trauma kit', 'Available', 31.5400, 74.3303, 1),
(10, 'LHR-AMB-010', 'Defib, O2, Ventilator', 'Available', 31.5499, 74.3431, 1),
(11, 'LHR-AMB-011', 'Trauma kit, Splints', 'Available', 31.5462, 74.3227, 1),
(12, 'LHR-AMB-012', 'Defib, O2', 'Available', 31.5453, 74.3211, 1),
(13, 'LHR-AMB-013', 'Defib, O2, Trauma kit', 'Available', 31.5731, 74.3095, 1),
(14, 'LHR-AMB-014', 'Defib, O2, Ventilator', 'Available', 31.5657, 74.3166, 1),
(15, 'LHR-AMB-015', 'Trauma kit, Splints', 'Available', 31.5139, 74.3003, 1);

INSERT INTO emergencies (caller_name, caller_phone, latitude, longitude, severity, description, status, intersection_id, priority)
VALUES
('Ali Khan', '03001234567', 31.5060, 74.3565, 'Critical', 'Heart attack at Liberty Market', 'Waiting', 1, 3),
('Sara Malik', '03019876543', 31.5075, 74.3550, 'High', 'Road accident near MM Alam', 'Waiting', 2, 2),
('Bilal Ahmed', '03005551234', 31.5052, 74.3402, 'Critical', 'Multi-vehicle crash at Kalma Chowk', 'Waiting', 3, 3),
('Ayesha Noor', '03007778888', 31.4980, 74.3385, 'Medium', 'Minor collision at Ferozepur Canal', 'Waiting', 4, 1),
('Hamza Tariq', '03009991111', 31.4854, 74.3308, 'High', 'Fire incident near Model Town Link', 'Waiting', 5, 2),
('Fatima Shah', '03002223333', 31.4707, 74.2652, 'Critical', 'Bus accident at Thokar Niaz Beg', 'Waiting', 6, 3),
('Usman Ali', '03004445555', 31.4691, 74.2909, 'Low', 'Bike slip at Johar Town Canal', 'Waiting', 7, 0),
('Maryam Zafar', '03006667777', 31.5099, 74.3011, 'Medium', 'Car breakdown at Wahdat Canal', 'Waiting', 8, 1),
('Imran Haider', '03008889999', 31.5402, 74.3305, 'High', 'Accident at Mall Canal', 'Waiting', 9, 2),
('Zainab Akhtar', '03001112222', 31.5501, 74.3433, 'Critical', 'Stroke patient at Zaman Park', 'Waiting', 10, 3),
('Ahmad Raza', '03003334444', 31.5460, 74.3225, 'Medium', 'Collision at Lakshmi Chowk', 'Waiting', 11, 1),
('Sana Javed', '03005556666', 31.5451, 74.3213, 'High', 'Fire near Anarkali Bazaar', 'Waiting', 12, 2),
('Noman Iqbal', '03007779999', 31.5733, 74.3095, 'Critical', 'Stampede at Data Darbar', 'Waiting', 13, 3),
('Hira Aslam', '03009990000', 31.5655, 74.3164, 'Medium', 'Train station injury', 'Waiting', 14, 1),
('Shahid Mehmood', '03001231231', 31.5137, 74.3003, 'High', 'Gas leak at Iqbal Town', 'Waiting', 15, 2);

INSERT INTO dispatches (emergency_id, ambulance_id, eta_minutes, status)
VALUES
(1, 1, 5, 'Assigned'),
(2, 2, 7, 'Assigned'),
(3, 3, 4, 'Assigned'),
(4, 4, 6, 'Assigned'),
(5, 5, 8, 'Assigned'),
(6, 6, 10, 'Assigned'),
(7, 7, 3, 'Assigned'),
(8, 8, 5, 'Assigned'),
(9, 9, 6, 'Assigned'),
(10, 10, 4, 'Assigned'),
(11, 11, 7, 'Assigned'),
(12, 12, 5, 'Assigned'),
(13, 13, 9, 'Assigned'),
(14, 14, 6, 'Assigned'),
(15, 15, 8, 'Assigned');

INSERT INTO routes (dispatch_id, path, total_distance, total_time)
VALUES
(1, '1-2-3', 5.2, 8),
(2, '2-3-4', 7.5, 12),
(3, '3-4-5', 9.0, 15),
(4, '4-5-6', 6.8, 10),
(5, '5-6-7', 3.5, 5),
(6, '6-7-8', 12.0, 20),
(7, '7-8-9', 15.0, 25),
(8, '8-9-10', 11.0, 18),
(9, '9-10-1', 20.0, 30),
(10, '10-1-2', 14.0, 22),
(11, '11-12-13', 9.5, 15),
(12, '12-13-14', 7.2, 12),
(13, '13-14-15', 13.0, 20),
(14, '14-15-16', 8.4, 13),
(15, '15-16-17', 10.5, 17);

INSERT INTO roads (from_intersection_id, to_intersection_id, travel_time_minutes, status, traffic_factor, name, distance_km)
VALUES
(1, 2, 5.0, 'Open', 1.00, 'Liberty to MM Alam', 2.0),
(2, 3, 7.0, 'Open', 1.10, 'MM Alam to Kalma Chowk', 3.0),
(3, 4, 4.0, 'Open', 1.00, 'Kalma to Ferozepur Canal', 1.5),
(4, 5, 6.0, 'Open', 1.20, 'Ferozepur to Model Town Link', 2.5),
(5, 6, 8.0, 'Open', 1.00, 'Model Town to Thokar Niaz Beg', 3.5),
(6, 7, 10.0, 'Open', 1.30, 'Thokar to Johar Town Canal', 4.0),
(7, 8, 3.0, 'Open', 1.00, 'Johar Town to Wahdat Canal', 1.2),
(8, 9, 5.0, 'Open', 1.10, 'Wahdat to Mall Canal', 2.0),
(9, 10, 6.0, 'Open', 1.00, 'Mall Canal to Zaman Park', 2.5),
(10, 11, 4.0, 'Open', 1.00, 'Zaman Park to Lakshmi Chowk', 1.5),
(11, 12, 5.0, 'Open', 1.10, 'Lakshmi Chowk to Anarkali', 2.0),
(12, 13, 6.0, 'Open', 1.20, 'Anarkali to Data Darbar', 2.5),
(13, 14, 7.0, 'Open', 1.00, 'Data Darbar to Railway Station', 3.0);











