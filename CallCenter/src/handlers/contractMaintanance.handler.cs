using CallCenter.Types;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Handlers{
    public class ContractMaintananceHandler{
        
        List<ContractType> contractTypes;
        ContractType selectedContractType;
        
        public ContractMaintananceHandler()
        {

        }

        public static IActionResult DefineService()
        {
            // Auth
            // checkPermision
            // validateQuery
            // call service
            
            throw new NotImplementedException();
        }

        public static IActionResult DefineServiceLevels()
        {
            throw new NotImplementedException();
        }

        public static IActionResult DefineContractType()
        {
            throw new NotImplementedException();
        }

        public static IActionResult GetContractAvailable()
        {
            throw new NotImplementedException();
        }

        public static IActionResult AddCallToRequest()
        {
            throw new NotImplementedException();
        }
    }
}