# Student Management System - Credit System

A comprehensive student management system for credit-based education, developed with C# and SQL Server.

## Features

- **Multi-role Authentication**: Support for Academic Affairs Office (PGV), Department (KHOA), Students (SV), and Lecturers (GV)
- **Catalog Management**: Departments, Classes, Students, Lecturers, Courses
- **Credit Class Management**: Opening classes, registration, grade entry
- **Reporting**: Credit class lists, student registration lists, course grade reports, student transcripts, tuition fee reports, final grade reports
- **Administration**: User account creation, database backup and restore

## Database Structure

- **Khoa**: Department information
- **Lop**: Class information
- **Sinhvien**: Student information
- **Giangvien**: Lecturer information
- **Monhoc**: Course information
- **Loptinchi**: Credit class information
- **Dangky**: Student registration information for credit classes

## System Requirements

- Windows 7 or later
- .NET Framework 4.5 or later
- SQL Server 2012 or later

## Installation

1. Create the QLDSV_HTC database using the included SQL script
2. Configure the connection string in App.config
3. Build and run the application

## Login Information

### Student Login
- Username: Student ID (e.g., SV001)
- Password: 123456 (default)

### Lecturer Login
- Username: Lecturer ID (e.g., GV001)
- Password: 123456 (default)

## Project Structure

- **BLL**: Business Logic Layer
- **DAL**: Data Access Layer
- **DTO**: Data Transfer Objects
- **GUI**: Graphical User Interface

## Screenshots

*Coming soon*

## Author

- Threde

## License

This project is licensed under the MIT License - see the LICENSE file for details.
