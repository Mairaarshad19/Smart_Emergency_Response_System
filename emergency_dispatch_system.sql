-- Create database and user
CREATE DATABASE emergency_dispatch_system;
USE emergency_dispatch_system;

-- =========================
-- Users table y 
-- =========================
CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    role ENUM('Admin','Operator','StationManager') NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
ALTER TABLE users 
MODIFY role ENUM('Admin','Operator') NOT NULL;
SELECT DISTINCT role FROM users;
UPDATE users SET role = 'Operator' WHERE role = 'StationManager';
SET SQL_SAFE_UPDATES = 0;

UPDATE users 
SET role = 'Operator' 
WHERE role = 'StationManager' AND user_id > 0;




SELECT* FROM users;

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
SELECT* FROM stations;

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
    FOREIGN KEY (station_id) REFERENCES stations(station_id)
);
SELECT* FROM ambulances;

ALTER TABLE ambulances ADD COLUMN is_active TINYINT(1) DEFAULT 1;

-- 1. Find the foreign keys on dispatches
SHOW CREATE TABLE dispatches;

-- Look for lines like:
-- CONSTRAINT `dispatches_ibfk_2` FOREIGN KEY (`ambulance_id`) REFERENCES `ambulances` (`ambulance_id`)

-- 2. Drop the old foreign key
ALTER TABLE dispatches DROP FOREIGN KEY dispatches_ibfk_2;

-- 3. Recreate with cascade
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
SELECT* FROM emergencies;

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
    status ENUM('Assigned','OnTheWay','Arrived','Cancelled') DEFAULT 'Assigned',
    reassigned_from_dispatch_id INT NULL,
    FOREIGN KEY (emergency_id) REFERENCES emergencies(emergency_id),
    FOREIGN KEY (ambulance_id) REFERENCES ambulances(ambulance_id)
);
SELECT* FROM dispatches;
ALTER TABLE dispatches
DROP FOREIGN KEY dispatches_ibfk_2;

ALTER TABLE dispatches
ADD CONSTRAINT dispatches_ibfk_2
FOREIGN KEY (ambulance_id) REFERENCES ambulances(ambulance_id)
ON DELETE CASCADE;


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

INSERT INTO users (username, password_hash, role)
VALUES
('admin1', 'hash_admin1', 'Admin'),
('admin2', 'hash_admin2', 'Admin'),
('operator1', 'hash_op1', 'Operator'),
('operator2', 'hash_op2', 'Operator'),
('operator3', 'hash_op3', 'Operator'),
('manager1', 'hash_mgr1', 'StationManager'),
('manager2', 'hash_mgr2', 'StationManager'),
('manager3', 'hash_mgr3', 'StationManager'),
('manager4', 'hash_mgr4', 'StationManager'),
('manager5', 'hash_mgr5', 'StationManager');


INSERT INTO intersections (name, latitude, longitude)
VALUES
('Anarkali Bazaar', 31.5204, 74.3587),
('Mall Road', 31.5497, 74.3436),
('Gulberg Main', 31.5650, 74.3500),
('Shadman Chowk', 31.5800, 74.3700),
('Cantt Market', 31.6000, 74.3800),
('Model Town Park', 31.6100, 74.4000),
('Johar Town Expo', 31.6200, 74.4100),
('Faisal Town Square', 31.6300, 74.4200),
('DHA Phase 5', 31.6400, 74.4300),
('Wapda Town Roundabout', 31.6500, 74.4400);
INSERT INTO intersections (name, latitude, longitude)
VALUES
('Liberty Market', 31.5360, 74.3560),
('Fort Road', 31.5880, 74.3100),
('Ichhra Bazaar', 31.5400, 74.3300),
('Racecourse Park', 31.5600, 74.3500),
('Shalimar Gardens', 31.6000, 74.3700),
('Badshahi Mosque', 31.5890, 74.3090),
('Minar-e-Pakistan', 31.5920, 74.3150),
('Lahore Railway Station', 31.5700, 74.3200),
('Canal Bank', 31.5650, 74.3700),
('Allama Iqbal Town', 31.5200, 74.3800);

SELECT* FROM intersections;

