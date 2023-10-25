using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models{
    public class Call : ICall
    {
        public ObjectId callId { get ; set ; }
        public ObjectId clientId { get ; set ; }
        public DateTime startTime { get ; set ; }
        public DateTime endTime { get ; set ; }
        public ObjectId employeeId { get ; set ; }
        public ObjectId workId { get ; set ; }
    
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