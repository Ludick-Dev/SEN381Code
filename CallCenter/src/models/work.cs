using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models
{
    public class Work : IWork{
        public ObjectId workId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ObjectId technicianId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime workDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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