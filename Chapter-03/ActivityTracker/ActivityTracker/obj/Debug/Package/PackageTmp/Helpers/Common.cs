using ActivityTracker.Enums;
using System;

namespace ActivityTracker.Helper
{
    public class Common
    {
        public static bool IsBitBucketReceiver(string receiver)
        {
            return ("BitBucket".Equals(receiver, StringComparison.InvariantCultureIgnoreCase));
        }

        //ToDo - refactoring required
        public static object GetEnum(string action)
        {
            var firstPart = action.Split(':');
            if (firstPart[0].ToLower() == "repository")
                return typeof(EnumRepository);
            if (firstPart[0].ToLower() == "issue")
                return typeof(EnumIssue);
            if (firstPart[0].ToLower() == "pullrequest")
                return typeof(EnumPullRequest);
            return typeof(EnumRepository);
        }
    }
}
