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
    public class MidasTrafficDataService: AbstractDatexService, IMidasTrafficDataService
    {        
        private static int MaxSensorReadings = 7;


        #region IMidasTrafficDataService Members

        public DeliverMIDASTrafficDataResponse GetDeliverMidasTrafficDataResponse(DeliverMIDASTrafficDataRequest deliverMIDASTrafficDataRequest)
        {
            log.Info("New DeliverMIDASTrafficDataRequest received.");
            D2LogicalModel d2LogicalModel = deliverMIDASTrafficDataRequest.D2LogicalModel;
            MeasuredDataPublication measuredDataPublication = null;
            DeliverMIDASTrafficDataResponse response = new DeliverMIDASTrafficDataResponse();

            // Validate the D2Logical Model
            if (!ExampleDataCheckOk(d2LogicalModel))
            {
                throw new SoapException("Incoming request does not appear to be valid!", SoapException.ClientFaultCode);
            }
            
            // MeasuredDataPublication class contains the feed description, feed
            // type, site measurements, publication time and other header information.
            try
            {
                measuredDataPublication = d2LogicalModel.payloadPublication as MeasuredDataPublication;

                if (measuredDataPublication != null && measuredDataPublication.headerInformation != null)
                {

                    // Eash MIDAS site is encapsulated within a SiteMeasurements object.
                    // Cycle through these to get to the sensor readings for a MIDAS site.
                    foreach (SiteMeasurements siteMeasurement in measuredDataPublication.siteMeasurements)
                    {
                        log.Debug("measurementDataPublication ID is " + siteMeasurement.measurementSiteReference.id);
                        log.Debug("measurementDataPublication time default is " + siteMeasurement.measurementTimeDefault.ToString());

                        // Cycle through the MeasuredValues to get the individual sensor readings for a MIDAS site.
                        foreach (_SiteMeasurementsIndexMeasuredValue singleMeasuredValue in siteMeasurement.measuredValue)
                        {
                            int index = singleMeasuredValue.index;

                            // Each sensor reading has an index. This represents the lane number the sensor reading is for.
                            // On retrieving the index, you can use getLaneNumberFromTrafficDataIndex to get the lane number.
                            int laneNumber = GetLaneNumberFromTrafficDataIndex(index);
                            log.Debug("lane number is " + laneNumber);

                            // To determine what type the sensore reading is, cast the basic data value to the appropriate
                            // type and retrieve the value of interest.
                            MeasuredValue mv = singleMeasuredValue.measuredValue;
                            BasicData basicData = mv.basicData;

                            if (basicData is TrafficFlow)
                            {
                                // For a lane, TrafficFlow will appear 4 times. i.e.
                                // flow1, flow2 ... flow4. It will appear in order.
                            }
                            else if (basicData is TrafficSpeed)
                            {
                                // Now you have TrafficSpeed. Cast it appropriately
                                // to retrieve values you are interested in.
                            }
                            else if (basicData is TrafficHeadway)
                            {
                                // Now you have TrafficHeadway. Cast it appropriately
                                // to retrieve values you are interested in.
                            }
                            else if (basicData is TrafficConcentration)
                            {
                                // Now you have TrafficConcentration. Cast it 
                                // appropriately to retrieve values you are
                                // interested in.
                            }

                        }
                    }

                    // You can convert the site measurements to you model objects
                    // and subsequently persist/manipulate your model objects.
                    List<TrafficData> trafficData = ConvertToModelObjects(measuredDataPublication.siteMeasurements.ToList());
                }
            }
            catch (Exception e)
            {
                log.Error("Error while obtaining MeasuredDataPublication.");
                log.Error(e.Message);
                throw new SoapException("Error while obtaining MeasuredDataPublication.", SoapException.ServerFaultCode, e);
            }
                        
            response.status = "DeliverMIDASTrafficDataRequest: Successful Delivery";

            return response;
        }

        public int GetLaneNumberFromTrafficDataIndex(int measuredValueIndex)
        {
            if (measuredValueIndex == 0)
            {
                return 1;
            }
            return (measuredValueIndex / MaxSensorReadings) + 1;
        }

        /// <summary>
        /// This method demonstrates how to extract SiteMeasurement from the 
        /// incoming requests and convert it into a list of your own model classes.
        /// </summary>
        /// <param name="siteMeasurements"></param>
        /// <returns></returns>
        public List<TrafficData> ConvertToModelObjects(List<SiteMeasurements> siteMeasurements)
        {
            log.Debug("Cycling through the list of site measurements");
            log.Debug("Number of site measurements returned: " + siteMeasurements.Count);

            List<TrafficData> trafficDataList = new List<TrafficData>();

            foreach (SiteMeasurements measurement in siteMeasurements)
            {
                TrafficData trafficDatum = new TrafficData();

                // This is how you can extract the Site Reference ID and set it
                // your own domain class.
                trafficDatum.Guid = measurement.measurementSiteReference.id;

                // You could calculate the lane and set it on your model object.
                // For examaple, trafficDatum.LaneNumber = 0;
                //
                // Convert the basic data to either a TrafficFlow,
                // TrafficConcentration, TrafficSpeed, or TrafficHeadway object
                // and extract the values as below.
                //
                // TrafficSpeed trafficSpeed = measurement.measuredValue[0].measuredValue.basicData;
                trafficDataList.Add(trafficDatum);
            }
            return trafficDataList;
        }
        #endregion
    }
}
