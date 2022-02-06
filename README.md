# EmployeeDiscount
Apply Discount for the specified employee based on Type

# Employee Types
1) Permanent
2) Part-time
3) Interns
4) Contractors  

# The Problem
A Company is providing its employees with special discounts to use in shops when buying online. The company has the following 4 types of employees: Permanent, Part-time, Interns and Contractors.
We need a program that applies the correct discount to each employee: <br>
• Permanent employees get a 10% discount. They also get an extra 5% if they have been in the company for longer than 3 years.<br>
• Part-time employees get a 5% discount. They also get an extra 3% if they have been in the company for longer than 5 years.<br>
• Interns get a 5% discount but only on products with a price greater than £30.<br>
• Unfortunately, Contractors never get a discount.<br>

# Required version to build and execute the Employee Discount Repository
  .NET 6.0 version
  Visual Studio 2022 IDE

# Build and Run the Repository
Build any .NET Core project using the .NET Core CLI, which is installed with the [.NET Core SDK](https://dotnet.microsoft.com/download). Then run these commands from the CLI in the directory of this project:<br />

``dotnet build``<br />
``dotnet run``<br />

These will install any needed dependencies, build the project, and run the project respectively.  

**Other Options** - 
1) **Buid :** Open the Visual Studio(2022) IDE **Build**  Menu --> **Build solution**
2) **Run :** Open the Lative.Discounts.sln in Visual Studio(2022) IDE and make the Lative.Discounts.API as startup project and execute it or publish the API project in IIS and execute from there(Attached the screenshot below). 

**Publish :** Open the Visual Studio(2022) IDE **Build**  Menu --> **Publish Lative.Discounts** <br />
&nbsp;&nbsp;&nbsp;&nbsp;Select the path to publish it. Once it is publish to the path, This path can be link from IIS and run from there <br />

**Test Project Execution:** Open the Visual Studio(2022) IDE **Test**  Menu --> Run All Tests<br />
    Once it is executed, Test explorer will show the test results(Executed screenshot added below) 

**Added Published files in this Ropository to help for executing without build and run.

# ScreenShots

# Result
![image](https://user-images.githubusercontent.com/63959021/152695216-5b321830-32ce-410d-9d84-2514bd7ed92e.png)
![image](https://user-images.githubusercontent.com/63959021/152695176-85f91137-86cb-470c-ba53-23be98818a7a.png)

# Configured Employee Details
![image](https://user-images.githubusercontent.com/63959021/152695293-9ea44a54-ed46-488f-8889-ff77653837b7.png)




# Test Case Status
![image](https://user-images.githubusercontent.com/63959021/152695254-fa8bc763-9ace-4d06-bff8-fbaef6510eeb.png)



