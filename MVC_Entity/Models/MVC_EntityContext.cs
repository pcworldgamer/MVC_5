using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Entity.Models
{
    public class MVC_EntityContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MVC_EntityContext() : base("name=MVC_EntityContext")
        {
        }

        public System.Data.Entity.DbSet<MVC_Entity.Models.User> Users { get; set; }
        public DbSet<MVC_Entity.Models.Room> Rooms { get; set; }
        public DbSet<MVC_Entity.Models.Client> Clients { get; set; }
        public DbSet<Stay> Stays { get; set; }
    }
}
