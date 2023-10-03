using MongoDB.Bson;

namespace CallCenter.Types
{
    interface IContract
    {
        ObjectId contractId {get; set;}
        ObjectId clientId {get; set;}
        Enum contractTyoe {get; set;}
        string contractDetails {get; set;}
        int serviceLevel {get; set;}
        Enum contractStatus {get; set;}

    }
}