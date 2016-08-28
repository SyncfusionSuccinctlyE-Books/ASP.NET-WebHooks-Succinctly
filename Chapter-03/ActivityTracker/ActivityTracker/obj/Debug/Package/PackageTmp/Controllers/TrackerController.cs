using System.Collections.Generic;
using System.Web.Http;
using ActivityTracker.Models;
using ActivityTracker.Persistance;

namespace ActivityTracker.Controllers
{
    public class TrackerController : ApiController
    {
        private readonly IActivityRepository _activityRepository;

        public TrackerController()
        {
            _activityRepository = new ActivityRepository();
        }

        public TrackerController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }
        // GET api/<controller>
        public IEnumerable<ActivityModel> Get()
        {
            return _activityRepository.GetAll();
        }

        // GET api/<controller>/5
        public ActivityModel Get(int activityId)
        {
            return _activityRepository.GetBy(activityId);
        }

    }
}