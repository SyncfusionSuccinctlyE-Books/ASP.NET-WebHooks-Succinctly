using ActivityTracker.Helper;
using Microsoft.AspNet.WebHooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTracker.WebHooks
{
    public class BitBucketWebHookHandler : WebHookHandler
    {
        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            if (Common.IsBitBucketReceiver(receiver))
            {

            }

            return Task.FromResult(true);
        }
    }
}
