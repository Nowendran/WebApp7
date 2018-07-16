using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class WebApplication7Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebApplication7Context() : base("name=WebApplication7Context")
        {
        }

        public System.Data.Entity.DbSet<WebApplication7.Models.Lifeguards> Lifeguards { get; set; }

        public System.Data.Entity.DbSet<WebApplication7.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<WebApplication7.Models.Beach> Beaches { get; set; }

        public System.Data.Entity.DbSet<WebApplication7.Models.Warehouse> Warehouses { get; set; }

        public System.Data.Entity.DbSet<WebApplication7.Models.Equipment> Equipments { get; set; }

        public System.Data.Entity.DbSet<WebApplication7.Models.EquipmentRental> EquipmentRentals { get; set; }
    }
}
