Car Rental System - Database Schema

This project is a car rental management system with the following key database components:

Key Tables

1. People

Stores basic information for all users (both customers and staff).

PersonID, FirstName, LastName, PhoneNumber


2. Users

Extends the People table for system users.

UserID, PersonID, UserName, PasswordHash


3. Customers

Stores customer-specific details.

CustomerID, PersonID, DriverLicenseID


4. Vehicles

Manages vehicle information.

VehicleID, Make, Model, Year, Mileage, RentalRatePerDay, IsAvailable


5. RentalBooking

Records vehicle rental bookings.

BookingID, VehicleID, CustomerID, BookingStartDate, BookingEndDate, PickupLocation


6. VehicleReturns

Stores return details for rented vehicles.

ReturnID, TransactionID, ActualReturnDate, CurrentMileage


7. RentalTransaction

Handles payment and transaction details.

TransactionID, PaidAmount, BookingID, TransactionDate


Key Relationships

People ↔ Users/Customers: PersonID links users and customers to personal details.

Vehicles ↔ RentalBooking ↔ RentalTransaction: Manages bookings, transactions, and returns for each vehicle.