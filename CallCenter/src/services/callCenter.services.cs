using CallCenter.Models;
using MongoDB.Bson;
using CallCenter.DataAccess;
using CallCenter.src.dataAccess;

namespace CallCenter.Services{
    public class CallCenterService
    {
        public CallCenterService()
        {

        }
        public static void AnswerCall()
        {
            throw new NotImplementedException();
        }

        public static Client ViewClientDetails(ObjectId clientId)
        {
            throw new NotImplementedException();
        }

        public static Contract ViewAgreements(ObjectId clientId)
        {
            throw new NotImplementedException();
        }

        public static CallReport ViewClientHistory(ObjectId clientId)
        {
            throw new NotImplementedException();
        }

        public static void LogRequest()
        {
            throw new NotImplementedException();
        }

        public static void SubmitRequest()
        {
            throw new NotImplementedException();
        }

        public static void AddCallToRequest()
        {
            throw new NotImplementedException();
        }
    }
}