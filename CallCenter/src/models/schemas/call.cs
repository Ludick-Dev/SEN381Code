using CallCenter.Types;

namespace CallCenter.Models{
    public class Call : ICall
    {
        public Guid callId { get ; set ; }
        public Guid clientId { get ; set ; }
        public DateTime startTime { get ; set ; }
        public DateTime endTime { get ; set ; }
        public Guid employeeId { get ; set ; }
        public Guid workId { get ; set ; }
    
        public Call()
        {
        }

        public Call(Guid callId, Guid clientId, DateTime startTime, DateTime endTime, Guid employeeId, Guid workId)
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