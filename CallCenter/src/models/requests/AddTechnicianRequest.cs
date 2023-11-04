namespace CallCenter.Models
{
    public class AddTechnicianRequest
    {
        public Guid employeeId {get; set;}
        public int skillLevel {get; set;}
        public bool availability { get; set; }
        public string serviceArea { get; set; }
        public string certificationLevel { get; set; }
    }
}