using MongoDB.Bson;

namespace CallCenter.Types
{
    interface IEmployee
    {
        ObjectId employeeId {get; set;}
        string employeeName {get; set;}
        Enum emplyeeDepartment {get; set;}
    }
}