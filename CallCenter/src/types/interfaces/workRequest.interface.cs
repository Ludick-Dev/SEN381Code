using MongoDB.Bson;

namespace CallCenter.Types
{
    interface IWorkRequest
    {
        ObjectId workId {get; set;}
        ObjectId technicianId {get; set;}
        Enum requestTypes {get; set;}
        string requestDetails {get; set;}
    }
}