using CallCenter.Models;
using MongoDB.Bson;

namespace CallCenter.Types
{
    interface ICall{
        ObjectId callId {get; set;}
        ObjectId clientId {get; set;}
        DateTime startTime {get; set;}
        DateTime endTime {get; set;}
        ObjectId employeeId {get; set;}
        ObjectId workId{get; set;}
    }
}