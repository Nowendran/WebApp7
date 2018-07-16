using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication7.Models
{
    public class Warehouse
    {
        [Key]
        
        public int WarehouseID { get; set; }

        //fk
        public int beach_id { get; set; }
        [ForeignKey("beach_id")]
        public Beach Beach { get; set; }

        [Required]
        [Display(Name = "Warehouse Name")]
        public string WarehouseName { get; set; }

       

      



    }
}