using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication7.Models
{
    public class City
    {
        [Key]
        public int city_id { get; set; }

        [Required]
        [Display(Name = "City Name")]
        public string city_name { get; set; }

        [Required]
        [Display(Name = "Province")]
        public string province { get; set; }

    }
}