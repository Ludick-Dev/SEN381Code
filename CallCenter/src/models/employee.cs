using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models
{
    public class Employee : IEmployee
    {
        public ObjectId employeeId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string employeeName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Department emplyeeDepartment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
        public Employee()
        {
        }

        public Employee(ObjectId employeeId, string employeeName, Department employeeDepartment)
        {
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.emplyeeDepartment = emplyeeDepartment;
        }
    }
}