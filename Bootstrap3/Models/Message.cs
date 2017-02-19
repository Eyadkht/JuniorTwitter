using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bootstrap3.Models
{
    public class Message
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string CompanyID { get; set; }
        [Display(Name = "Message")]
        public string Text { get; set; }

        public virtual Customer Customer { get; set; }
    }
}