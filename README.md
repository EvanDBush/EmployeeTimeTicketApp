# Employee Time Ticket Application

- [x] Project is uploaded to your GitHub repository and shows at minimum 5 separate commits.
Using GitHub’s file uploader on their website does not count as a check-in. You must upload via Git commands
Essentially, we need to see that you are using Git regularly as intended and not just waiting until your project is done to upload your final content
Note that committing and pushing 5 changes at one time is a single commit, not 5 separate commits.

- [x] Project includes a README file that explains the following:

### A one paragraph or longer description of what your project is about

This project is an API for interacting with a database of employee time tickets, project and employee information. 
It was built using .NET6.0, Entity Framework, and SQL Server. Object models are created for Employees, Projects, and TimeTickets.
A list of TimeTickets is stored in the Employee object. The Project object keeps a list of Employees and Tickets. 
TimeTickets stored contain an employee and project id. The project was designed to showcase some of the 
development principles we have learned through the CodeLouisville program. Beyond general C# and .NET basics, this 
project uses the Object Relational Mapper Entity Framework to build a relational database from the designed object classes. 
 
### Features List

- [x] 3+ features you have included from the below list to meet the requirements.

1. This application is an API connected to a local SQL server database.

2. The API takes advantage of asynchronus programming to handle api requests. The GET, PUT,POST, etc. methods in the API controllers
are asynchronus.

3. The application was built using SOLID design principles such as Single Responsibility and Dependency Injection.

4. Using the SwaggerUI, Employee objects can be Created, Read, Updated, and Deleted (CRUD API) from the Database.

- [x] special instructions required for the reviewer to run your project.

After cloning and building the project, please run "update-database" 
command in the nuget package manager console. This will build a local SQL server database 
you can explore using SwaggerUI in the browser.


Guide to use markdown for README.md files. (https://guides.github.com/features/mastering-markdown/)

- [x] You must create at least one class, 
 Employee class is created in EmployeeTimeTicketApp.Domain, as well as Project class and TimeTicket class.

- [x] create at least one object of that class 
and populate it with data from a database. 
After creating an employee object with the swagger ui, it can be stored and retrieved from the local database.

- [x] You must use or display the data in your application.  
You are only required to have 1 table (one entity).

Data can be created, read, updated or deleted through the api.

- [x] Create and call at least 3 functions or methods, 
at least one of which must return a value that is used in your application.

Methods for calls to the database are found in the Controllers folder.
The "Get" method returns an employee object given an id number.

Choose at least 3 items on the Features List below and implement them in your project
We recommend you pick a 4th item (or more!) to add, 
just in case something goes wrong with one of your other items 

- 3 is only the minimum requirement


Failure to meet all requirements will result in you not completing the class.FEATURE LIST:


- [] Create 3 or more unit tests for your application



- [x] Implement a regular expression (regex) to ensure a field either a phone number or an email address is always stored and displayed in the same format



- [] Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program



- [x] Implement a log that records errors, invalid inputs, or other important events and writes them to a text file

	In the startup.cs file a private Streamwriter named "ErrorLog.txt" is created. 
	While configuring the options for the dbcontext, errors are configured to append to the ErrorLog file. 


- [x] Add comments to your code explaining how you are using at least 2 of the solid principles



- [] Make a generic class and use it


- [x] Make your application an API

T	his application includes routes to query a local SQL Server that stores Employee Information, Projects, and TimeTickets.
	The API can be manipulated through the SwaggerUI running in the browser.


- [x] Make your application a CRUD API

	Located in the EmployeeTimeTicketApp.UI project, in the Controllers folder are methods 
	to Create, Read, Update and Delete Employees from the database.


- [x] Make your application asynchronous

	All of the POST,GET, DELETE, etc. classes in the EmployeesController.cs file are asynchronous. 
	They send an asynchronous request to the Database, then await a response.  



- [] Have 2 or more tables (entities) in your application that are related and have a function return data from both entities.  In entity framework, this is equivalent to a join


-[] Query your database using a raw SQL query, not EF
