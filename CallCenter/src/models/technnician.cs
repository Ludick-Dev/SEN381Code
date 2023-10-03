using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models
{
    public class Technician : ITechnician
    {
        public int skillLevel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ObjectId employeeId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string employeeName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Enum emplyeeDepartment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}