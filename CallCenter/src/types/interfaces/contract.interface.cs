using MongoDB.Bson;

namespace CallCenter.Types
{
    interface IContract
    {
        ObjectId contractId {get; set;}
        ObjectId clientId {get; set;}
        ContractType contractType {get; set;}
        string contractDetails {get; set;}
        int serviceLevel {get; set;}
        ContractStatus contractStatus {get; set;}

    }
}