using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models
{
    public class Work : IWork{
        public ObjectId workId { get ; set ; }
        public ObjectId technicianId { get ; set ; }
        public DateTime workDate { get ; set ; }

        public Work()
        {

        }

        public Work(ObjectId workId, ObjectId technicianId, DateTime workDate)
        {
            this.workId = workId;
            this.technicianId = technicianId;
            this.workDate = workDate;
        }
    }
}