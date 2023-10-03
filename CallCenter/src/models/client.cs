using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models
{
    public class Client : IClient
    {
        public ObjectId clientId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string clientName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string phoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Enum cientType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}