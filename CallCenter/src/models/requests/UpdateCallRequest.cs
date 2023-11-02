namespace CallCenter.Models{
    public class UpdateCallToRequest{
        public Guid CallId {get; set;}
        public Guid? ClientId { get ; set ; }
        public DateTime EndTime {get; set;}
        public Guid? EmployeeId { get ; set ; }
        public Guid? WorkId {get; set;}
    }
}