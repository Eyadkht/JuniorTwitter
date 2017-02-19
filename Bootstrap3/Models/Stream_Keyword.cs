using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bootstrap3.Models
{
    public class Stream_Keyword
    {
        public int Stream_KeywordID { get; set; }
        public int StreamID { get; set; }
        public Nullable<int> IndustryWordID { get; set; }

        public virtual IndustryWord IndustryWord { get; set; }
        public virtual Stream Stream { get; set; }
    }
}