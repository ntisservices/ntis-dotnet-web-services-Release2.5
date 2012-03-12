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
using Subscriber;
using log4net;
using System.Web.Services.Protocols;

namespace SubscriberWebService.Services
{
    public class AnprTrafficDataService : AbstractDatexService, IAnprTrafficDataService
    {
        #region IAnprTrafficDataService Members

        public DeliverANPRTrafficDataResponse GetDeliverAnprTrafficDataResponse(DeliverANPRTrafficDataRequest deliverANPRTrafficDataRequest)
        {
            log.Info("New DeliverANPRTrafficDataRequest received.");

            D2LogicalModel d2LogicalModel = deliverANPRTrafficDataRequest.D2LogicalModel;
            JourneyTimePublication journeyTimePublication = null;

            // Validate the D2Logical Model
            if (!ExampleDataCheckOk(d2LogicalModel))
            {
                throw new SoapException("Incoming reqest does not appear to be valid!", SoapException.ClientFaultCode);
            }

            // JourneyTimePublication contains on or more journey times.
            try
            {
                journeyTimePublication = (JourneyTimePublication) d2LogicalModel.payloadPublication;

                if (journeyTimePublication != null && journeyTimePublication.journeyTimes[0] != null)
                {
                    // You could use the JourneyTimePublication and extract the 
                    // corresponding fields.
                    log.Debug("JourneyTime: Timestampis " + journeyTimePublication.journeyTimes[0].timeStamp.ToString());
                }
            }
            catch (Exception e)
            {
                log.Debug("Error while obtaining JourneyTimePublication.");
                log.Error(e.Message);
                throw new SoapException("Error while obtaining JourneyTimePublication.", SoapException.ServerFaultCode, e);
            }

            DeliverANPRTrafficDataResponse response = new DeliverANPRTrafficDataResponse();
            response.status = "DeliverANPRTrafficDataResponse: Successful Delivery";

            return response;
        }

        #endregion
    }
}
