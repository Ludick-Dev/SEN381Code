using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models
{
    public class Client : IClient
    {
        public ObjectId clientId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string clientName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string phoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ClientTypes clientType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Contract> contracts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
        public Client()
        {
        }

        public Client(ObjectId clientId, string clientName, string phoneNumber, ClientTypes clientType, List<Contract> contracts)
        {
            this.clientId = clientId;
            this.clientName = clientName;
            this.phoneNumber = phoneNumber;
            this.clientType = clientType;
            this.contracts = contracts;
        }
    }
}