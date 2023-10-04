using CallCenter.Types;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Handlers
{
    public class ClientMaintananceHandler
    {
        List<ContractType> contractTypes;

        public ClientMaintananceHandler()
        {

        }

        public static IActionResult AddClient()
        {
            // Auth
            // checkPermision
            // validateQuery
            // call service

            throw new NotImplementedException();
        }
        public static IActionResult AddBusinessClient()
        {
            throw new NotImplementedException();
        }
        public static IActionResult AddServiceAgreement()
        {
            throw new NotImplementedException();
        }
        public static IActionResult ViewContractHistory()
        {
            throw new NotImplementedException();
        }
    }
}