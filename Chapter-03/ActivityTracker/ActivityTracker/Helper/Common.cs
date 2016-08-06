using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
