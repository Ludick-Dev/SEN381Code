namespace CallCenter.Models
{
    public class AddWorkRequestRequest
    {
        public Guid clientId { get; set; }
        public string serviceType { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
    }
}