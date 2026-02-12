# 🎬 Movie Ticket Booking System – CDAC 2025

A full-stack **Movie Ticket Booking System** inspired by platforms like BookMyShow.  
Built using **ASP.NET Core, React (Vite), SQL Server, SignalR, AWS S3, Razorpay, and Redis-ready architecture**.

---

## 📌 Project Overview

This project simulates a real-world movie booking platform where users can:

- Browse movies
- View theatres and show timings
- Select seats in real-time
- Make secure online payments
- Receive booking confirmations

It demonstrates production-level backend architecture with real-time seat locking and secure payment verification.

---

## ❓ Problem Statement

Traditional movie booking systems often suffer from:

- Manual seat allocation
- Long queues
- No real-time seat updates
- Double booking issues
- Poor scalability
- Insecure payment handling

### ✅ This Project Solves

- Real-time seat locking
- Secure JWT authentication
- Cloud media storage (AWS S3)
- Payment gateway integration (Razorpay)
- Clean layered backend architecture
- Concurrency control using background services

---

## 🎯 Objectives

- Design a real-world online ticket booking system
- Implement complete end-to-end booking workflow
- Apply full-stack architecture principles
- Implement secure authentication & authorization
- Handle concurrency with real-time updates

---

# 🧩 Features

## 👤 User Module

- Register / Login (JWT-based authentication)
- Browse movies by city
- View theatres & show timings
- Real-time seat selection
- Temporary seat locking (5 minutes)
- Secure online payment
- Booking history & cancellation

---

## 🏢 Theatre Manager Module

- Request manager role
- Manage screens
- Configure seat layouts
- Create shows
- View past & upcoming shows

---

## 👑 Admin Module

- Approve / Reject manager requests
- Manage theatres
- Manage movies
- Monitor bookings

---

# 🛠️ Tech Stack

## 🔹 Frontend
- React (Vite)
- Axios
- React Router
- Context API
- SignalR Client

## 🔹 Backend
- ASP.NET Core Web API
- Entity Framework Core
- Clean Architecture (Controller → Service → Repository)
- Hosted Background Services
- SignalR

## 🔹 Database
- SQL Server (Relational Model)

## 🔹 Cloud & External Services
- AWS S3 (Movie poster storage)
- Razorpay (Payment Gateway)
- Redis-ready configuration (Distributed seat locking)

---

# 🏗️ System Architecture

This project follows Layered Clean Architecture:

```
Frontend (React)
        ↓
API Controllers
        ↓
Services Layer (Business Logic)
        ↓
Repositories (Data Access Layer)
        ↓
Entity Framework Core
        ↓
SQL Server
```

---

# 🧠 Backend Architecture Diagram

```
┌───────────────────────┐
│       React UI        │
└────────────┬──────────┘
             │ HTTP / JWT
             ▼
┌───────────────────────┐
│    API Controllers    │
└────────────┬──────────┘
             ▼
┌───────────────────────┐
│     Services Layer    │
│   (Business Logic)    │
└────────────┬──────────┘
             ▼
┌───────────────────────┐
│     Repositories      │
│  (Data Access Layer)  │
└────────────┬──────────┘
             ▼
┌───────────────────────┐
│     SQL Server DB     │
└───────────────────────┘
```

---

# 🔐 Authentication & Authorization

- JWT (JSON Web Token)
- Stateless authentication
- Role-based authorization
- Password hashing using BCrypt

### Authentication Flow

```
User Login
    ↓
JWT Generated
    ↓
Token stored in Frontend
    ↓
Token sent in Authorization Header
    ↓
Backend validates signature & claims
```

---

# 🎟️ Real-Time Seat Locking System

### Problem
Two users selecting the same seat simultaneously.

### Solution
- Seat status stored in database
- Temporary lock (5 minutes)
- SignalR broadcasts seat updates
- Background job removes expired locks

### Flow

```
User A selects seat
    ↓
Seat marked LOCKED
    ↓
SignalR broadcasts update
    ↓
User B sees seat locked instantly
```

---

# 💳 Payment Flow (Razorpay)

1. Booking created (Pending)
2. Razorpay order created
3. User completes payment
4. Backend verifies signature
5. Booking confirmed
6. Seats marked BOOKED

```
Frontend → Razorpay → Backend Verification → Booking Confirmed
```

---

# ☁️ AWS S3 Integration

Used for storing movie posters.

### Flow

```
Admin uploads image
        ↓
Backend uploads to AWS S3
        ↓
S3 returns public URL
        ↓
URL stored in database
        ↓
Frontend loads image
```

### Benefits

- No file storage in database
- Scalable
- Secure

---

# 🗄️ Database Design

### Core Tables

- Users
- Roles
- Movies
- Genres
- Languages
- Theatres
- Screens
- SeatRows
- Seats
- Shows
- ShowSeatStatus
- Bookings
- BookingSeats
- Payments
- SeatStatusLogs

---

# 🔄 Booking Flow

```
Select Show
      ↓
Select Seats
      ↓
Seats Locked
      ↓
Create Booking (Pending)
      ↓
Initiate Payment
      ↓
Verify Payment
      ↓
Seats Booked
      ↓
Booking Confirmed
```

---

# ⏱️ Background Jobs

Hosted services handle:

- Expiring seat locks
- Cleaning pending bookings
- Payment reconciliation

---

# ⚡ Unique Concepts Implemented

- Clean Architecture
- Repository Pattern
- Dependency Injection
- JWT Authentication
- Role-Based Authorization
- SignalR (Real-Time Communication)
- Seat Locking & Concurrency Control
- Hosted Background Services
- AWS S3 Integration
- Razorpay Payment Verification
- Transaction Management
- DTO & Mapper Pattern

---

# 🧪 How to Run Locally

## Backend

1. Configure `appsettings.Development.json`
2. Add AWS & Razorpay test keys
3. Run:

```bash
dotnet run
```

---

## Frontend

```bash
cd frontend
npm install
npm run dev
```

---

# 🔐 Security Considerations

- JWT token expiration
- Password hashing with BCrypt
- Razorpay signature verification
- No sensitive data stored in frontend
- External keys stored in configuration

---

# 📈 Scalability

Designed to support:

- Multiple concurrent users
- Distributed seat locking (Redis-ready)
- Horizontal scaling
- Real-time updates

---

# 🚀 Future Enhancements

- CI/CD deployment
- Docker containerization
- Admin analytics dashboard
- Microservices migration
- Email/SMS ticket confirmation
- Social login (Google, Phone OTP)

---

# 🎯 Conclusion

This project demonstrates:

- Enterprise-level backend architecture
- Real-time concurrency handling
- Secure authentication & authorization
- Payment gateway integration
- Cloud storage integration
- Production-ready design patterns

> This is a complete enterprise-grade Movie Ticket Booking System — not just a CRUD application.

