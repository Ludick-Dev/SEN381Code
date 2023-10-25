using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models
{
    public class Contract : IContract
    {
        public ObjectId contractId { get ; set ; }
        public ObjectId clientId { get ; set ; }
        public ContractType contractType { get ; set ; }
        public string contractDetails { get ; set ; }
        public int serviceLevel { get ; set ; }
        public ContractStatus contractStatus { get ; set ; }
    
        public Contract()
        {
            
        }

        public Contract(ObjectId contractId, ObjectId clientId, ContractType contractType, string contractDetails, int serviceLevel, ContractStatus contractStatus)
        {
            this.contractId = contractId;
            this.clientId = clientId;
            this.contractType = contractType;
            this.contractDetails = contractDetails;
            this.serviceLevel = serviceLevel;
            this.contractStatus = contractStatus;
        }
    }
}