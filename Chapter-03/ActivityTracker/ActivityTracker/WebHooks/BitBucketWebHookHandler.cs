using System.Linq;
using System.Threading.Tasks;
using ActivityTracker.Enums;
using ActivityTracker.Helper;
using ActivityTracker.Helpers;
using ActivityTracker.Models;
using ActivityTracker.Persistance;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;

namespace ActivityTracker.WebHooks
{
    public class BitBucketWebHookHandler : WebHookHandler
    {
        private readonly ActivityRepository _activityRepository;

        public BitBucketWebHookHandler()
        {
            _activityRepository = new ActivityRepository();
        }

        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            if (Common.IsBitBucketReceiver(receiver))
            {
                var dataJObject = context.GetDataOrDefault<JObject>();
                var action = context.Actions.First();
                var enumAction = EnumHelper.GetEnumValue<EnumRepository>(action, EnumProp.DisplayCode, false);
                switch (enumAction)
                {
                    case EnumRepository.Push:
                        var activityModel = new ActivityModel
                        {
                            Activity = "Repository",
                            Action = EnumHelper.GetEnumDisplayName(EnumRepository.Push, EnumProp.DisplayCode),
                            Description = EnumHelper.GetEnumDisplayName(EnumRepository.Push,
                                EnumProp.DisplayName),
                            Data = dataJObject.ToString()
                        };
                        _activityRepository.Add(activityModel);
                        break;
                    case EnumRepository.Fork:
                        //do something
                        break;
                    case EnumRepository.Updated:
                        //do something
                        break;
                    case EnumRepository.Commitcommentcreated:
                        //do something
                        break;
                    case EnumRepository.Commitstatuscreated:
                        //do something
                        break;
                    case EnumRepository.Commitstatusupdated:
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