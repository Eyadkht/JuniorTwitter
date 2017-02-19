using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bootstrap3.Models
{
    public class Target_Industry
    {
        public Target_Industry()
        {
            this.IndustryWords = new HashSet<IndustryWord>();
            this.Streams = new HashSet<Stream>();
        }

        public int Target_IndustryID { get; set; }
        [Display(Name = "Industry")]
        public string text { get; set; }

        public virtual ICollection<IndustryWord> IndustryWords { get; set; }
        public virtual ICollection<Stream> Streams { get; set; }
    }
}