INSERT INTO stations (name, latitude, longitude, intersection_id)
VALUES
('Station 1 - Anarkali', 31.5204, 74.3587, 1),
('Station 2 - Mall Road', 31.5497, 74.3436, 2),
('Station 3 - Gulberg', 31.5650, 74.3500, 3),
('Station 4 - Shadman', 31.5800, 74.3700, 4),
('Station 5 - Cantt', 31.6000, 74.3800, 5),
('Station 6 - Model Town', 31.6100, 74.4000, 6),
('Station 7 - Johar Town', 31.6200, 74.4100, 7),
('Station 8 - Faisal Town', 31.6300, 74.4200, 8),
('Station 9 - DHA', 31.6400, 74.4300, 9),
('Station 10 - Wapda Town', 31.6500, 74.4400, 10);

INSERT INTO stations (name, latitude, longitude, intersection_id)
VALUES
('Station 11 - Liberty', 31.5360, 74.3560, 11),
('Station 12 - Fort Road', 31.5880, 74.3100, 12),
('Station 13 - Ichhra', 31.5400, 74.3300, 13),
('Station 14 - Racecourse', 31.5600, 74.3500, 14),
('Station 15 - Shalimar', 31.6000, 74.3700, 15),
('Station 16 - Badshahi', 31.5890, 74.3090, 16),
('Station 17 - Minar-e-Pakistan', 31.5920, 74.3150, 17),
('Station 18 - Railway', 31.5700, 74.3200, 18),
('Station 19 - Canal Bank', 31.5650, 74.3700, 19),
('Station 20 - Iqbal Town', 31.5200, 74.3800, 20);

INSERT INTO ambulances (station_id, plate_number, equipment, status, current_latitude, current_longitude)
VALUES
(11, 'LHR-1501', 'Basic Kit', 'Available', 31.5360, 74.3560),
(12, 'LHR-1601', 'Advanced Kit', 'Dispatched', 31.5880, 74.3100),
(13, 'LHR-1701', 'Cardiac Unit', 'Busy', 31.5400, 74.3300),
(14, 'LHR-1801', 'Trauma Unit', 'OnTheWay', 31.5600, 74.3500),
(15, 'LHR-1901', 'Basic Kit', 'Available', 31.6000, 74.3700),
(16, 'LHR-2001', 'Advanced Kit', 'Dispatched', 31.5890, 74.3090),
(17, 'LHR-2101', 'Cardiac Unit', 'Busy', 31.5920, 74.3150),
(18, 'LHR-2201', 'Trauma Unit', 'OnTheWay', 31.5700, 74.3200),
(19, 'LHR-2301', 'Basic Kit', 'Available', 31.5650, 74.3700),
(20, 'LHR-2401', 'Advanced Kit', 'Available', 31.5200, 74.3800);


INSERT INTO ambulances (station_id, plate_number, equipment, status, current_latitude, current_longitude)
VALUES
(1, 'LHR-501', 'Basic Kit', 'Available', 31.5204, 74.3587),
(2, 'LHR-601', 'Advanced Kit', 'Dispatched', 31.5497, 74.3436),
(3, 'LHR-701', 'Cardiac Unit', 'Busy', 31.5650, 74.3500),
(4, 'LHR-801', 'Trauma Unit', 'Available', 31.5800, 74.3700),
(5, 'LHR-901', 'Basic Kit', 'Available', 31.6000, 74.3800),
(6, 'LHR-1001', 'Advanced Kit', 'OnTheWay', 31.6100, 74.4000),
(7, 'LHR-1101', 'Cardiac Unit', 'Available', 31.6200, 74.4100),
(8, 'LHR-1201', 'Trauma Unit', 'Busy', 31.6300, 74.4200),
(9, 'LHR-1301', 'Basic Kit', 'Available', 31.6400, 74.4300),
(10, 'LHR-1401', 'Advanced Kit', 'Available', 31.6500, 74.4400);


