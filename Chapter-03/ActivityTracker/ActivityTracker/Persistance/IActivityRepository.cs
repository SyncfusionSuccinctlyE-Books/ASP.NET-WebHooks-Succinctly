using System;
using System.Collections.Generic;
using ActivityTracker.Models;

namespace ActivityTracker.Persistance
{
    public interface IActivityRepository : IDisposable
    {
        ActivityModel Add(ActivityModel activityModel);
        IEnumerable<ActivityModel> GetAll();
        ActivityModel GetBy(int activityId);
    }
}