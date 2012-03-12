using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using TestClient.SubscriberServiceReference;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SubscriberServiceReference.DeliverANPRTrafficDataRequest request = new SubscriberServiceReference.DeliverANPRTrafficDataRequest();
            SubscriberServiceReference.D2LogicalModel model = new SubscriberServiceReference.D2LogicalModel();

            //request.D2LogicalModel = new TestClient.SubscriberServiceReference.D2LogicalModel();
            
            model.modelBaseVersion = "2";
            model.exchange = new SubscriberServiceReference.Exchange();
            model.exchange.supplierIdentification = new SubscriberServiceReference.InternationalIdentifier();
            model.exchange.supplierIdentification.country = SubscriberServiceReference.CountryEnum.gb;
            model.exchange.supplierIdentification.nationalIdentifier = "gb";

            request.D2LogicalModel = model;
            
            subscriberSoap11Client client = new TestClient.SubscriberServiceReference.subscriberSoap11Client();
            DeliverANPRTrafficDataResponse response = new TestClient.SubscriberServiceReference.DeliverANPRTrafficDataResponse();

            // call service and get response;
            try
            {
                response = client.DeliverANPRTrafficData(request);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                Console.ReadLine();
            }
            

            Console.WriteLine(response.status);
            Console.ReadLine();
        }
    }
}
