NTIS Subscriber Web Service
===========================

This project is an example implementation of the NTIS Subscriber Service that uses the .NET 3.5 framework and the C# language.
You can import the project into Visual Studio 2008 (which is what is was created in), and tailor it to your needs. The solution can also be imported into Visual Studio 2010, during which you will be prompted by instructions which will state that it will be converted to use the .NET 4.0 framework.

The SubscriberWebService web site in the solution, is of the type "ASP.NET Web Service".


Contract First / WSDL First ASMX Development
--------------------------------------------
In this project, we were supplied with a set of XSDs (XML Schema Definitions) and given descriptions of operatons, input parameter types, and output (response types) which were to be exposed. From these and the XSDs, the "subscriber.wsdl", and "subscriber.xsd" were crafted manually. The WSDL contains the operations to be exposed. All XSDs and the WSDL (Web Services Description Language) documents, can be found in the "Contract" folder within the .NET solution.

With these files to hand, the wsdl.exe tool, which comes bundled with Visual Studio, can be used to generate the ASMX service interface, which can then be implemented to expose the web methods. The tool is engaged from the Visual Studio DOS command prompt.

The following shows how I generated the "ISubscriber.cs", ASMX service interface file:

	wsdl /serverInterface /namespace:Subscriber /out:ISubscriber.cs subscriber.wsdl subscriber.xsd Datex2_JourneyTimeExtensions_2.xsd DATEXIIProcessedTrafficDataSchemaV0.01.xsd DATEXIISchema_2_2_0withdefinitions.xsd


Note that the "ISubscriber.cs" file contains the web service interface which needs to be implemented, and .NET classes derived from the XSD and WSDL data types.

Next, I created the SubscriberWebService web site of type "ASP.NET Web Service" in Visual Studio 2008, imported the interface file, and implemented the methods.


BUILDING AND TESTING THE WEBSITE VISUAL STUDIO 2008 & WINDOWS XP
----------------------------------------------------------------

Building
--------
In Visual Studio 2008, You can build a ASP.NET Web Service Application such as I have done, and run it from there. A web page should pop up with the URL, http://localhost:<portNumber>/SubscriberService.asmx, where <portNumber> can be auto-generated port number, or hard coded.

If IIS has been installed, the following can be done:
1) After testing that the project works successully in Visual Project, within Visual Studio, right click on the web service website in Solution Explorer, and select "Publish".
2) In the "Publish Web" dialogue box that appears, enter a Target location. (e.g: C:\SubscriberWebSite), leave the default settings of "Replace matching files with local copies", "Only files needed to run this application", and leave "Include files from the App_Data folder" checked.

Deploying the webservice on IIS 5
---------------------------------
This project was first deployed on IIS 5. The instructions are as follows:

1) Start up "Internet Information Services", by going to the "Control Panel", double clicking on "Administrative Tools", and double clicking on "Internet Information Services".
2) Expand "<machine name>local computer".
3) Expand "Web Sites".
4) Right click on "Default Web Site", and select "New", "Virtual Directory".
5) On the "Virtual Directory Creation Wizard" dialogue that appears, click "Next".
6) Enter an "Alias" (e.g. "SubscriberWebService" and click "Next".
7) Enter or browse to the directory containing the published content (e.g. C:\SubscriberWebSite) and click "Next".
8) Leave the default settings checked for "Read" and "Run scripts (such as ASP)", and click "Next".
9) Click "Finish".
10) Open a browser window, and enter "http://localhost/SubscriberWebservice/Contract/subscriber.wsdl" as the URL. Note that the Microsoft generated WSDL has been disabled in this project in favour of the real one.
11) The "Subscriber Service" web page should appear.
12) Click on the "service description" link to see the .NET generated WSDL page.
14) Click on the browser back button, and click on any of the operations to see the formats and data types of the request and response over different protocols.


Deploying on Windows 7 using IIS 7
----------------------------------
Deploying the website for use by IIS 7 on a Windows 7 machine depends on the type of Windows 7 installation that you have. Microsoft may have certain configuration files locked down. If you have a home edition of Windows 7, IIS 7 may not have been installed by default. In this case, you need to go to the Control Panel, click on "Programs and Features", then "Turn Windows features on or off", and install it via the check boxes under "Internet Information Services".

With IIS 7 running, the web site should then be added as an application with the Application Pool set as "DefaultAppPool". Depending on your Windows 7 setup, you may have to set path credentials for a specific user.


Deploying on Windows Server 2008
--------------------------------
I am not familiar with this platform and suggest that you refer to Microsoft's documentation.


Example Requests
----------------
These can be found in the "exampleRequests" folder. These can be used to form requests for testing your own client that you build. For our testing we used "soapUI" which is a free tool by SmartBear Software (www.soapui.org), for sending web service requests, and viewing responses.


Testing Using SoapUI
--------------------
SoapUI is a free and open source cross-platform tool which can be used for testing SOAP requests and responses. The version used for testing this example was V4.0.1. Because of its simple interface, it was used as a client for testing this Subscriber web service.

1) Make sure that the Subscriber web service is running.
2) Start soapUI.
3) From the main menu select File -> New soapUI Project.
4) Enter a Project Name, browse to the WSDL or manually enter the location. e.g. http://SubscriberWebSite/SubscriberService.asmx?wsdl, then press "OK".
5) The service and methods will then be exposed.
6) Modify any of the requests and enter suitable values, or copy any of the example messages provided in the "exampleRequests" folder, which match the message to be tested, and paste over the contents of the "Request 1" sample generated.
7) Press the green play arrow at the top of the request and check that a success response is sent.
8) The message requests and responses will be logged in "C:\temp\logs\SOAP". Additionally, if a DeliverANPRTrafficData request was sent, it will be processed by a sample implementation of the AnprTrafficDataService class, and logged in "C:\temp\subscriberservice.log".

Note, that soapUI can also be used to test gzip compressed messages and responses, by selecting "Preferences" from the File menu and selecting "gzip" from the "Request compression" option, and checking/unchecking the "Disable Response Decompression" option.

Note that the "deflate" compression option is not catered for in this implementation.
