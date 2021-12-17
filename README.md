# Library managment application
> It's an application for manage library, store books and store information about customers, application is created with ASP.NET.

## Table of contents
* [Information](#information)
* [Technologies](#technologies)
* [Features](#features)
* [Sreenshots](#screenshots)
* [Project status](#project-status)


## Information
The application is created to improve the operation of small and medium-sized libraries. Library application is able to help library staff with daily job and make easier for readers to reserve or rental books.
The application let employees to store information about quantity books and better control rentals of readers, we can watch new features of rental and manage users roles soon, in the future LibraryMVC will have change designe on front-end and have possibility to shared information about quantity books to outside services.
Most of functionalities are available in the Features section. 
LibraryMVC is designed thanks to ASP.NET Core MVC.
This application is built in Clean Architecture and the Service-Repository pattern.

## Technologies
* .NET Core 5.0
* ASP.NET, HTML5, CSS3
* MSSQL
* Depedency Injection
* Entity Framework Core 5.0.9
* LINQ
* Fluent Validation 10.3.0
* AutoMapper 10.1.1
* Cloudscribe.Web.Pagination 3.1.0
* Authentication Google/Facebook 5.0.10
* SendGrid 9.24.2


## Features
* Books managment - CRUD operations which can use by library staff
* Authors/Categories/Publishers/Types managment - CRUD operations which can use by library staff
* Customers managment - CRUD operations which can use by library staff
* Creating/editing reader account - every readers can create/editing his own account, employees are able to have created local accounts yet. 
* Customers View - Viewing customers list
* Authors/Books/Categories/Publishers/Types Views - Viewing Authors/Books/Categories/Publishers/Types lists
* Authors/Books Details View - Every person in library application can show authors/books details
* Reserve Book - Every person in library application can reserve book.
* Reservation View - Every person in library can show own reservations, employees can show all reservations
* Reservation Details - Every person in library can show own reservations details, employees can show all reservations details
* Login/Register - Readers are able to Register or Login to application
* Account Authentication Google/Facebook - Customers are able to create account thanks to Google or Facebook.
* Features Soon: Rentals CRUD and managment of UsersRoles

## Screenshots
### Books page
![Books page](/LibraryMVC.WebApplication/wwwroot/images/screens/Books.png)
### Create Book
![Create Book](/LibraryMVC.WebApplication/wwwroot/images/screens/CreateBook.png)
### Register Panel
![Register Panel](/LibraryMVC.WebApplication/wwwroot/images/screens/RegisterPanel.png)
### Profile Details
![Profile Details](/LibraryMVC.WebApplication/wwwroot/images/screens/ProfileDetails.png)
### Authors page
![Authors page](/LibraryMVC.WebApplication/wwwroot/images/screens/Authors.png)
### Create Category
![Create Category](/LibraryMVC.WebApplication/wwwroot/images/screens/AddCategory.png)
### Reservations page
![Reservations page](/LibraryMVC.WebApplication/wwwroot/images/screens/Reservations.png)
### Create Reservation
![Create Reservation](/LibraryMVC.WebApplication/wwwroot/images/screens/CreateReservation.png)


## Project status
Project has not finished yet, we are able to show features such as rentals CRUD and managment of UsersRoles soon, 
in the future application will be change on front-end side.

