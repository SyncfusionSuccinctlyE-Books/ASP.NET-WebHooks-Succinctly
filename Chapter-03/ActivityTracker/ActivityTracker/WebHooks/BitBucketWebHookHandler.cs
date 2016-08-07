using ActivityTracker.Constants;
using ActivityTracker.Enums;
using ActivityTracker.Helper;
using ActivityTracker.Helpers;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityTracker.WebHooks
{
    public class BitBucketWebHookHandler : WebHookHandler
    {
        public override Task ExecuteAsync1(string receiver, WebHookHandlerContext context)
        {
            if (Common.IsBitBucketReceiver(receiver))
            {
                var dataJObject = context.GetDataOrDefault<JObject>();
                var action = context.Actions.First();
                var enumAction = EnumHelper.GetEnumValue<EnumRepository>(action, EnumProp.DisplayCode, false);
                switch (enumAction)
                {
                    case EnumRepository.push:
                        //do something
                        break;
                    case EnumRepository.fork:
                        //do something
                        break;
                    case EnumRepository.updated:
                        //do something
                        break;
                    case EnumRepository.commitcommentcreated:
                        //do something
                        break;
                    case EnumRepository.commitstatuscreated:
                        //do something
                        break;
                    case EnumRepository.commitstatusupdated:
                        //do something
                        break;

                    default:
                        var data = dataJObject.ToString();
                        break;
                }

            }

            return Task.FromResult(true);
        }



        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            if (Common.IsBitBucketReceiver(receiver))
            {
                var dataJObject = context.GetDataOrDefault<JObject>();
                var action = context.Actions.First();
                switch (action)
                {
                    case BitBucketRepoAction.Push:
                        //do something
                        break;
                    case BitBucketRepoAction.Fork:
                        //do something
                        break;
                    case BitBucketRepoAction.Updated:
                        //do something
                        break;
                    case BitBucketRepoAction.CommitCommentCreated:
                        //do something
                        break;
                    case BitBucketRepoAction.CommitStatusCreated:
                        //do something
                        break;
                    case BitBucketRepoAction.CommitStatusUpdated:
                        //do something
                        break;

                    default:
                        var data = dataJObject.ToString();
                        break;
                }
            }
            return Task.FromResult(true);
        }
    }
}
