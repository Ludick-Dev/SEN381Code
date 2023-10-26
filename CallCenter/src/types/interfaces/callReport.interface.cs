using CallCenter.Models;

namespace CallCenter.Types{
    interface ICallReport
    {
        Guid workId {get; set;}
        List<Call> calls {get; set;}
    }
}