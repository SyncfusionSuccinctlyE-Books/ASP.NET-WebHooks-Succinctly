using System.Data.Entity;
using ActivityTracker.Models;

namespace ActivityTracker.Persistance
{
    public class ActivityContext : DbContext
    {
        public ActivityContext() : base("name=ActivityDBConnectionString")
        {
            
        }
        public DbSet<ActivityModel> ActivityTrackers { get; set; }
    }
}