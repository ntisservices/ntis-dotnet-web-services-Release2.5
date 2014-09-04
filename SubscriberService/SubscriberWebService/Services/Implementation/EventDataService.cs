using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using System.Web.Services.Protocols;

namespace SubscriberWebService.Services
{

    public class EventDataService : AbstractDatexService, IEventDataService
    {

        #region IEventDataService Members

        public void Handle(D2LogicalModel deliverEventDataRequest)
        {

            log.Info("New EventData received.");

            // Validate the D2Logical Model
            if (!ExampleDataCheckOk(deliverEventDataRequest))
            {
                throw new SoapException("Incoming request does not appear to be valid!", SoapException.ClientFaultCode);
            }

            SituationPublication situationPublication = null;
            try
            {

                situationPublication = (SituationPublication)deliverEventDataRequest.payloadPublication;

                if (situationPublication != null)
                {

                    Situation[] situations = situationPublication.situation;

                    log.Info("Number of Events in payload: " + situations.Length);

                    foreach (Situation situation in situations)
                    {

                        // Only have 1 situationRecord per situation (index=0)
                        SituationRecord situationRecord = situation.situationRecord[0];

                        // Different types of event/situation record contain some common information and 
                        // some type-specific data items and should be handled accordingly
                        processCommonEventData(situationRecord);

                        if (situationRecord.GetType() == typeof(MaintenanceWorks))
                        {
                            processMaintenanceWorksEvent((MaintenanceWorks)situationRecord);
                        }

                    }

                    log.Info("EventData: processed successfully.");

                }

            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }

        }

        private void processCommonEventData(SituationRecord situationRecord)
        {
            log.Info("Event ID: " + situationRecord.id);
            log.Info("Severity: " + situationRecord.severity);
            log.Info("Current status: " + situationRecord.validity.validityStatus);
            log.Info("Overall start time: " + situationRecord.validity.validityTimeSpecification.overallStartTime);
            log.Info("Overall end time: " + situationRecord.validity.validityTimeSpecification.overallEndTime);
        }

        private void processMaintenanceWorksEvent(MaintenanceWorks maintenanceWorksEvent)
        {

            if (maintenanceWorksEvent.urgentRoadworks)
                log.Info("Urgent Roadworks!");

            RoadMaintenanceTypeEnum[] maintenanceTypes = maintenanceWorksEvent.roadMaintenanceType;
            foreach (RoadMaintenanceTypeEnum maintenanceType in maintenanceTypes)
            {
                log.Info("Type of maintenance involved: " + maintenanceType);
            }
            log.Info("Mobility: " + maintenanceWorksEvent.mobility.mobilityType);
            log.Info("Scale: " + maintenanceWorksEvent.roadworksScale);
            log.Info("Roadworks Scheme Name: " + maintenanceWorksEvent.maintenanceWorksExtension.roadworksEventDetails.roadworksSchemeName);

        }

        #endregion
    }
}
