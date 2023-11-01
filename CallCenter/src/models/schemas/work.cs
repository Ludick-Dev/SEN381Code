using CallCenter.Types;

namespace CallCenter.Models
{
    public class Work : IWork{
        public Guid workId { get ; set ; }
        public Guid technicianId { get ; set ; }
        public DateTime workDate { get ; set ; }

        public Work()
        {

        }

        public Work(Guid workId, Guid technicianId, DateTime workDate)
        {
            this.workId = workId;
            this.technicianId = technicianId;
            this.workDate = workDate;
        }
    }
}