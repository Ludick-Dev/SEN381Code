namespace CallCenter.Models
{
    public class AddWorkRequest{
        public Guid technicianId { get ; set ; }
        public DateTime workDate { get ; set ; }
    }
}