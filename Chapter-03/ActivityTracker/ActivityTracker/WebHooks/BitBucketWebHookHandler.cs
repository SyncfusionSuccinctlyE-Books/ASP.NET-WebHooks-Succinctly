using ActivityTracker.Helper;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTracker.WebHooks
{
    public class BitBucketWebHookHandler : WebHookHandler
    {
        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            if (Common.IsBitBucketReceiver(receiver))
            {
                var dataJObject = context.GetDataOrDefault<JObject>();
                var action = context.Actions.First();
            }

            return Task.FromResult(true);
        }
    }
}
