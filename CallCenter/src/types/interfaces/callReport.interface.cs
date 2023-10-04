using CallCenter.Models;
using MongoDB.Bson;

namespace CallCenter.Types{
    interface ICallReport
    {
        ObjectId workId {get; set;}
        List<Call> calls {get; set;}
    }
}