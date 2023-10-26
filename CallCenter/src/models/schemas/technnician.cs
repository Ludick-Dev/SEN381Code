using CallCenter.Types;

namespace CallCenter.Models
{
    public class Technician //: ITechnician
    {
        public int skillLevel { get ; set ; }
        public Guid employeeId { get ; set ; }
        public string employeeName { get ; set ; }
        public Department emplyeeDepartment { get ; set ; }
    
        public Technician()
        {
        }
        
        public Technician(int skillLevel, Guid employeeId, string employeeName, Department employeeDepartment)
        {
            this.skillLevel = skillLevel;
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.emplyeeDepartment = emplyeeDepartment;
        }
    }
}