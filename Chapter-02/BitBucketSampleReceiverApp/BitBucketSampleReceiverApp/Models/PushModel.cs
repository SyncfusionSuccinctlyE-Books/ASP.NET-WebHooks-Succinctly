using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;

namespace BitBucketSampleReceiverApp.Models
{
    public class PushModel
    {
        public BitbucketRepository Repository { get; set; }
        public BitbucketUser User { get; set; }
        public BitbucketTarget Previous { get; set; }
        public BitbucketTarget Current { get; set; }
        public string RawData { get; set; } //This contains value if it went to default operation
    }
}