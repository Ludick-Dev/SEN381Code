using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models{
    public class Call : ICall
    {
        public ObjectId callId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ObjectId clientId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime startTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime endTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ObjectId employeeId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ObjectId workId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
        public Call()
        {
        }

        public Call(ObjectId callId, ObjectId clientId, DateTime startTime, DateTime endTime, ObjectId employeeId, ObjectId workId)
        {
            this.callId = callId;
            this.clientId = clientId;
            this.startTime = startTime;
            this.endTime = endTime;
            this.employeeId = employeeId;
            this.workId = workId;
        }
    }
}