INSERT INTO emergencies (caller_name, caller_phone, latitude, longitude, severity, description, status, intersection_id, priority)
VALUES
('Ali Khan', '03001234567', 31.5210, 74.3590, 'High', 'Accident at Anarkali', 'Waiting', 1, 2),
('Sara Malik', '03007654321', 31.5500, 74.3440, 'Critical', 'Heart attack Mall Road', 'Waiting', 2, 5),
('Bilal Ahmed', '03009876543', 31.5660, 74.3510, 'Medium', 'Minor fire Gulberg', 'Assigned', 3, 1),
('Fatima Noor', '03001112222', 31.5810, 74.3710, 'High', 'Car crash Shadman', 'Waiting', 4, 3),
('Usman Tariq', '03003334444', 31.6010, 74.3810, 'Low', 'Fainting Cantt', 'Resolved', 5, 0),
('Ayesha Raza', '03005556666', 31.6110, 74.4010, 'Critical', 'Explosion Model Town', 'Waiting', 6, 5),
('Hamza Ali', '03007778888', 31.6210, 74.4110, 'High', 'Building collapse Johar Town', 'Assigned', 7, 4),
('Nida Shah', '03009990000', 31.6310, 74.4210, 'Medium', 'Gas leak Faisal Town', 'Waiting', 8, 2),
('Imran Haider', '03001239876', 31.6410, 74.4310, 'Critical', 'Multi-vehicle crash DHA', 'Waiting', 9, 5),
('Zara Iqbal', '03004561234', 31.6510, 74.4410, 'High', 'Fire Wapda Town', 'Waiting', 10, 3);


INSERT INTO emergencies (caller_name, caller_phone, latitude, longitude, severity, description, status, intersection_id, priority)
VALUES
('Khalid Mehmood', '03001110001', 31.5365, 74.3565, 'Low', 'Minor injury Liberty', 'Waiting', 11, 1),
('Sadia Javed', '03002220002', 31.5885, 74.3105, 'Medium', 'Food poisoning Fort Road', 'Assigned', 12, 2),
('Ahmed Raza', '03003330003', 31.5405, 74.3305, 'High', 'Car accident Ichhra', 'Waiting', 13, 3),
('Bushra Khan', '03004440004', 31.5605, 74.3505, 'Critical', 'Heart attack Racecourse', 'Waiting', 14, 5),
('Tariq Ali', '03005550005', 31.6005, 74.3705, 'Low', 'Fainting Shalimar', 'Resolved', 15, 1),
('Noreen Akhtar', '03006660006', 31.5895, 74.3095, 'Medium', 'Gas leak Badshahi', 'Waiting', 16, 2),
('Hassan Shah', '03007770007', 31.5925, 74.3155, 'High', 'Explosion Minar-e-Pakistan', 'Assigned', 17, 4),
('Iqra Aslam', '03008880008', 31.5705, 74.3205, 'Critical', 'Building collapse Railway', 'Waiting', 18, 5),
('Zeeshan Malik', '03009990009', 31.5655, 74.3705, 'Medium', 'Fire Canal Bank', 'Waiting', 19, 3),
('Farah Nadeem', '0300101010', 31.5205, 74.3805, 'High', 'Multi-vehicle crash Iqbal Town', 'Waiting', 20, 4);

INSERT INTO dispatches (emergency_id, ambulance_id, eta_minutes, arrival_time, status)
VALUES
(1, 1, 8, NULL, 'Assigned'),
(2, 2, 12, NULL, 'Assigned'),
(3, 3, 15, '2026-01-02 19:00:00', 'Arrived'),
(4, 4, 10, NULL, 'OnTheWay'),
(5, 5, 5, '2026-01-02 18:45:00', 'Arrived'),
(6, 6, 20, NULL, 'Assigned'),
(7, 7, 25, NULL, 'OnTheWay'),
(8, 8, 18, NULL, 'Assigned'),
(9, 9, 30, NULL, 'Assigned'),
(10, 10, 22, NULL, 'Assigned');

INSERT INTO dispatches (emergency_id, ambulance_id, eta_minutes, arrival_time, status)
VALUES
(40, 12, 12, NULL, 'OnTheWay'),
(41, 13, 15, '2026-01-03 19:00:00', 'Arrived'),
(42, 14, 10, NULL, 'Assigned'),
(43, 15, 5, '2026-01-03 18:45:00', 'Arrived'),
(44, 16, 20, NULL, 'Assigned'),
(45, 17, 25, NULL, 'OnTheWay'),
(46, 18, 18, NULL, 'Assigned'),
(47, 19, 30, NULL, 'Cancelled'),
(48, 20, 22, NULL, 'Assigned'),
(49, 21, 14, NULL, 'OnTheWay');

select* from dispatches;

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
(10, '10-1-2', 14.0, 22);

