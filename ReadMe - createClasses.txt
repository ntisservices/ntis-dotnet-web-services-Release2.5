wsdl /serverInterface /namespace:Subscriber /out:ISubscriber.cs C:\NTIS\SubscriberService\Contract\subscriber.wsdl 
rem C:\NTIS\SubscriberService\Contract\Datex2_TrafficDataServicePerformance.xsd C:\NTIS\SubscriberService\Contract\DATEXIISchema_2_2_0withdefinitions.xsd C:\NTIS\SubscriberService\Contract\request.xsd C:\NTIS\SubscriberService\Contract\response.xsd

pause

Instructions:

Change to directory containing WSDL and XSD's. E.g: C:\NTIS\SubscriberService\Contract

Type following command:

wsdl /serverInterface /namespace:Subscriber /out:ISubscriber.cs C:\NTIS\SubscriberService\Contract\subscriber.wsdl  C:\NTIS\SubscriberService\Contract\Datex2_TrafficDataServicePerformance.xsd  C:\NTIS\SubscriberService\Contract\DATEXIISchema_2_2_0withdefinitions.xsd C:\NTIS\SubscriberService\Contract\subscriber.xsd

This will produce the file ISubscriber.cs in the current directory which contains the interface and C# classes constructed from the datatypes in the WSDL's and XSDs.

------------------------------------------------------------------------
THE FOLLOWING WARNINGS WILL BE SEEN relating to the "tns" namespace being invalid in forming part of the data type. This can be ignored.

C:\NTIS\SubscriberService\Contract>wsdl /serverInterface /namespace:Subscriber /out:ISubscriber.cs C:\NTIS\SubscriberService\Contract\subscriber.wsdl  C:\NTIS\SubscriberService\Contract\Datex2_Traffic
DataServicePerformance.xsd C:\NTIS\SubscriberService\Contract\DATEXIISchema_2_2_0withdefinitions.xsd C:\NTIS\SubscriberService\Contract\subscriber.xsd
Microsoft (R) Web Services Description Language Utility
[Microsoft (R) .NET Framework, Version 2.0.50727.3038]
Copyright (C) Microsoft Corporation. All rights reserved.
Warning: This web reference does not conform to WS-I Basic Profile v1.1.
R2028, R2029: A DESCRIPTION using the WSDL namespace and the WSDL SOAP binding namespace MUST be valid according to the XML Schemas found at http://schemas.xmlsoap.org/wsdl/2003-02-11.xsd and http://schemas.xmlsoap.org/wsdl/soap/2003-02-11.xsd.
  -  Warning: The 'name' attribute is invalid - The value 'tns:DeliverDatex2Request' is invalid according to its datatype 'http://www.w3.org/2001/XMLSchema:NCName' - The ':' character, hexadecimal value 0x3A, cannot be included in a name. Line 21, position 14.
  -  Warning: The 'name' attribute is invalid - The value 'tns:DeliverDatex2Response' is invalid according to its datatype 'http://www.w3.org/2001/XMLSchema:NCName' - The ':' character, hexadecimal value 0x3A, cannot be included in a name. Line 24, position 14.

For more details on the WS-I Basic Profile v1.1, see the specification
at http://www.ws-i.org/Profiles/BasicProfile-1.1.html.

Writing file 'ISubscriber.cs'.

C:\NTIS\SubscriberService\Contract>

------------------------------------------------------------------------

or 31/01/2012
------------------------------------------------------------------------
Setting environment for using Microsoft Visual Studio 2008 x86 tools.

C:\Program Files\Microsoft Visual Studio 9.0\VC>cd C:\NTIS\SubscriberService

C:\NTIS\SubscriberService>wsdl /serverInterface /namespace:Subscriber /out:ISubscriber.cs C:\NTIS\SubscriberService\subscriber.wsdl C:\NTIS\SubscriberService\DATEXIIProcessedTrafficDataSchemaV0.01.xsd
 C:\NTIS\SubscriberService\DATEXIISchema_2_2_0withdefinitions.xsd C:\NTIS\SubscriberService\subscriber.xsd
Microsoft (R) Web Services Description Language Utility
[Microsoft (R) .NET Framework, Version 2.0.50727.3038]
Copyright (C) Microsoft Corporation. All rights reserved.
Writing file 'ISubscriber.cs'.

C:\NTIS\SubscriberService>
------------------------------------------------------------------------







BUILDING AND TESTING THE WEBSITE VISUAL STUDIO 2008 & WINDOWS XP
--------------------------------

Building
--------
In Visual Studio, You can build a .Net ASP.NET Web Service Application such as I have done, and run it from there. A web page should pop up with the URL, http://localhost:<portNumber>/SubscriberService.asmx, where <portNumber> can be auto-generated port number, or hard coded one.

If IIS has been installed, the following can be done:
1) After testing that the project works successully in Visual Project, within Visual Studio, right click on the web service website in Solution Explorer, and select "Publish".
2) In the "Publish Web" dialogue box that appears, enter a Target location. (e.g: C:\SubscriberWebSite), leave the default settings of "Replace matching files with local copies", "Only files needed to run this application", and leave "Include files from the App_Data folder" checked.

Deploying the webservice
------------------------
1) Start up "Internet Information Services", by going the "Control Panel", double clicking on "Administrative Tools", and double clicking on "Internet Information Services".
2) Expand "<machine name>local computer".
3) Expand "Web Sites".
4) Right click on "Default Web Site", and select "New", "Virtual Directory".
5) On the "Virtual Directory Creation Wizard" dialogue that appears, click "Next".
6) Enter an "Alias" (e.g. "SubscriberWebService" and click "Next".
7) Enter or browse to the directory containing the content (e.g. C:\SubscriberWebSite) and click "Next".
8) Leave the default settings checked for "Read" and "Run scripts (such as ASP)", and click "Next".
9) Click "Finish".
10) Open a browser window, and enter "http://localhost/SubscriberWebservice/SubscriberService.asmx" as the URL.
11) The "Subscriber Service" web page should appear.
12) Click on the "service description" link to check that the WSDL page appears.
14) Click on the browser back button, and click on the "DeliverDatex2" link to check that a sample page appears for sending "request" and "response" messages over different protocols.






