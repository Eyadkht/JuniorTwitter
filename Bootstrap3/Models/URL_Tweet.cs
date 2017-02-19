using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bootstrap3.Models
{
    public class URL_Tweet
    {
        public int URL_TweetID { get; set; }
        public int TweetID { get; set; }
        [Display(Name = "URL")]
        public string URL { get; set; }

        public virtual Tweet Tweet { get; set; }
    }
}