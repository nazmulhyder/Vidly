using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Vidly.Models;

namespace Vidly.VidlyDbContext
{
    public class VidlyDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies{ get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }



    }
}