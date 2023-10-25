using Microsoft.VisualBasic;

namespace CallCenter.Types
{
    public interface IrequestLog
    {
        public int clientId { get; set; }
        public string logName { get; set; }
        public DateAndTime lastCallDate { get; set; }
        public string callDuration { get; set; }
        public int requestId { get; set; }
        public string technicianName { get; set; }
        public string priorityLevel { get; set; }
        public string status { get; set; }

    }
}
