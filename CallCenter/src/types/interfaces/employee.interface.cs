
namespace CallCenter.Types
{
    interface IEmployee
    {
        Guid employeeId { get; set; }
        string employeeName { get; set; }
        string department { get; set; }
        bool availability { get; set; }
        string serviceArea { get; set; }
        string certificationLevel { get; set; }
        string emailAddress { get; set; }
        string phoneNumber { get; set; }
    }
}