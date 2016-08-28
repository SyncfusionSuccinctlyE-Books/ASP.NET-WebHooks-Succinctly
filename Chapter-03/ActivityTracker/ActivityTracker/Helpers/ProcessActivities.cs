using ActivityTracker.Enums;
using ActivityTracker.Models;
using ActivityTracker.Persistance;
using Newtonsoft.Json.Linq;

namespace ActivityTracker.Helpers
{
    //ToDo - this class required lot of refactoring
    public class ProcessActivities
    {
        private string _action;
        private JObject _dataJObject;
        private readonly ActivityRepository _activityRepository;
        public ProcessActivities(JObject dataObject, string action )
        {
            _dataJObject = dataObject;
            _action = action;
            _activityRepository = new ActivityRepository();
        }
        public void Process()
        {
            var firstPart = _action.Split(':');
            if (firstPart[0].ToLower() == "repository")
                ProcessRepository();
            else if (firstPart[0].ToLower() == "pullrequest")
                ProcessPullRequest();
            else if (firstPart[0].ToLower() == "issue")
                ProcessIssue();
            else
                throw new System.Exception("UnIdentified action!");
        }

        private void ProcessRepository()
        {
            var enumAction = EnumHelper.GetEnumValue<EnumRepository>(_action, EnumProp.DisplayCode, false);
            switch (enumAction)
            {
                case EnumRepository.Push:
                    var activityModel = new ActivityModel
                    {
                        Activity = "Repository",
                        Action = EnumHelper.GetEnumDisplayName(EnumRepository.Push, EnumProp.DisplayCode),
                        Description = EnumHelper.GetEnumDisplayName(EnumRepository.Push,
                            EnumProp.DisplayName),
                        Data = _dataJObject.ToString()
                    };
                    _activityRepository.Add(activityModel);
                    break;
                case EnumRepository.Fork:
                    var activityModelFork = new ActivityModel
                    {
                        Activity = "Repository",
                        Action = EnumHelper.GetEnumDisplayName(EnumRepository.Fork, EnumProp.DisplayCode),
                        Description = EnumHelper.GetEnumDisplayName(EnumRepository.Fork, EnumProp.DisplayName),
                        Data = _dataJObject.ToString()
                    };
                    _activityRepository.Add(activityModelFork);
                    break;
                case EnumRepository.Updated:
                    var activityModelUpdated = new ActivityModel
                    {
                        Activity = "Repository",
                        Action = EnumHelper.GetEnumDisplayName(EnumRepository.Updated, EnumProp.DisplayCode),
                        Description = EnumHelper.GetEnumDisplayName(EnumRepository.Updated, EnumProp.DisplayName),
                        Data = _dataJObject.ToString()
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
                        Data = _dataJObject.ToString()
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
                        Data = _dataJObject.ToString()
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
                        Data = _dataJObject.ToString()
                    };
                    _activityRepository.Add(activityModelCommitStatusUpdated);
                    break;

                default:
                    var activityModelUknown = new ActivityModel
                    {
                        Activity = "Repository",
                        Action = _action,
                        Description = "Uknown action",
                        Data = _dataJObject.ToString()
                    };
                    _activityRepository.Add(activityModelUknown);
                    break;
            }
        }

