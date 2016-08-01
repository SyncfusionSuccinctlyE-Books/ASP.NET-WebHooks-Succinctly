using System.Linq;
using System.Threading.Tasks;
using BitBucketSampleReceiverApp.Constants;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;

namespace BitBucketSampleReceiverApp.WebHooks
{
    public class BitBucketWebHookhandler : WebHookHandler
    {
        public BitBucketWebHookhandler()
        {
            Receiver = BitbucketWebHookReceiver.ReceiverName;
        }

        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            var dataJObject = context.GetDataOrDefault<JObject>();
            var action = context.Actions.First();
            switch (action)
            {
                case BitBucketRepoAction.Push:
                    var repository = dataJObject["repository"].ToObject<BitbucketRepository>();
                    var actor = dataJObject["actor"].ToObject<BitbucketUser>();
                    AssessChanges(dataJObject);
                    break;

                default:
                    var data = dataJObject.ToString();
                    break;
            }
            return Task.FromResult(true);
        }

        private static void AssessChanges(JObject dataJObject)
        {
            foreach (var change in dataJObject["push"]["changes"])
            {
                var previousValue = change["old"]["target"].ToObject<BitbucketTarget>();

                var newValue = change["new"]["target"].ToObject<BitbucketTarget>();
            }
        }
    }
}