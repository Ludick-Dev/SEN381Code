using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models{
    public class CallReport : ICallReport
    {
        public ObjectId workId { get ; set ; }
        public List<Call> calls { get ; set ; }
    
        public CallReport()
        {
        }

        public CallReport(ObjectId workId, List<Call> calls)
        {
            this.workId = workId;
            this.calls = calls;
        }
    }
}