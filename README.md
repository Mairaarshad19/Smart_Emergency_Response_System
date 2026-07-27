# 🚑 Smart Emergency Response System

![Stars](https://img.shields.io/github/stars/Mairaarshad19/Smart_Emergency_Response_System?style=flat-square)
![Last Commit](https://img.shields.io/github/last-commit/Mairaarshad19/Smart_Emergency_Response_System?style=flat-square)
![Status](https://img.shields.io/badge/status-completed-brightgreen?style=flat-square)

![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET_Framework-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![WinForms](https://img.shields.io/badge/Windows_Forms-0078D6?style=flat-square&logo=windows&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-005C84?style=flat-square&logo=mysql&logoColor=white)
![Google Maps](https://img.shields.io/badge/Google_Maps-4285F4?style=flat-square&logo=googlemaps&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-yellow.svg?style=flat-square)

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

## Screenshots

![Routes](images/routes.png)

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
