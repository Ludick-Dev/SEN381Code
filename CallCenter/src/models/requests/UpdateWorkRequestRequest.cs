namespace CallCenter.Models
{
    public class UpdateWorkRequestRequest
    {
        public Guid requestId { get; set; }
        public string? serviceType { get; set; }
        public string? priority { get; set; }
        public string? status { get; set; }
    }
}