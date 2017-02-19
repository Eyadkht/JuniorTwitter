using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bootstrap3.Models
{
    public class IndustryWord
    {
        public IndustryWord()
        {
            this.Stream_Keywords = new HashSet<Stream_Keyword>();
        }

        public int IndustryWordID { get; set; }
        [Display(Name ="KeyWord")]
        public string Text { get; set; }
        public int Target_IndustryID { get; set; }

        public virtual Target_Industry Target_Industry { get; set; }
        public virtual ICollection<Stream_Keyword> Stream_Keywords { get; set; }
    }
}