using MongoDB.Bson;

namespace CallCenter.Types
{
    interface IWork{
        ObjectId workId {get; set;}
        ObjectId technicianId {get; set;}
        DateTime workDate {get; set;}

    }
}