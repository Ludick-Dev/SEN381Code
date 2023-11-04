namespace CallCenter.Models
{
    public class UpdateCallReportRequest
    {
        public Guid callReportId {get; set;}
        public List<Call> calls { get; set; }
    }
}