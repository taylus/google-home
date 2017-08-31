using System;
using System.Web.Http;

namespace GoogleAssistantWebApi
{
    public class HelloController : ApiController
    {
        [HttpGet, HttpPost, Route("")]
        public object Main([FromBody] dynamic request)
        {
            string intent = GetIntentFromRequest(request);
            switch (intent)
            {
                case "WebHookHello": return SayHello();
                case "WebHookDiagnostics": return SayDiagnostics();
                default: return SayUnknownIntent();
            }
        }

        private string GetIntentFromRequest(dynamic request)
        {
            return request?.result?.metadata?.intentName;
        }

        private object SayHello()
        {
            return new { speech = "Royal's web service says hello!" };
        }

        private object SayDiagnostics()
        {
            return new { speech = $"This app is communicating with a web service over HTTPS which is running on a server named {Environment.MachineName}." };
            //TODO: SSML and stuff?
        }

        private object SayUnknownIntent()
        {
            return new { speech = "I didn't get that, could you rephrase and try again?" };
        }
    }
}