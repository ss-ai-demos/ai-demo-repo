# 🌦️ Weather Forecast API Project

Welcome to the Weather Forecast API project! This repository contains the core API services and client applications designed to deliver accurate and timely weather data to users across various platforms.

---

## 📌 Project Overview

This project provides a RESTful API that aggregates and serves weather forecast data. It supports multiple data sources and offers endpoints for current conditions, hourly forecasts, and extended forecasts. The API is designed to be scalable, secure, and easy to integrate.

---

## 🧩 Features

- 🌍 Global weather coverage
- 🕒 Real-time and forecast data (hourly, daily)
- 📍 Location-based queries (city name, coordinates)
- 📊 Historical weather data access
- 🔐 Secure API key authentication
- 📈 JSON-formatted responses for easy parsing

---

## 🧪 Technologies Used

- **Backend:** Node.js / Express
- **Data Sources:** OpenWeatherMap, WeatherAPI, Meteostat
- **Database:** MongoDB (for caching and analytics)
- **Clients:** React (Web), Flutter (Mobile), Python (CLI)

---

## 🖥️ Client Applications

### 1. Web Client (React)
- Responsive UI for desktop and mobile
- Search by city or geolocation
- Displays current weather, forecasts, and trends

### 2. Mobile Client (Flutter)
- Cross-platform support (iOS & Android)
- Push notifications for severe weather alerts
- Offline caching of recent forecasts

### 3. CLI Client (Python)
- Lightweight terminal interface
- Ideal for automation and scripting
- Supports batch queries and CSV export

---

## 🚀 Getting Started

### API Setup
```bash
git clone https://github.com/your-org/weather-api.git
cd weather-api
npm install
npm start
