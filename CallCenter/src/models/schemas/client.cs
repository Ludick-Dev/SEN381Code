using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models
{
    public class Client : IClient
    {
        public ObjectId clientId { get ; set ; }
        public string clientName { get ; set ; }
        public string phoneNumber { get ; set ; }
        public ClientTypes clientType { get ; set ; }
        public List<Contract> contracts { get ; set ; }
    
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