// Copyright (C) 2011 Thales Transportation Systems UK 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy,modify, merge, publish, distribute, sublicense, and/or sell 
// copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software. 
//    
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
// THE SOFTWARE.

using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Net;
using System.Configuration;
using System.Threading;
using System.Xml;
using System.Text;

namespace SoapMessageUtility
{
    // Define a SOAP Extension that traces the SOAP request and SOAP
    // response for the XML Web service method the SOAP extension is
    // applied to.
    public class TraceExtension : SoapExtension
    {
        Stream oldStream;
        Stream newStream;
        private static bool traceSoap = ConfigurationManager.AppSettings.Get("traceSOAP").Equals("true");
        private static string traceDirectory = ConfigurationManager.AppSettings.Get("traceDirectory");

        // Save the Stream representing the SOAP request or SOAP response into
        // a local memory buffer.
        public override Stream ChainStream(Stream stream)
        {
            if (traceSoap)
            {
                oldStream = stream;
                newStream = new MemoryStream();
                return newStream;
            }
            else
            {
                return stream;
            }
        }

        // When the SOAP extension is accessed for the first time, the XML Web
        // service method it is applied to is accessed to store the file
        // name passed in, using the corresponding SoapExtensionAttribute.    
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            return null;
        }

        
        public override object GetInitializer(Type WebServiceType)
        {
            return null;
        }
                
        public override void Initialize(object initializer)
        {
        }

        //  If the SoapMessageStage is such that the SoapRequest or
        //  SoapResponse is still in the SOAP format to be sent or received,
        //  save it out to a file.
        public override void ProcessMessage(SoapMessage message)
        {
            switch (message.Stage)
            {
                case SoapMessageStage.BeforeSerialize:
                    break;
                case SoapMessageStage.AfterSerialize:
                    if (traceSoap)
                    {
                        WriteOutput(message);
                    }
                    break;
                case SoapMessageStage.BeforeDeserialize:
                    if (traceSoap)
                    {
                        WriteInput(message);
                    }
                    break;
                case SoapMessageStage.AfterDeserialize:
                    break;
                default:
                    throw new Exception("invalid stage");
            }
        }

        public void WriteOutput(SoapMessage message)
        {
            FileStream fs;
            StreamWriter w = null;
            newStream.Position = 0;
            Thread currentThread = Thread.CurrentThread;
            int threadID = currentThread.GetHashCode();
            
            try
            {                   
                fs = new FileStream(traceDirectory + "Response." + threadID + "-" + DateTime.Now.ToString("HHmmssfffff") + ".xml",
                     FileMode.Append, FileAccess.Write);
                w = new StreamWriter(fs);

                string soapString = "SoapResponse";
                w.WriteLine("-----" + soapString + " at " + DateTime.Now);
                w.Flush();
                Copy(newStream, fs);
                w.Close();
               
            }
            catch (Exception ex)
            {
                // Don't really care about exceptions as this is for debug logging only.
            }
            finally
            {
                if (w != null)
                {
                    w.Close();
                }
                newStream.Position = 0;
                Copy(newStream, oldStream);
            }
        }

        public void WriteInput(SoapMessage message)
        {
            Thread currentThread = Thread.CurrentThread;
            int threadID = currentThread.GetHashCode();
            FileStream fs;
            StreamWriter w = null; 

            try
            {
                if (!Directory.Exists(traceDirectory))
                {
                    Directory.CreateDirectory(traceDirectory);
                }

                Copy(oldStream, newStream);
                fs = new FileStream(traceDirectory + "Request." + threadID + "-" + DateTime.Now.ToString("HHmmssfffff") + ".xml",
                     FileMode.Append, FileAccess.Write);
                w = new StreamWriter(fs);
                string soapString = "SoapRequest";
                w.WriteLine("-----" + soapString + " at " + DateTime.Now);
                w.Flush();
                newStream.Position = 0;
                Copy(newStream, fs);              
            }
            catch (Exception ex)
            {
                // Don't really care about exceptions as this is for debug logging only.
            }
            finally
            {
                if (w != null)
                {
                    w.Close();
                }
                newStream.Position = 0;
            }
        }

        void Copy(Stream from, Stream to)
        {
            TextReader reader = new StreamReader(from);
            TextWriter writer = new StreamWriter(to);
            writer.WriteLine(reader.ReadToEnd());
            writer.Flush();
        }
            
    }
}
