using CallCenter.Models;

namespace CallCenter.Types
{
    interface IClient
    {
        Guid clientId {get; set;}
        string clientName {get; set;}
        string phoneNumber {get; set;}
        ClientTypes clientType {get; set;}
        List<Contract> contracts {get; set;}
    }
}