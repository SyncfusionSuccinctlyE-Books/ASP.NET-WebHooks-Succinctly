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
                        var activityModelFork = new ActivityModel
                        {
                            Activity = "Repository",
                            Action = EnumHelper.GetEnumDisplayName(EnumRepository.Fork, EnumProp.DisplayCode),
                            Description = EnumHelper.GetEnumDisplayName(EnumRepository.Fork, EnumProp.DisplayName),
                            Data = dataJObject.ToString()
                        };
                        _activityRepository.Add(activityModelFork);
                        break;
                    case EnumRepository.Updated:
                        var activityModelUpdated = new ActivityModel
                        {
                            Activity = "Repository",
                            Action = EnumHelper.GetEnumDisplayName(EnumRepository.Updated, EnumProp.DisplayCode),
                            Description = EnumHelper.GetEnumDisplayName(EnumRepository.Updated, EnumProp.DisplayName),
                            Data = dataJObject.ToString()
                        };
                        _activityRepository.Add(activityModelUpdated);
                        break;
                    case EnumRepository.Commitcommentcreated:
                        var activityModelCommit = new ActivityModel
                        {
                            Activity = "Repository",
                            Action =
                                EnumHelper.GetEnumDisplayName(EnumRepository.Commitcommentcreated, EnumProp.DisplayCode),
                            Description =
                                EnumHelper.GetEnumDisplayName(EnumRepository.Commitcommentcreated, EnumProp.DisplayName),
                            Data = dataJObject.ToString()
                        };
                        _activityRepository.Add(activityModelCommit);
                        break;
                    case EnumRepository.Commitstatuscreated:
                        var activityModelCommitStatus = new ActivityModel
                        {
                            Activity = "Repository",
                            Action =
                                EnumHelper.GetEnumDisplayName(EnumRepository.Commitstatuscreated, EnumProp.DisplayCode),
                            Description =
                                EnumHelper.GetEnumDisplayName(EnumRepository.Commitstatuscreated, EnumProp.DisplayName),
                            Data = dataJObject.ToString()
                        };
                        _activityRepository.Add(activityModelCommitStatus);
                        break;
                    case EnumRepository.Commitstatusupdated:
                        var activityModelCommitStatusUpdated = new ActivityModel
                        {
                            Activity = "Repository",
                            Action =
                                EnumHelper.GetEnumDisplayName(EnumRepository.Commitstatusupdated, EnumProp.DisplayCode),
                            Description =
                                EnumHelper.GetEnumDisplayName(EnumRepository.Commitstatusupdated, EnumProp.DisplayName),
                            Data = dataJObject.ToString()
                        };
                        _activityRepository.Add(activityModelCommitStatusUpdated);
                        break;

                    default:
                        var activityModelUknown = new ActivityModel
                        {
                            Activity = "Uknown",
                            Action = action,
                            Description = "Uknown action",
                            Data = dataJObject.ToString()
                        };
                        _activityRepository.Add(activityModelUknown);
                        break;
                }
            }

            return Task.FromResult(true);
        }
    }
}