using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models
{
    public class Contract : IContract
    {
        public ObjectId contractId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ObjectId clientId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ContractType contractType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string contractDetails { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int serviceLevel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ContractStatus contractStatus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
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