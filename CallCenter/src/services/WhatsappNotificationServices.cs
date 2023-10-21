using CallCenter.src.types.interfaces;
using Twilio.Types;
using Twilio;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CallCenter.src.services
{
    //implements Whatsapp notification services using Twilio API
    public class WhatsappNotificationServices : INotificationStrategy
    {
        private readonly string accountSid = "ACc22a1cc2695739e39421d1ede151fcab";
        private readonly string authToken = "373279c2656dba5675335f744d52ee64";
        private readonly string twilioPhoneNumber = "+14155238886";

        public void Notify(string message, string recipientPhoneNumber)
        {
            TwilioClient.Init(accountSid, authToken);
            var messageResource = MessageResource.Create(
                body: message,
                from: new PhoneNumber($"whatsapp:{twilioPhoneNumber}"),
                to: new PhoneNumber($"whatsapp:{recipientPhoneNumber}")
            );
        }
    }
}
