using CallCenter.Types;

namespace CallCenter.Models
{
    public class WorkRequest : IWorkRequest
    {
        public Guid requestID { get; set; }
        public Guid clientID { get; set; }
        public Guid serviceTypeID { get; set; }
        public Guid priorityID { get; set; }
        public string status { get; set; }
        public WorkRequest()
        {

        }

        public WorkRequest(Guid requestID, Guid clientID, Guid serviceTypeID, Guid priorityID, string status)
        {
            this.requestID = requestID;
            this.clientID = clientID;
            this.serviceTypeID = serviceTypeID;
            this.priorityID = priorityID;
            this.status = status;
        }
    }
}