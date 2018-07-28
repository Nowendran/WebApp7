using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication7.Models
{
    public class EquipmentRental
    {
        [Key]
     
        public int EquipmentRentalID { get; set; }

        //fk
        public int EquipmentID { get; set; }
        [ForeignKey("EquipmentID")]
        public Equipment Equipment { get; set; }

        //fk
        public int? WarehouseID { get; set; }
        
        public virtual Warehouse Warehouse { get; set; }

        //fk
        public int? lifeguard_id { get; set; }
        [ForeignKey("lifeguard_id")]
        public Lifeguards Lifeguards { get; set; }

        

        [Required]
        [Display(Name = "Date of Return")]
        [DataType(DataType.Date)]
        public System.DateTime ReturnDate { get; set; }

       
        [Display(Name = "Date of loan")]
        [DataType(DataType.Date)]
        public DateTime DateOfLoan { get; set; }

        public bool Return { get; set; }

        private WebApplication7Context db = new WebApplication7Context();
        //public string SetStatus(Equipment equipment)
        //{
        //    var d = db.Equipments.Find(equipment.Status);

        //    var a = (from b in db.Equipments where b.EquipmentID == EquipmentID select b.Status).Single();

        //    if (Return == true)
        //    {
        //        a = "Available";
        //    }
        //    else if (Return == false)
        //    {
        //        a = "On-Loan";
        //    }
        //    else if (DateTime.Now > ReturnDate)
        //    {
        //        a = "Over Due";
        //    }
        //    else
        //    {
        //        a = "Available";
        //    }
        //    return a;
        //}






    }
}