INSERT INTO routes (dispatch_id, path, total_distance, total_time)
VALUES
(78, '39-40-41', 5.2, 8),
(79, '40-41-42', 7.5, 12),
(80, '41-42-43', 9.0, 15),
(81, '42-43-44', 6.8, 10),
(82, '43-44-45', 3.5, 5),
(83, '44-45-46', 12.0, 20),
(84, '45-46-47', 15.0, 25),
(85, '46-47-48', 11.0, 18),
(86, '47-48-49', 20.0, 30),
(87, '48-49-39', 14.0, 22);
select* from routes;

INSERT INTO roads (from_intersection_id, to_intersection_id, travel_time_minutes, status, traffic_factor, name, distance_km)
VALUES
(1, 2, 5.0, 'Open', 1.00, 'Anarkali to Mall Road', 2.5),
(2, 3, 7.0, 'Open', 1.10, 'Mall Road to Gulberg', 3.2),
(3, 4, 6.0, 'Open', 1.00, 'Gulberg to Shadman', 2.8),
(4, 5, 8.0, 'Open', 1.20, 'Shadman to Cantt', 4.0),
(5, 6, 10.0, 'Open', 1.00, 'Cantt to Model Town', 5.0),
(6, 7, 12.0, 'Open', 1.15, 'Model Town to Johar Town', 6.0),
(7, 8, 9.0, 'Open', 1.05, 'Johar Town to Faisal Town', 4.5),
(8, 9, 11.0, 'Open', 1.00, 'Faisal Town to DHA', 5.5),
(9, 10, 13.0, 'Open', 1.25, 'DHA to Wapda Town', 6.5),
(10, 1, 15.0, 'Open', 1.10, 'Wapda Town to Anarkali', 7.0);

INSERT INTO roads (from_intersection_id, to_intersection_id, travel_time_minutes, status, traffic_factor, name, distance_km)
VALUES
(11, 12, 5.0, 'Open', 1.00, 'Liberty to Fort Road', 2.5),
(12, 13, 7.0, 'Open', 1.10, 'Fort Road to Ichhra', 3.2),
(13, 14, 6.0, 'Closed', 1.00, 'Ichhra to Racecourse', 2.8),
(14, 15, 8.0, 'Open', 1.20, 'Racecourse to Shalimar', 4.0),
(15, 16, 10.0, 'Open', 1.00, 'Shalimar to Badshahi', 5.0),
(16, 17, 12.0, 'Closed', 2.00, 'Badshahi to Minar-e-Pakistan', 6.0),
(17, 18, 9.0, 'Open', 1.05, 'Minar-e-Pakistan to Railway', 4.5),
(18, 19, 11.0, 'Open', 1.00, 'Railway to Canal Bank', 5.5),
(19, 20, 13.0, 'Open', 1.25, 'Canal Bank to Iqbal Town', 6.5),
(20, 11, 15.0, 'Open', 1.10, 'Iqbal Town to Liberty', 7.0);

-- Normal road
UPDATE roads 
SET status = 'Closed', traffic_factor = 1.0 
WHERE road_id = 5;

-- Simulate traffic jam
UPDATE roads 
SET status = 'Closed', traffic_factor = 2.0 
WHERE road_id = 6;

-- Simulate closed road
UPDATE roads 
SET status = 'Closed' 
WHERE road_id = 7;

INSERT INTO audit_logs (user_id, action, details)
VALUES
(1, 'Login', 'Admin1 logged in successfully'),
(2, 'Create Station', 'Admin2 created Station 3 - Gulberg'),
(3, 'Dispatch Assigned', 'Operator1 assigned ambulance LHR-701 to emergency 3'),
(4, 'Dispatch Cancelled', 'Operator2 cancelled dispatch for emergency 4'),
(5, 'Update Emergency', 'Operator3 updated severity of emergency 5 to Critical'),
(6, 'Station Update', 'Manager1 updated equipment list for Station 6'),
(7, 'Ambulance Status Change', 'Manager2 marked ambulance LHR-1101 as Busy'),
(8, 'Emergency Resolved', 'Manager3 closed emergency 7 as Resolved'),
(9, 'Route Update', 'Manager4 updated route for dispatch 9'),
(10, 'Logout', 'Manager5 logged out of system');









