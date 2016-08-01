using System.Linq;
using System.Threading.Tasks;
using BitBucketSampleReceiverApp.Constants;
using BitBucketSampleReceiverApp.Models;
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
            var pushModel = new PushModel();
            switch (action)
            {
                case "repo:push":
                    
                    pushModel.Repository = dataJObject["repository"].ToObject<BitbucketRepository>();
                    pushModel.User = dataJObject["actor"].ToObject<BitbucketUser>();
                    foreach (var change in dataJObject["push"]["changes"])
                    {
                        pushModel.Previous = change["old"]["target"].ToObject<BitbucketTarget>();

                        pushModel.Current = change["new"]["target"].ToObject<BitbucketTarget>();
                    }
                    break;

                default:
                    pushModel.RawData = dataJObject.ToString();
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