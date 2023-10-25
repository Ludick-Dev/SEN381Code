namespace CallCenter.Models
{
    public class requestLog
    {
        public int clientId { get; set; }
        public string clientName { get; set; }
        public DateTime lastCallDate { get; set; }
        public int callDuration { get; set; } //in minutes
        public int requestId { get; set; }
        public string technicianName { get; set; }
        public string priorityLevel { get; set; }
        public string status { get; set; }

        public requestLog()
        {

        }

        public requestLog(int clientId, string clientName, DateTime lastCallDate, int callDuration, int requestId, string technicianName, string priorityLevel, string status)
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
