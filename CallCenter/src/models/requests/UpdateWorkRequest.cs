namespace CallCenter.Models
{
    public class UpdateWorkRequest{
        public Guid workId { get ; set ; }
        public Guid? technicianId { get ; set ; }
        public DateTime? workDate { get ; set ; }
    }
}