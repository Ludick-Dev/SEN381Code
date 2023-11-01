using CallCenter.Types;

namespace CallCenter.Models
{
    public class RequestLog : IRequestLog
    {
        public Guid requestId { get; set; }
        public Guid clientId { get; set; }
        public string clientName { get; set; }
        public DateTime lastCallDate { get; set; }
        public double callDuration { get; set; } //in minutes
        public string technicianName { get; set; }
        public string priorityLevel { get; set; }
        public string status { get; set; }

        public RequestLog()
        {

        }

        public RequestLog(Guid clientId, string clientName, DateTime lastCallDate, int callDuration, Guid requestId, string technicianName, string priorityLevel, string status)
        {
            this.clientId = clientId;
            this.clientName = clientName;
            this.lastCallDate = lastCallDate;
            this.callDuration = callDuration;
            this.requestId = requestId;
            this.technicianName = technicianName;
            this.priorityLevel = priorityLevel;
            this.status = status;
        }
    }
}
