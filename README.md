# RentalCarSystem
Description

This project is a car rental management system designed to handle bookings, customer management, vehicle returns, and transactions. It is built with a SQL Server database that organizes data related to customers, vehicles, and rental processes.

Features

Customer Management: Add and manage customer information.

Vehicle Management: Store and track vehicle details such as availability, mileage, and rental rates.

Rental Bookings: Manage vehicle rental bookings, including start and end dates, and pickup/drop-off locations.

Return Processing: Handle vehicle returns and calculate additional charges based on mileage and rental period.

Transactions: Track payments and transactions related to vehicle rentals.


Database Schema

The database consists of several tables and relationships to manage car rentals efficiently:

Tables

People: Contains personal information for both system users and customers.

Users: Stores system user data linked to the People table.

Customers: Contains customer-specific details like driver’s license information.

Vehicles: Manages the list of vehicles, including their availability and rental rates.

RentalBooking: Records details of vehicle bookings.

VehicleReturns: Handles the return process for rented vehicles.

RentalTransaction: Manages the financial transactions related to rentals.


Key Functions and Procedures

GetRentalPricePerDay: A function to calculate the daily rental price based on the vehicle.

SP_BookingNewVehicles: A stored procedure to book a vehicle, check availability, and update the vehicle status.


How to Use

1. Clone the repository and set up the SQL Server database.


2. Run the provided stored procedures and functions to manage rentals, returns, and transactions.


3. Use the backend code (if any) to interact with the database.