        private void ProcessPullRequest()
        {
            var enumAction = EnumHelper.GetEnumValue<EnumPullRequest>(_action, EnumProp.DisplayCode, false);
            switch (enumAction)
            {
                case EnumPullRequest.created:
                    var activityModel = new ActivityModel
                    {
                        Activity = "PullRequest",
                        Action = EnumHelper.GetEnumDisplayName(EnumPullRequest.created, EnumProp.DisplayCode),
                        Description = EnumHelper.GetEnumDisplayName(EnumPullRequest.created, EnumProp.DisplayName),
                        Data = _dataJObject.ToString()
                    };
                    _activityRepository.Add(activityModel);
                    break;
                case EnumPullRequest.updated:
                    var activityModelFork = new ActivityModel
                    {
                        Activity = "PullRequest",
                        Action = EnumHelper.GetEnumDisplayName(EnumPullRequest.updated, EnumProp.DisplayCode),
                        Description = EnumHelper.GetEnumDisplayName(EnumPullRequest.updated, EnumProp.DisplayName),
                        Data = _dataJObject.ToString()
                    };
                    _activityRepository.Add(activityModelFork);
                    break;
                case EnumPullRequest.approved:
                    var activityModelUpdated = new ActivityModel
                    {
                        Activity = "PullRequest",
                        Action = EnumHelper.GetEnumDisplayName(EnumPullRequest.approved, EnumProp.DisplayCode),
                        Description = EnumHelper.GetEnumDisplayName(EnumPullRequest.approved, EnumProp.DisplayName),
                        Data = _dataJObject.ToString()
                    };
                    _activityRepository.Add(activityModelUpdated);
                    break;
                case EnumPullRequest.approvalremoved:
                    var activityModelCommit = new ActivityModel
                    {
                        Activity = "PullRequest",
                        Action =
                            EnumHelper.GetEnumDisplayName(EnumPullRequest.approvalremoved, EnumProp.DisplayCode),
                        Description =
                            EnumHelper.GetEnumDisplayName(EnumPullRequest.approvalremoved, EnumProp.DisplayName),
                        Data = _dataJObject.ToString()
                    };
                    _activityRepository.Add(activityModelCommit);
                    break;
                case EnumPullRequest.merged:
                    var activityModelCommitStatus = new ActivityModel
                    {
                        Activity = "PullRequest",
                        Action =
                            EnumHelper.GetEnumDisplayName(EnumPullRequest.merged, EnumProp.DisplayCode),
                        Description =
                            EnumHelper.GetEnumDisplayName(EnumPullRequest.merged, EnumProp.DisplayName),
                        Data = _dataJObject.ToString()
                    };
                    _activityRepository.Add(activityModelCommitStatus);
                    break;
                case EnumPullRequest.declined:
                    var activityModelCommitStatusUpdated = new ActivityModel
                    {
                        Activity = "PullRequest",
                        Action =
                            EnumHelper.GetEnumDisplayName(EnumPullRequest.declined, EnumProp.DisplayCode),
                        Description =
                            EnumHelper.GetEnumDisplayName(EnumPullRequest.declined, EnumProp.DisplayName),
                        Data = _dataJObject.ToString()
                    };
                    _activityRepository.Add(activityModelCommitStatusUpdated);
                    break;
                case EnumPullRequest.commentcreated:
                    var activityModelcommentcreated = new ActivityModel
                    {
                        Activity = "PullRequest",
                        Action =
                            EnumHelper.GetEnumDisplayName(EnumPullRequest.commentcreated, EnumProp.DisplayCode),
                        Description =
                            EnumHelper.GetEnumDisplayName(EnumPullRequest.commentcreated, EnumProp.DisplayName),
                        Data = _dataJObject.ToString()
                    };
                    _activityRepository.Add(activityModelcommentcreated);
                    break;
                case EnumPullRequest.commentupdated:
                    var activityModelcommentupdated = new ActivityModel
                    {
                        Activity = "PullRequest",
                        Action =
                            EnumHelper.GetEnumDisplayName(EnumPullRequest.commentupdated, EnumProp.DisplayCode),
                        Description =
                            EnumHelper.GetEnumDisplayName(EnumPullRequest.commentupdated, EnumProp.DisplayName),
                        Data = _dataJObject.ToString()
                    };
                    _activityRepository.Add(activityModelcommentupdated);
                    break;
                case EnumPullRequest.commentdeleted
:
                    var activityModelcommentdeleted = new ActivityModel
                    {
                        Activity = "PullRequest",
                        Action =
                            EnumHelper.GetEnumDisplayName(EnumPullRequest.commentdeleted, EnumProp.DisplayCode),
                        Description =
                            EnumHelper.GetEnumDisplayName(EnumPullRequest.commentdeleted, EnumProp.DisplayName),
                        Data = _dataJObject.ToString()
                    };
                    _activityRepository.Add(activityModelcommentdeleted);
                    break;

                default:
                    var activityModelUknown = new ActivityModel
                    {
                        Activity = "PullRequest",
                        Action = _action,
                        Description = "Uknown action",
                        Data = _dataJObject.ToString()
                    };
                    _activityRepository.Add(activityModelUknown);
                    break;
            }
        }

        private void ProcessIssue()
        {
            var enumAction = EnumHelper.GetEnumValue<EnumIssue>(_action, EnumProp.DisplayCode, false);
            var activity   = "Issue";
            switch (enumAction)
            {
                case EnumIssue.created:
                  var activityModel = PopulateActivityModel(activity, EnumHelper.GetEnumDisplayName(EnumIssue.created, EnumProp.DisplayCode), 
                      EnumHelper.GetEnumDisplayName(EnumIssue.created, EnumProp.DisplayName), _dataJObject.ToString());
                    _activityRepository.Add(activityModel);
                    break;
                case EnumIssue.updated:
                  var activityModelUpdated = PopulateActivityModel(activity, EnumHelper.GetEnumDisplayName(EnumIssue.updated, EnumProp.DisplayCode),
                      EnumHelper.GetEnumDisplayName(EnumIssue.updated, EnumProp.DisplayName), _dataJObject.ToString());
                    _activityRepository.Add(activityModelUpdated);
                    break;
                case EnumIssue.commentcreated:
                    var activityModelcommentcreated = PopulateActivityModel(activity, EnumHelper.GetEnumDisplayName(EnumIssue.commentcreated, EnumProp.DisplayCode),
                      EnumHelper.GetEnumDisplayName(EnumIssue.commentcreated, EnumProp.DisplayName), _dataJObject.ToString());
                    _activityRepository.Add(activityModelcommentcreated);
                    
                    break;
               
                default:
                   var activityModelUknown = PopulateActivityModel(activity, _action,"Unknown action", _dataJObject.ToString());
                    _activityRepository.Add(activityModelUknown);
                    break;
            }
        }

        private ActivityModel PopulateActivityModel(string activity, string action, string description,string data)
        {
            var activityModel = new ActivityModel
            {
                Activity = activity,
                Action = action,
                Description = description,
                Data = data
            };
            return activityModel;
        }
    }
}