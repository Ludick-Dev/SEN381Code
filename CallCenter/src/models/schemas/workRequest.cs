using CallCenter.Types;

namespace CallCenter.Models
{
    public class WorkRequest : IWorkRequest
    {
        public int requestID { get; set; }
        public int clientID { get; set; }
        public int serviceTypeID { get; set; }
        public int priorityID { get; set; }
        public string status { get; set; }
        public WorkRequest()
        {

        }

        public WorkRequest(int requestID, int clientID, int serviceTypeID, int priorityID, string status)
        {
            this.requestID = requestID;
            this.clientID = clientID;
            this.serviceTypeID = serviceTypeID;
            this.priorityID = priorityID;
            this.status = status;
        }
    }
}