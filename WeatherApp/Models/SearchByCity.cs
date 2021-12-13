using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class SearchByCity
    {
        [Required]
        [Display(Name = "City Name:")]
        public string CityName { get; set; }
    }
}
