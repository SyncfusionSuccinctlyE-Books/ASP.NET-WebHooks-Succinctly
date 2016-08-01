using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BitBucketSampleReceiverApp.Controllers
{
    public class BitBucketNotificationController : ApiController
    {
        // GET: api/BitBucketNotification
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
    }
}
