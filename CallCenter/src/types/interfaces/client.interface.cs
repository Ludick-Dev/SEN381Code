using System.Diagnostics.Contracts;
using MongoDB.Bson;

namespace CallCenter.Types
{
    interface IClient
    {
        ObjectId clientId {get; set;}
        string clientName {get; set;}
        string phoneNumber {get; set;}
        Enum cientType {get; set;}
        List<Contract>
    }
}