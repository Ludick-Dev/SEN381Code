using CallCenter.Types;

namespace CallCenter.Models{
    public class CallReport : ICallReport
    {
        public Guid workId { get ; set ; }
        public List<Call> calls { get ; set ; }
    
        public CallReport()
        {
        }

        public CallReport(Guid workId, List<Call> calls)
        {
            this.workId = workId;
            this.calls = calls;
        }
    }
}