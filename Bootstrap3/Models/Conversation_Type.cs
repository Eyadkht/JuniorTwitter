using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bootstrap3.Models
{
    public class Conversation_Type
    {
        public Conversation_Type()
        {
            this.Streams = new HashSet<Stream>();
        }
        public int Conversation_TypeID { get; set; }

        [Display(Name ="Type")]
        public string Text { get; set; }

        public virtual ICollection<Stream> Streams { get; set; }
    }
}