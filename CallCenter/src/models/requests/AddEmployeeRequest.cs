using CallCenter.Types;

namespace CallCenter.Models
{
    public class AddEmployeeRequest
    {
        public string employeeName { get; set; }
        public Department department { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }
    }
}