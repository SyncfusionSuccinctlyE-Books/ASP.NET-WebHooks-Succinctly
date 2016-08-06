using System;

namespace ActivityTracker.Helper
{
    public class Common
    {
        public static bool IsBitBucketReceiver(string receiver)
        {
            return ("BitBucket".Equals(receiver, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
