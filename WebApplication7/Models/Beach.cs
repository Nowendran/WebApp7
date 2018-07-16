using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class Beach
    {
        
            [Key]
            public int beach_id { get; set; }

            [Required]
            [Display(Name = "Beach Name")]
            public string beach_name { get; set; }

            [Display(Name = "City Name")]
            public int city_id { get; set; }

            [ForeignKey("city_id")]
            public City city { get; set; }
        
    }
}