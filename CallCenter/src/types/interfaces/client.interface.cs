using CallCenter.Models;
using MongoDB.Bson;

namespace CallCenter.Types
{
    interface IClient
    {
        ObjectId clientId {get; set;}
        string clientName {get; set;}
        string phoneNumber {get; set;}
        ClientTypes cientType {get; set;}
        List<Contract> contracts {get; set;}
    }
}