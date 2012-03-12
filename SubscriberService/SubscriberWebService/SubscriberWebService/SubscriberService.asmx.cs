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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Subscriber;
using log4net;
using SubscriberWebService.Services;
using SoapMessageUtility;

namespace SubscriberWebService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://thalesgroup.com/NTIS/Subscriber")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SubscriberService : System.Web.Services.WebService, ISubscriberSoap11
    {       
        protected static readonly ILog log = LogManager.GetLogger(typeof(SubscriberService));
        

        #region ISubscriberSoap11 Members
        [WebMethod]
        [TraceExtension]
        public DeliverAverageSpeedFvdResponse DeliverAverageSpeedFvd(DeliverAverageSpeedFvdRequest DeliverAverageSpeedFvdRequest)
        {
            AverageSpeedFvdService averageSpeedFvdService = new AverageSpeedFvdService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver average speed FVD request received");
            DeliverAverageSpeedFvdResponse response = averageSpeedFvdService.GetDeliverAverageSpeedFvdResponse(DeliverAverageSpeedFvdRequest);

            return response;
        }

        [WebMethod]
        [TraceExtension]
        public DeliverMIDASTrafficDataResponse DeliverMIDASTrafficData(DeliverMIDASTrafficDataRequest DeliverMIDASTrafficDataRequest)
        {
            MidasTrafficDataService midasTrafficDataService = new MidasTrafficDataService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver MIDAS traffic data request received");
            DeliverMIDASTrafficDataResponse response = midasTrafficDataService.GetDeliverMidasTrafficDataResponse(DeliverMIDASTrafficDataRequest);
           
            return response;
        }

        [WebMethod]
        [TraceExtension]
        public DeliverANPRTrafficDataResponse DeliverANPRTrafficData(DeliverANPRTrafficDataRequest DeliverANPRTrafficDataRequest)
        {
            AnprTrafficDataService anprTrafficDataService = new AnprTrafficDataService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver ANPR traffic data request received");
            DeliverANPRTrafficDataResponse response = anprTrafficDataService.GetDeliverAnprTrafficDataResponse(DeliverANPRTrafficDataRequest);
            
            return response;
        }

        [WebMethod]
        [TraceExtension]
        public DeliverAverageSpeedFusedDataResponse DeliverAverageSpeedFusedData(DeliverAverageSpeedFusedDataRequest DeliverAverageSpeedFusedDataRequest)
        {
            AverageSpeedFusedDataService averageSpeedFusedDataService = new AverageSpeedFusedDataService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver average speed fused data request received");
            DeliverAverageSpeedFusedDataResponse response = averageSpeedFusedDataService.GetDeliverAverageSpeedFusedDataResponse(DeliverAverageSpeedFusedDataRequest);
            
            return response;
        }

        [WebMethod]
        [TraceExtension]
        public DeliverAverageJourneyTimeResponse DeliverAverageJourneyTime(DeliverAverageJourneyTimeRequest DeliverAverageJourneyTimeRequest)
        {
            AverageJourneyTimeService averageJourneyTimeService = new AverageJourneyTimeService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver average journey time request received");
            DeliverAverageJourneyTimeResponse response = averageJourneyTimeService.GetDeliverAverageJourneyTimeResponse(DeliverAverageJourneyTimeRequest);            
            
            return response;
        }

        #endregion
    }
}
