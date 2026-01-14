# Real-Time GPS Trajectory Simulator (Major Project)



<img width="960" height="540" alt="image" src="https://github.com/user-attachments/assets/09417c8a-8e69-4822-af7e-a9ce884b1dd5" />



## What the Project Does

This project is a **real-time, GUI-based GPS trajectory simulator** that emulates the motion of a GPS receiver around a user-defined geographic center.

Unlike a static plotting tool, this application behaves like a **navigation motion engine**:

- The user enters a **centre latitude, longitude, and radius (in meters)**.
- The system converts Earth-referenced coordinates into a local Cartesian plane.
- A **timer-driven engine** continuously computes the next position along a circular path.
- Each `(x, y)` position is converted back into **latitude and longitude** using Earth-radius-based geodesy.
- The trajectory is **animated in real time** on a chart, simulating continuous movement.

This mirrors how software-defined navigation systems and GPS emulators work—by generating motion mathematically and rendering it as live positional data.

---

## Features

- Interactive Windows Forms GUI for user input  
- Real-time circular trajectory generation  
- Earth-referenced coordinate transformation (degrees ↔ radians)  
- Local tangent-plane projection using Earth-radius modeling  
- Analytical circle generation using `x² + y² = r²`  
- Timer-driven motion engine for continuous animation  
- Live visualization using `.NET Charting`  
- Dynamic axis scaling and precision formatting  
- Start/Stop simulation control  

Each timer tick:

1. Computes the next `(x, y)` on the circle  
2. Converts it to `(latitude, longitude)`  
3. Plots the point on the chart  
4. Advances motion for the next frame  

This produces a smooth, real-time GPS-like movement.

---

## Tech Stack

- **Language:** C#  
- **Framework:** .NET (Windows Forms)  
- **Libraries:**
  - `System.Windows.Forms`
  - `System.Windows.Forms.DataVisualization.Charting`
- **Core Concepts:**
  - Geodetic ↔ Cartesian transformation  
  - Earth-radius-based spatial modeling  
  - Analytical geometry (circle equation)  
  - Timer-driven simulation loop  
  - Real-time data visualization  

- **Platform:** Windows Desktop

---

## How to Run It

1. Clone the repository:
   ```bash
   git clone <your-repo-url>
2. Open the solution in Visual Studio.
3. Build and run the project.
4. In the GUI:
 - Enter Centre Latitude
 - Enter Centre Longitude
 - Enter Radius (in meters)
 - Click Simulate
5. The application will:
 - Initialize the motion engine
 - Generate a circular trajectory
 - Animate movement in real time on the chart
6. Click Stop to halt the simulation.
