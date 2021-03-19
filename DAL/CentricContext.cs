using Centric_Project_rc744716.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Centric_Project_rc744716.DAL
{
    public class CentricContext : DbContext
    {
      public CentricContext() : base("name =DefaultConnection")
        {

        }
        public DbSet<Profile> profile { get; set; }

        public System.Data.Entity.DbSet<Centric_Project_rc744716.Models.Nominate> Nominates { get; set; }
    }
}