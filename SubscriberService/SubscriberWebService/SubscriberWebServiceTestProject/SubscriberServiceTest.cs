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

using SubscriberWebService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Subscriber;
using SubscriberWebService.Services;
using System.Web.Services.Protocols;

namespace SubscriberWebServiceTestProject
{
    
    
    /// <summary>
    ///This is a test class for SubscriberServiceTest and is intended
    ///to contain all SubscriberServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SubscriberServiceTest
    {        
        private TestContext testContextInstance;
        private static D2LogicalModel model;
        private static Exchange exchange;
        private static InternationalIdentifier supplierIdentification;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{        
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            // Define message data
            model = new D2LogicalModel();
            model.modelBaseVersion = "2";
            exchange = new Exchange();
            supplierIdentification = new InternationalIdentifier();
            exchange.supplierIdentification = supplierIdentification;
            model.exchange = exchange;
            model.exchange.supplierIdentification.country = CountryEnum.gb;
            model.exchange.supplierIdentification.nationalIdentifier = "gb";
        }
        
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        
        /// <summary>
        ///A test for GetDeliverMidasTrafficDataResponse
        ///</summary>
        [TestMethod()]
        public void CheckValidGetDeliverMidasTrafficDataResponseTest()
        {
            IMidasTrafficDataService midasTrafficDataService = new MidasTrafficDataService();
            DeliverMIDASTrafficDataRequest deliverMIDASTrafficDataRequest = new DeliverMIDASTrafficDataRequest();
            deliverMIDASTrafficDataRequest.D2LogicalModel = model;
            string expected = "DeliverMIDASTrafficDataRequest: Successful Delivery";
            string actual;
            actual = (midasTrafficDataService.GetDeliverMidasTrafficDataResponse(deliverMIDASTrafficDataRequest)).status;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test to check that a SoapException is thrown for a null D2LogicalModel object
        /// on GetDeliverMidasTrafficDataResponse().
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SoapException))]
        public void CheckErrorInGetDeliverMidasTrafficDataResponseTest()
        {
            IMidasTrafficDataService midasTrafficDataService = new MidasTrafficDataService();
            DeliverMIDASTrafficDataRequest deliverMIDASTrafficDataRequest = new DeliverMIDASTrafficDataRequest();

            model = null; // This will be checked by ExampleDataCheckOk(d2LogicalModel)

            deliverMIDASTrafficDataRequest.D2LogicalModel = model;
            string expected = "DeliverMIDASTrafficDataRequest: Successful Delivery";
            string actual;
            // This should cause a SoapException
            actual = (midasTrafficDataService.GetDeliverMidasTrafficDataResponse(deliverMIDASTrafficDataRequest)).status;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetDeliverAverageSpeedFvdResponse()
        ///</summary>
        [TestMethod()]
        public void CheckValidGetDeliverAverageSpeedFvdResponseTest()
        {
            IAverageSpeedFvdService averageSpeedFvdService = new AverageSpeedFvdService();
            DeliverAverageSpeedFvdRequest deliverAverageSpeedFvdRequest = new DeliverAverageSpeedFvdRequest();
            deliverAverageSpeedFvdRequest.D2LogicalModel = model;
            string expected = "DeliverAverageSpeedFvdRequest: Successful Delivery";
            string actual;
            actual = (averageSpeedFvdService.GetDeliverAverageSpeedFvdResponse(deliverAverageSpeedFvdRequest)).status;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test to check that a SoapException is thrown for a null D2LogicalModel object
        /// on DeliverAverageSpeedFvd.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SoapException))]
        public void CheckErrorInGetDeliverAverageSpeedFvdResponseTest()
        {
            IAverageSpeedFvdService averageSpeedFvdService = new AverageSpeedFvdService();
            DeliverAverageSpeedFvdRequest deliverAverageSpeedFvdRequest = new DeliverAverageSpeedFvdRequest();

            model = null; // This will be checked by ExampleDataCheckOk(d2LogicalModel)

            deliverAverageSpeedFvdRequest.D2LogicalModel = model;
            string expected = "DeliverAverageSpeedFvdRequest: Successful Delivery";
            string actual;
            // This should cause a SoapException
            actual = (averageSpeedFvdService.GetDeliverAverageSpeedFvdResponse(deliverAverageSpeedFvdRequest)).status;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetDeliverAverageSpeedFusedDataResponse()
        ///</summary>
        [TestMethod()]
        public void CheckValidGetDeliverAverageSpeedFusedDataResponseTest()
        {
            IAverageSpeedFusedDataService averageSpeedFusedData = new AverageSpeedFusedDataService();
            DeliverAverageSpeedFusedDataRequest deliverAverageSpeedFusedDataRequest = new DeliverAverageSpeedFusedDataRequest();
            deliverAverageSpeedFusedDataRequest.D2LogicalModel = model;
            string expected = "DeliverAverageSpeedFusedDataRequest: Successful Delivery";
            string actual;
            actual = (averageSpeedFusedData.GetDeliverAverageSpeedFusedDataResponse(deliverAverageSpeedFusedDataRequest)).status;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test to check that a SoapException is thrown for a null D2LogicalModel object
        /// on GetDeliverAverageSpeedFusedDataResponse().
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(SoapException))]
        public void CheckErrorInGetDeliverAverageSpeedFusedDataResponseTest()
        {
            IAverageSpeedFusedDataService averageSpeedFusedData = new AverageSpeedFusedDataService();
            DeliverAverageSpeedFusedDataRequest deliverAverageSpeedFusedDataRequest = new DeliverAverageSpeedFusedDataRequest();

            model = null; // This will be checked by ExampleDataCheckOk(d2LogicalModel)

            deliverAverageSpeedFusedDataRequest.D2LogicalModel = model;
            string expected = "DeliverAverageSpeedFusedDataRequest: Successful Delivery";
            string actual;
            // This should cause a SoapException
            actual = (averageSpeedFusedData.GetDeliverAverageSpeedFusedDataResponse(deliverAverageSpeedFusedDataRequest)).status;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetDeliverAverageJourneyTimeResponse()
        ///</summary>
        [TestMethod()]
        public void CheckValidGetDeliverAverageJourneyTimeResponseTest()
        {
            IAverageJourneyTimeService averageJourneyTimeService = new AverageJourneyTimeService();
            DeliverAverageJourneyTimeRequest deliverAverageJourneyTimeRequest = new DeliverAverageJourneyTimeRequest();
            deliverAverageJourneyTimeRequest.D2LogicalModel = model;
            string expected = "DeliverAverageJourneyTimeRequest: Successful Delivery";
            string actual;
            actual = (averageJourneyTimeService.GetDeliverAverageJourneyTimeResponse(deliverAverageJourneyTimeRequest)).status;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test to check that a SoapException is thrown for a null D2LogicalModel object
        /// on GetDeliverAverageJourneyTimeResponse().
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(SoapException))]
        public void CheckErrorInGetDeliverAverageJourneyTimeResponseTest()
        {
            IAverageJourneyTimeService averageJourneyTimeService = new AverageJourneyTimeService();
            DeliverAverageJourneyTimeRequest deliverAverageJourneyTimeRequest = new DeliverAverageJourneyTimeRequest();

            model = null; // This will be checked by ExampleDataCheckOk(d2LogicalModel)

            deliverAverageJourneyTimeRequest.D2LogicalModel = model;
            string expected = "DeliverAverageJourneyTimeRequest: Successful Delivery";
            string actual;
            // This should cause a SoapException
            actual = (averageJourneyTimeService.GetDeliverAverageJourneyTimeResponse(deliverAverageJourneyTimeRequest)).status;

            Assert.AreEqual(expected, actual);
        }
        

        /// <summary>
        ///A test for GetDeliverAnprTrafficDataResponse()
        ///</summary> 
        [TestMethod()]
        public void CheckValidGetDeliverAnprTrafficDataResponseTest()
        {
            IAnprTrafficDataService anprTrafficDataService = new AnprTrafficDataService();
            DeliverANPRTrafficDataRequest deliverANPRTrafficDataRequest = new DeliverANPRTrafficDataRequest();
            deliverANPRTrafficDataRequest.D2LogicalModel = model;
            string expected = "DeliverANPRTrafficDataResponse: Successful Delivery";
            string actual;
            actual = (anprTrafficDataService.GetDeliverAnprTrafficDataResponse(deliverANPRTrafficDataRequest)).status;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test to check that a SoapException is thrown for a null D2LogicalModel object
        /// on GetDeliverAnprTrafficDataResponse().
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(SoapException))]
        public void CheckErrorInDeliverANPRTrafficDataTest()
        {
            IAnprTrafficDataService anprTrafficDataService = new AnprTrafficDataService();
            DeliverANPRTrafficDataRequest deliverANPRTrafficDataRequest = new DeliverANPRTrafficDataRequest();

            model = null; // This will be checked by ExampleDataCheckOk(d2LogicalModel)

            deliverANPRTrafficDataRequest.D2LogicalModel = model;
            string expected = "DeliverANPRTrafficDataResponse: Successful Delivery";
            string actual;
            // This should cause a SoapException
            actual = (anprTrafficDataService.GetDeliverAnprTrafficDataResponse(deliverANPRTrafficDataRequest)).status;

            Assert.AreEqual(expected, actual);
        }
    }
}
