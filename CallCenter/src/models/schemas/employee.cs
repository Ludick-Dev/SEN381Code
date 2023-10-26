using CallCenter.Types;

namespace CallCenter.Models
{
    public class Employee : IEmployee
    {
       public Guid employeeId { get; set; }
       public  string employeeName { get; set; }
        public string department { get; set; }
       public  bool availability { get; set; }
        public string serviceArea { get; set; }
        public string certificationLevel { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }

        public Employee()
        {

        }
        public Employee(Guid employeeID, string employeeName, string department, bool availability, string serviceArea, string certificationLevel, string emailAddress, string phoneNumber)
        {
            this.employeeId = employeeID;
            this.employeeName = employeeName;
            this.department = department;
            this.availability = availability;
            this.serviceArea = serviceArea;
            this.certificationLevel = certificationLevel;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
        }
    }
}