using CallCenter.Types;
using MongoDB.Bson;

namespace CallCenter.Models
{
    public class Contract : IContract
    {
        public ObjectId contractId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ObjectId clientId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ContractType contractTyoe { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string contractDetails { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int serviceLevel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ContractStatus contractStatus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
        public Contract()
        {
            
        }
    }
}