using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models
{
    public class WorkRequest : IWorkRequest
    {
        public ObjectId workId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ObjectId technicianId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Enum requestTypes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string requestDetails { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}