# CSharpClockSoftware

It is a Selenium C# Specflow BDD based test automation framework and the test scripts written for Clock Software site https://www.clock-software.com/demo-clockpms/index.html

It has following features:

-> Page object Model

-> Extent HTML Report with screenshot

-> BDD with Specflow

-> Screenshot for both pass and fail steps

-> CI/CD configurable

To run this project -> Build the project and run using Test Explorer (Test->Test Explorer)

You can also run in terminal using command ```dotnet test```

Sample Report:
<img src="https://github.com/ayosuva/CSharpClockSoftware/blob/main/ClockSoftware/Report.PNG">

# Jenkins Setup:

**Source Code Management:** Git : [https://github.com/ayosuva/SeleniumBDD](https://github.com/ayosuva/CSharpClockSoftware)

**Branches to build:** */main

**Build Triggers:** Poll SCM : * * * * *

**Build :** Execute Windows batch command : mvn -Dtest=Runner test

**E-mail Notification :** 
Manage Jenkins -> Configure System
smtp.gmail.com
Use SMTP Authentication
Use SSL
Port:465
