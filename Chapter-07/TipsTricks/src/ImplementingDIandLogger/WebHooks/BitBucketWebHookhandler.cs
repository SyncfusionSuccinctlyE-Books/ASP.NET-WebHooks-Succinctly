using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;

namespace ImplementingDIandLogger.WebHooks
{
    public class BitBucketWebHookhandler : WebHookHandler
    {
        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            var dataJObject = context.GetDataOrDefault<JObject>();
            var action = context.Actions.FirstOrDefault();

            //other stuff goes here

            return Task.FromResult(true);
        }
    }
}