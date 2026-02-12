"# MOVIE-TICKET-BOOKING-SYSTEM-CDAC-2025-" 


📌 Project Description
A full-stack Movie Ticket Booking System inspired by platforms like BookMyShow.
Built using ASP.NET Core, React (Vite), SQL Server, SignalR, AWS S3, Razorpay, and Redis-ready architecture. It allows users to browse movies, view show timings, select seats, and book tickets through an interactive web interface.


❓ Problem Statement

Traditional movie ticket booking often involves long queues, manual seat allocation, and lack of real-time seat availability. Existing systems are complex and not suitable for learning full-stack fundamentals.

This project solves:
1. Manual ticket booking inefficiency
2. Lack of centralized movie and show management
3. Absence of structured booking workflows for learning purposes
4. Double booking issues
5. No real-time seat updates
6. Poor scalability
7. Manual theatre management
8. Insecure payment handling

This project solves these issues by:
1. Implementing real-time seat locking
2. Using secure JWT authentication
3. Integrating cloud storage for media
4. Integrating payment gateway

Using clean layered backend architecture


🎯 Objectives

To design a real-world online ticket booking platform
To implement end-to-end booking flow
To understand full-stack application architecture
To apply database design and API integration
To simulate a production-like movie booking system


🧩 Features

👤 User
Register / Login (JWT-based authentication)
Browse movies by city
View theatres & show timings
Real-time seat selection
Temporary seat locking (5 minutes)
Secure online payment
Booking history & cancellation

🏢 Theatre Manager
Request manager role
Manage screens
Configure seat layout
Create shows
View past & upcoming shows

👑 Admin
Approve / Reject manager requests
Manage theatres
Manage movies
Monitor bookings

🛠️ Tech Stack
🔹 Frontend
React (Vite)
Axios
React Router
Context API
SignalR Client

🔹 Backend
ASP.NET Core Web API
Entity Framework Core
Clean Architecture (Controller → Service → Repository)
Hosted Background Services
SignalR

🔹 Database
SQL Server (Relational Model)


🔹 Cloud & External Services
AWS S3 (Movie image storage)
Razorpay (Payment Gateway)
Redis-ready configuration (for distributed seat locking)

🏗 System Architecture and Applications Flow
This project follows a Layered Clean Architecture.
Frontend (React)
        ↓
REST API (Controllers)
        ↓
Business Layer (Services)
        ↓
Data Layer (Repositories)
        ↓
Entity Framework Core
        ↓
SQL Server


🧠 Backend Architecture Diagram
                ┌───────────────────────┐
                │       React UI        │
                └────────────┬──────────┘
                             │ HTTP / JWT
                             ▼
                ┌───────────────────────┐
                │     API Controllers   │
                └────────────┬──────────┘
                             │
                             ▼
                ┌───────────────────────┐
                │      Services Layer   │
                │ (Business Logic)      │
                └────────────┬──────────┘
                             │
                             ▼
                ┌───────────────────────┐
                │    Repositories       │
                │ (Data Access Layer)   │
                └────────────┬──────────┘
                             │
                             ▼
                ┌───────────────────────┐
                │     SQL Server DB     │
                └───────────────────────┘


🔐 Authentication & Authorization
Uses JWT (JSON Web Token)
Stateless authentication
Role-based authorization
Passwords hashed using BCrypt

User Login → JWT generated → Token stored in frontend → Token sent in Authorization header 
→ Backend validates signature & claims

🎟️ Seat Locking & Real-Time System 

Problem: Two users selecting the same seat simultaneously.

Solution:
Seat status stored in database
Temporary lock (5 minutes)
SignalR broadcasts changes
Background job removes expired locks

User A selects seat
→ Seat status = LOCKED
→ SignalR broadcasts event
→ User B sees seat locked instantly

💳 Payment Flow (Razorpay)
1. Booking created (Pending)
2. Razorpay order created
3. User completes payment
4. Backend verifies signature
5. Booking confirmed
6. Seats marked BOOKED

Real-Time Flow
Frontend → Razorpay → Backend Verification → Booking Confirmed

☁️ AWS S3 Integration
Used for movie posters.

Flow:
Admin uploads image
→ Backend uploads to S3
→ S3 returns public URL
→ URL stored in database
→ Frontend loads image

Benefits:
No file storage in database
Scalable
Secure

🗄 Database Design

📊 Diagrams
Database Design (Core Tables)
Users
Roles
Movies
Genres
Languages
Theatres
Screens
SeatRows
Seats
Shows
ShowSeatStatus
Bookings
BookingSeats
Payments
SeatStatusLogs

🔄 Booking Flow Diagram
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


⏱️ Background Jobs
The system uses hosted services to:
Expire seat locks
Clean pending bookings
Reconcile payments

⚡ Unique Concepts Used
Clean Architecture
Repository Pattern
Dependency Injection
JWT Authentication
Role-based Authorization
SignalR (Real-Time Communication)
Seat Locking Concurrency Control
Background Hosted Services
AWS S3 Integration
Razorpay Payment Verification
Transaction Management
DTO & Mapper Pattern


🧪 How to Run Locally

Backend
Configure appsettings.Development.json
Add AWS & Razorpay test keys
Run:
dotnet run

Frontend
Navigate to frontend folder
Install dependencies:
npm install
Start dev server:
npm run dev

🔐 Security Considerations
JWT token expiration
Password hashing with BCrypt
Razorpay signature verification
No sensitive data stored in frontend
External keys stored in development config

📈 Scalability
System is designed to support:
Multiple concurrent users
Distributed seat locking (Redis-ready)
Horizontal scaling
Real-time updates

📌 Future Enhancements
CI/CD deployment
Docker containerization
Admin analytics dashboard
Microservices migration
Email/SMS ticket confirmation
Login/Register Using gmail, phone number, etc

🎯 Conclusion
This project demonstrates:
Full-stack architecture design
Real-time concurrency handling
Secure authentication
Payment integration
Cloud storage integration
Production-level backend design patterns
It is a complete enterprise-grade Movie Ticket Booking System, not just a CRUD application.
