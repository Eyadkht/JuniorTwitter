using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bootstrap3.Models
{
    public class Stream
    {
        public int StreamID { get; set; }
        public string CompanyID { get; set; }
        [Display(Name="Stream Name")]
        public string Name { get; set; }
        public string Language { get; set; }
        public string Location { get; set; }
        public Nullable<int> Conversation_TypeID { get; set; }
        public Nullable<int> Target_IndustryID { get; set; }

        public virtual Conversation_Type Conversation_Type { get; set; }
        public virtual Target_Industry Target_Industry { get; set; }
    }
}