using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bootstrap3.Models
{
    public class Tweet
    {

        public Tweet()
        {
            this.Hashtags = new HashSet<Hashtag>();
            this.URL_Tweet = new HashSet<URL_Tweet>();
        }

        public int TweetID { get; set; }
        public int CustomerID { get; set; }
        [Display(Name ="Tweet")]
        public string Text { get; set; }
        public Nullable<int> in_reply_To_Tweet_ID { get; set; }
        [Display(Name = "Tweet Language")]
        public string Lang { get; set; }
        [Display(Name = "Tweeted From")]
        public string Location { get; set; }
        [Display(Name = "# Retweeted")]
        public Nullable<int> Retweet_Count { get; set; }
        [Display(Name = "Retweeted")]
        public Nullable<bool> Is_Retweeted { get; set; }

        [Display(Name = "Tweeted at")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> CreatedAt { get; set; }
        [Display(Name = "Tweeted by")]
        public string CreatedBy { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Hashtag> Hashtags { get; set; }
        public virtual ICollection<URL_Tweet> URL_Tweet { get; set; }
    }
}