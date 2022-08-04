using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JokeApp.Models;

namespace JokeApp.Models
{
    public class Images
    {
        public int Id { get; set; }

        public string BucketName { get; set; }
        public string ImageName { get; set; }
        public string AwsRegion { get; set; }
        public string AwsUrl { get; set; }

        public string Message { get; set;  }

        public VisionLabels vl { get; set; }

        public Images()
        {

        }

    }
}