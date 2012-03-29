Creating a Client In Microsoft Visual Studio 2008
=================================================

Visual Studio languages access the API through objects that serve as proxies for their server-side counterparts. Before using the API, you must first generate these objects from the WSDL file(s).

Visual Studio provides two approaches for importing your WSDL file and generating an XML Web service client: an IDE-based approach and a command line approach.
An XML Web service client is any component or application that references and uses an XML Web service. This does not necessarily need to be a client-based application. In fact, in many cases, your XML Web service clients might be other Web applications, such as Web Forms or even other XML Web services. When accessing XML Web services in managed code, a proxy class and the .NET Framework handle all of the infrastructure coding.

To access an XML Web service from managed code:
-----------------------------------------------
1. Add a Web reference to your project for the XML Web service that you want to access. The Web reference creates a proxy class with methods that serve as proxies for each exposed method of the XML Web service.
2. Add the namespace for the Web reference. 
3. Create an instance of the proxy class and then access the methods of that class as you would the methods of any other class.

To Add a Service Reference:
---------------------------
On the Project menu, choose Add Service Reference.
1.	In the Address field, enter the URL of the web service or the full path and filename of the WSDL file. E.g: http://www.thales.com/SubscriberWebsite/SubscriberService.asmx, or C:\NTIS\subscriber.wsdl.
2.	In the Namespace field type a suitable name. E.g: SubscriberServiceReference.
3.	Click on the Ok button.

The service data types, and methods will now be available as .NET classes and data types.
To build a Windows console or forms client you will need to create an instance of the client class produced from the above process. The client class will have a name such as “subscriberSoap11Client”. This is simply the port name when the WSDL is viewed, with "Client" appended to it.
