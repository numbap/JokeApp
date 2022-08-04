using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JokeApp.Models
{
    public class VisionLabels
    {
        public int Id { get; set; }
        public Label[] Labels { get; set; }
    }

    public class Label
    {
        public int Id { get; set; }
        public float Confidence { get; set; }
        public string Name { get; set; }
    }



}