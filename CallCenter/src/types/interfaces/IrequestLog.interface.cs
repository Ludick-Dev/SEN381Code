using Microsoft.VisualBasic;

namespace CallCenter.Types
{
    public interface IrequestLog
    {
        public Guid clientId { get; set; }
        public string logName { get; set; }
        public DateAndTime lastCallDate { get; set; }
        public string callDuration { get; set; }
        public Guid requestId { get; set; }
        public string technicianName { get; set; }
        public string priorityLevel { get; set; }
        public string status { get; set; }

    }
}
