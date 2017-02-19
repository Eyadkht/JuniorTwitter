using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bootstrap3.Models
{
    public class JuniorDBContext : IdentityDbContext<Company>
    {
        public JuniorDBContext() : base("JuniorDBContext")
        {

        }
        //public DbSet<Company> Companies { get; set; }
        public DbSet<Conversation_Type> Conversation_Types { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<IndustryWord> IndustryWord { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Stream> Streams { get; set; }
        public DbSet<Stream_Keyword> Stream_Keywords { get; set; }
        public DbSet<Target_Industry> Target_Industries { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<URL_Tweet> URL_Tweets { get; set; }

    }
}