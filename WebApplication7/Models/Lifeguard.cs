using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Lifeguards
    {
        [Key]
        public int lifeguard_id { get; set; }

        [Required]
        [Display(Name = "Lifeguard Name")]
        [MaxLength(50)]
        public string lifeguard_name { get; set; }

        [Required]
        [Display(Name = "Date Of birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Lifeguard status")]
        public string l_status { get; set; }

        [Display(Name = "City Name")]
        public int city_id { get; set; }
        [ForeignKey("city_id")]
        public City city { get; set; }

    }
}