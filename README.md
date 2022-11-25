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

A special thank you to Code Louisville and my Mentors Doug Sutherland and Daniel "CD" Waddell. I have had so much fun learning 
about coding and C#. I am grateful for all the time you have given us, I hope someday to pay it forward to others starting their 
careers in Software Development.
 
### Features List

- [x] 3+ features you have included from the below list to meet the requirements.

1. This application is an API connected to a local SQL server database.

2. The API takes advantage of asynchronus programming to handle api requests. The GET, PUT,POST, etc. methods in the API controllers
are asynchronus.

3. The application was built using SOLID design principles such as Single Responsibility and Dependency Injection.

4. Using the SwaggerUI, Employee objects can be Created, Read, Updated, and Deleted (CRUD API) from the Database.

- [x] special instructions required for the reviewer to run your project.

After cloning and building the project, please run "update-database" 
command in the nuget package manager console. Make sure to target the EmployeeTimeTicketApp.Data project.
This will build a local SQL server database. 
You can then explore the API using SwaggerUI in the browser.





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
		
Regular Expressions in the EmployeeTimeTicketApp.Domain Employees class can be used to validate properties as they are entered into the
Employee object.  

This is the regex used: [RegularExpression("^([a-zA-Z]{2,}\\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)",
						ErrorMessage = "Valid Characters include (A-Z) (a-z) (' space -)")]

This is an explaination of the specific regex and its parts:

^               // start of line
[a-zA-Z]{2,}    // will except a name with at least two characters
\s              // will look for white space between name and surname
[a-zA-Z]{1,}    // needs at least 1 Character
\'?-?           // possibility of **'** or **-** for double barreled and hyphenated surnames
[a-zA-Z]{2,}    // will except a name with at least two characters
\s?             // possibility of another whitespace
([a-zA-Z]{1,})? // possibility of a second surname



- [x] Implement a log that records errors, invalid inputs, or other important events and writes them to a text file

	In EmployeeTimeTicketApp.UI, in the startup.cs file, a private Streamwriter named "ErrorLog.txt" is created on line 23. 
	While configuring the options for the dbcontext, errors and other information is configured to append to the ErrorLog file on line 44. 


- [x] Add comments to your code explaining how you are using at least 2 of the solid principles

	Single Responsibility Principle (SRP). Each software module should have one and only one reason to change. The classes for Employees, Projects,
	and Time Tickets, all have the single responsibility of creating objects.
	
	Open and Closed Principle (OCP). A module must be open to extension, but closed to modification. 
	This means new behavior can be added in the future and less bugs are created in the process. An example of this is inheriting the 
	properties of dbContext to use in the app without directly modifying the dbcontext class. Instead we inherit from dbcontext to create
	our own EmployeeTimeTicketContext.

	Dependency Inversion.


- [x] Make your application an API

	This application includes routes to query a local SQL Server that stores Employee Information, Projects, and TimeTickets.
	The API can be manipulated through the SwaggerUI running in the browser.


- [x] Make your application a CRUD API

	Located in the EmployeeTimeTicketApp.UI project, The EmployeesController.cs in the Controllers folder contains methods 
	to Create, Read, Update and Delete Employees from the database.


- [x] Make your application asynchronous

	All of the POST,GET, DELETE, etc. classes in the EmployeesController.cs file are asynchronous. 
	They send an asynchronous request to the Database, then await a response.  


