using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bootstrap3.Models
{
    public class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Messages = new HashSet<Message>();
            this.Tweets = new HashSet<Tweet>();
        }
        [Display(Name ="Customer ID")]
        public int CustomerID { get; set; }
        [Display(Name = "Company ID")]
        public string CompanyID { get; set; }
        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        //[ReadOnly(true)]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Twitter Username")]
        public byte[] Screen_Name { get; set; }
        [Display(Name = "Twitter Name")]
        public string Full_Name { get; set; }
        [Display(Name = "Twitter Description")]
        public string Description { get; set; }
        [Display(Name = "Twitter Language")]
        public string Language { get; set; }
        public string Location { get; set; }
        public Nullable<int> Number_Of_Tweets { get; set; }
        public Nullable<int> Total_Following { get; set; }
        public Nullable<int> Total_Followers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}