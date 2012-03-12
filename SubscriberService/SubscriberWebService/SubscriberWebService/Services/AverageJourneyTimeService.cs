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
using log4net;
using Subscriber;
using System.Web.Services.Protocols;

namespace SubscriberWebService.Services
{
    public class AverageJourneyTimeService : AbstractDatexService, IAverageJourneyTimeService
    {
        #region IAverageJourneyTimeService Members

        public DeliverAverageJourneyTimeResponse GetDeliverAverageJourneyTimeResponse(DeliverAverageJourneyTimeRequest deliverAverageJourneyTimeRequest)
        {
            log.Info("New DeliverAverageJourneyTimeRequest received.");

            D2LogicalModel d2LogicalModel = deliverAverageJourneyTimeRequest.D2LogicalModel;
            FusedDataPublication fusedDataPublication = null;

            // Validate D2LogicalModel
            if (!ExampleDataCheckOk(d2LogicalModel))
            {
                throw new SoapException("Incoming request does not appear to be valid!", SoapException.ClientFaultCode);
            }

            // FusedDataPublication contains teh journey time, direction, code, region, etc.
            try
            {
                fusedDataPublication = (FusedDataPublication)d2LogicalModel.payloadPublication;

                if (fusedDataPublication != null && fusedDataPublication.fusedData[0] != null)
                {
                    // You could use the FusedDataPublication and extract the corresponding fields.

                    log.Debug("createdUtc is " + fusedDataPublication.fusedData[0].createdUtc.ToString());
                    log.Debug("Local is " + fusedDataPublication.fusedData[0].markets[0].createdLocal.ToString());
                }

            }
            catch (Exception e)
            {
                log.Error("Error while obtaining FusedDataPublication.");
                log.Error(e.Message);
                throw new SoapException("Error while obtaining FusedDataPublication.", SoapException.ServerFaultCode, e);
            }

            DeliverAverageJourneyTimeResponse response = new DeliverAverageJourneyTimeResponse();
            response.status = "DeliverAverageJourneyTimeRequest: Successful Delivery";

            return response;
        }

        #endregion
    }
}
