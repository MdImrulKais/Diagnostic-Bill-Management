# Diagnostic-Bill-Management

This project can helps the Diagnostic center for their bill management.It is very usefull project for a Diagnostic center or a clinic.
An admin can store all the data for their institution.And by this system they can easily communicate with their client and easily monitor
their billing system.

# Prerequisites

What things you need to install ?

--Visual studio 2013
--Sql Server Management Studio 2012
--Any Browser

How to run the project ?

--At first we have to unzip the project file.
--Then we have to open the Sql Server Management studio.
--We have to create a new database and the database name 
will be DiagnosticBillManagenent.
--Then we drag the project.sql file from the main project folder
and drop it into the Sql Server Management Studio.
--Click the project.sql file and after open it into the Sql server management studio, we have to run it.
--Then all the data from the file project.sql will be copied into the database.
--After that we have to go to our main project file.
--There we have to open the DiagnosticBillManagementSystem.sln file in the visual studio.
--In that we have to open the Web.config file.
--In that we will get the connectionStrings tag.There we have to set the database name
and the server name.
--For database name under connectionStrings tag we will write add name=DiagnosticBillManagementConnectionString.
--For the server name we will give the name of our Sql server Name which we set at the time of connecting the database.
For example my server name is KAIS,so I write connectionString="Server=KAIS; Database=DiagnosticBillManagement.
--After that we will run the project in the Visual studio by clicking run with any browser.

