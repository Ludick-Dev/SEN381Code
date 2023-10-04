using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models{
    public class CallReport : ICallReport
    {
        public ObjectId workId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Call> calls { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}