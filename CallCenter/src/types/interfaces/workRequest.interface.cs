using CallCenter.Models;
using MongoDB.Bson;

namespace CallCenter.Types
{
    interface IWorkRequest
    {
        List<Work> workId {get; set;}
        RequestTypes requestTypes {get; set;}
        string requestDetails {get; set;}
    }
}