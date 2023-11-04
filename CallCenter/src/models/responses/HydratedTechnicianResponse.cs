namespace CallCenter.Models
{
    public class HydratedTechnicianResponse
    {
        public Guid technicianId {get; set;}
        public string employeeName {get; set;}
        public string phoneNumber {get; set;}
        public string email{get; set;}
        public int skillLevel {get; set;}
        public bool availability { get; set; }
        public string serviceArea { get; set; }
        public string certificationLevel { get; set; }
    }
}