using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bootstrap3.Models
{
    public class Company : IdentityUser
    {
        [Display(Name ="Twitter Username")]
        public string Screen_Name { get; set; }
     
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Stream> Streams { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}