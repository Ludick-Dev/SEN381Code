using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models
{
    public class WorkRequest : IWorkRequest
    {
        public List<Work> workId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public RequestTypes requestTypes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string requestDetails { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
        public WorkRequest()
        {
        }

        public WorkRequest(List<Work> workId, RequestTypes requestTypes, string requestDetails)
        {
            this.workId = workId;
            this.requestTypes = requestTypes;
            this.requestDetails = requestDetails;
        }
    }
}