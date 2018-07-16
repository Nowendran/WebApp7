using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication7.Models
{
    public class Equipment
    {
        [Key]
       
        public int EquipmentID { get; set; }

       
        public int WarehouseID { get; set; }
        [ForeignKey("WarehouseID")]
        public Warehouse Warehouse { get; set; }

        [Required]
        [Display(Name = "Equipment Name")]
        public string itemName { get; set; }

        [Required]
        [Display(Name = "Equipment Description")]
        public string Description { get; set; }

        public string Status { get; set; }
        private WebApplication7Context db = new WebApplication7Context();

    //    public string SetStatus()
    //    {
    //        string Stat = "";
    //        //var d = db.EquipmentRentals.Find(EquipmentRentalID);
    //        var a = (from b in db.EquipmentRentals where b.EquipmentRentalID == EquipmentRentalID select b.Return).Single();
    //        var c = (from x in db.EquipmentRentals where x.EquipmentRentalID == EquipmentRentalID select x.ReturnDate).Single();

    //        if (a == true)
    //        {
    //            Stat = "Available";
    //        }
    //        else if (a == false)
    //        {
    //            Stat = "On-Loan";
    //        }
    //        else if (DateTime.Now > c)
    //        {
    //            Stat = "Over Due";
    //        }
    //        else
    //        {
    //            Stat = "Available";
    //        }
    //        return Stat;
    //    }
    }
}