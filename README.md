# ToDo
A Simple Project to Remind Your Tasks

In this project the user can create his to-do list, 
change the description, delete and mark as done.

To access his list, the user must be logged in and 
if he does not have access, he can register in the application.


## Project Info

The official home of the `PyOxidizer` project is
https://github.com/rcamara32/ToDo.


This project is built in ASP.NET MVC Framework 4.6.

using modern frameworks like Bootstrap to work in any browser like: 
Chrome, Safari, Opera, Firefox, among others.

### Front-End

To develop the application interface, I chose ASP .NET MVC and use 
cross-browser components to work on any device and make the 
user experience the best it can be.

Components:

* Bootstrap v3.3.7
* Toastr v2.1.3
* Datatables v1.10.19
* Jquery v3.3.1

### Back-End

I chose to approach the DDD software model, in order to facilitate 
the division of responsibility and business rule. 
This way we can easily scale and test the application.

Patterns:

* Repository
* Dependendy Injection
* Entities
* Services


I also opted for Code-First's approach to making development more dynamic 
and Entity Framework (with Fluent API) to simplifies mapping between objects and to increase 
the productivity by reducing the redundant task of persisting of data.

### Unit Tests

Unit tests were implemented to verify the correct implementation 
of each method of the business rule.

* TestFramework
* Moq


### Configuration

To run the project, you must follow the steps below:

- Change the connectionstring within web.config to the database you have access to.
- Open the Package Manager Console, choose the ToDoList.Repository project and run the command line: "update-database -verbose".


After that the database will be created with some initial data 
and you can access the project with the following user if you want:

* Username: deloitte.ireland
* Password: deloitte123

Otherwise, register a new user.

Ready! Enjoy it!