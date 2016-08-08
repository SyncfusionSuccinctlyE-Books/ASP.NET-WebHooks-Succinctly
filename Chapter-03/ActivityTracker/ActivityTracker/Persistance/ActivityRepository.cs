using System;
using System.Collections.Generic;
using System.Linq;
using ActivityTracker.Models;

namespace ActivityTracker.Persistance
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ActivityContext _activityContext;

        public ActivityRepository()
        {
            _activityContext = new ActivityContext();
        }

        public ActivityRepository(ActivityContext activityContext)
        {
            _activityContext = activityContext;
        }

        public void Dispose()
        {
            _activityContext?.Dispose();
        }

        public IEnumerable<ActivityModel> GetAll()
        {
            return _activityContext.ActivityTrackers.ToList();
        }

        public ActivityModel GetBy(int activityId)
        {
            return _activityContext.ActivityTrackers
                .FirstOrDefault(a => a.ActivityId == activityId); //activityId is unique
        }

        public ActivityModel Add(ActivityModel activityModel)
        {
            var activity = _activityContext.ActivityTrackers.Add(activityModel);
            try
            {
                _activityContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //log here and throw exception message
                throw new Exception(ex.Message);
            }

            return activity;
        }
    }
}