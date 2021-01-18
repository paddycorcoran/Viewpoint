# Viewpoint
codeChallenge

Included is the project for Software QA Engineer - Code Challenge 2021 for Glass Lewis


On GitHub, navigate to the main page of the repository.
Above the list of files, click Code.
To clone the repository using HTTPS, under "Clone with HTTPS", click . ...
Open Terminal .
Change the current working directory to the location where you want the cloned directory.

The project uses the page Object model design pattern to isolate the Locators from the main code.
It also have the capability of running on the different browsers (Chrome,Firefox or IE)

In the file,Browsers.cs,change the browser type in the line :
private static string browser = "Chrome";
to FireFox to test with Firefox browser
and IE to test with Internet Explorer

The two stories are tested using Nunit Framework and is comprised of four class files
LandingPage.cs - Locators and methods
Pages.cs - Class to handle the page mapping
Browsers.cs - Browser set up and helper methods
UITests.cs - Browser setup/teardown and user story tests 
