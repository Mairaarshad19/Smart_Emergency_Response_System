# 🚑 Smart Emergency Response System

A C# Windows Forms application for managing **emergency calls, ambulance dispatch, and coverage** using **Data Structures and Algorithms (DSA)**.

---

## ✨ Features
- Log emergencies with severity (Normal / Critical).
- Dispatch ambulances based on **nearest route** and **availability**.
- Calculate fastest routes using **Graph + Dijkstra’s Algorithm**.
- Coverage analysis: check which areas a station can reach within a time threshold.
- Visualize ambulances, emergencies, and coverage zones on **Google Maps (WebView2)**.
- Manage stations and ambulances with CRUD operations.

---

## 🛠️ Technologies
- **Language:** C# (.NET Framework, Windows Forms)
- **Database:** MySQL
- **Map Integration:** Google Maps via WebView2
- **Libraries:** Newtonsoft.Json, MySql.Data
- **Data Structures:** Queue, Priority Queue, LinkedList, Hash Table, AVL Tree, Graph, QuickSort

---

## 📂 Project Structure
- `BL/` → Business Logic classes (AmbulanceBL, EmergencyBL, StationBL)
- `DL/` → Database Layer (CRUD with MySQL)
- `Managers/` → Workflow controllers (RouteManager, SortManager, StationManager)
- `Helpers/` → Utility classes (GeoHelper, MapHelper)
- `UI/` → Windows Forms (Dashboards, Dispatch, Emergency Logging)
- `GraphAlgorithms/` → Dijkstra, Coverage

---

## ⚙️ How It Works
1. Operator logs an emergency (intersection + severity).
2. System finds nearest available ambulance using **Priority Queue**.
3. Fastest route calculated via **Dijkstra’s Algorithm**.
4. Ambulance dispatched, ETA shown, and dispatch logged.
5. Coverage analysis shows which intersections are reachable within threshold.
6. Map displays ambulances, emergencies, and coverage zones.

---

## 🚀 Getting Started
1. Clone the repo:
   ```bash
   git clone https://github.com/Mairaarshad19/Smart_Emergency_Response_System.git
# 🚑 Smart Emergency Response System

A C# Windows Forms application for managing **emergency calls, ambulance dispatch, and coverage** using **Data Structures and Algorithms (DSA)**.

---

## ✨ Features
- Log emergencies with severity (Normal / Critical).
- Dispatch ambulances based on **nearest route** and **availability**.
- Calculate fastest routes using **Graph + Dijkstra’s Algorithm**.
- Coverage analysis: check which areas a station can reach within a time threshold.
- Visualize ambulances, emergencies, and coverage zones on **Google Maps (WebView2)**.
- Manage stations and ambulances with CRUD operations.

---

## 🛠️ Technologies
- **Language:** C# (.NET Framework, Windows Forms)
- **Database:** MySQL
- **Map Integration:** Google Maps via WebView2
- **Libraries:** Newtonsoft.Json, MySql.Data
- **Data Structures:** Queue, Priority Queue, LinkedList, Hash Table, AVL Tree, Graph, QuickSort

---

## 📂 Project Structure
- `BL/` → Business Logic classes (AmbulanceBL, EmergencyBL, StationBL)
- `DL/` → Database Layer (CRUD with MySQL)
- `Managers/` → Workflow controllers (RouteManager, SortManager, StationManager)
- `Helpers/` → Utility classes (GeoHelper, MapHelper)
- `UI/` → Windows Forms (Dashboards, Dispatch, Emergency Logging)
- `GraphAlgorithms/` → Dijkstra, Coverage

---

## ⚙️ How It Works
1. Operator logs an emergency (intersection + severity).
2. System finds nearest available ambulance using **Priority Queue**.
3. Fastest route calculated via **Dijkstra’s Algorithm**.
4. Ambulance dispatched, ETA shown, and dispatch logged.
5. Coverage analysis shows which intersections are reachable within threshold.
6. Map displays ambulances, emergencies, and coverage zones.

---

## 🚀 Getting Started
1. Clone the repo:
   ```bash
   git clone https://github.com/Mairaarshad19/Smart_Emergency_Response_System.git
