using System.Diagnostics;

namespace CarRentSystemManagement.GlobalClass
{
    public class clsEventLogEntry
    {
        public enum enEventLogEntry { enInformation=1,enWarnning=2,enError=3}
        public enEventLogEntry _EventLog=enEventLogEntry.enInformation;
        public static void SaveEventToEventLogEntry(string Description,enEventLogEntry eventLogEntry=enEventLogEntry.enError)
        {
            string AppName = "CarRentalSystmeManagementSystem";
            if (!EventLog.SourceExists(AppName))
            {
                EventLog.CreateEventSource(AppName,"Application");
            }
            switch (eventLogEntry)
            {
                case enEventLogEntry.enInformation:
                    EventLog.WriteEntry(AppName, Description, EventLogEntryType.Information);
                    break;
                case enEventLogEntry.enWarnning:
                    EventLog.WriteEntry(AppName, Description, EventLogEntryType.Warning);
                    break;
                default:
                    EventLog.WriteEntry(AppName, Description, EventLogEntryType.Error);
                    break;
            }
        }
    }
}
