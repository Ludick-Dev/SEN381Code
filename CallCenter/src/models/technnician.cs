using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models
{
    public class Technician //: ITechnician
    {
        public int skillLevel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ObjectId employeeId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string employeeName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Department emplyeeDepartment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
        public Technician()
        {
        }
        
        public Technician(int skillLevel, ObjectId employeeId, string employeeName, Department employeeDepartment)
        {
            this.skillLevel = skillLevel;
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.emplyeeDepartment = emplyeeDepartment;
        }
    }
}