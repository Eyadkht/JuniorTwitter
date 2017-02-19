using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bootstrap3.Models
{
    public class Hashtag
    {
        public int HashtagID { get; set; }
        public int TweetID { get; set; }
        [Display(Name = "Hashtag")]
        public string Text { get; set; }

        public virtual Tweet Tweet { get; set; }
    }
}