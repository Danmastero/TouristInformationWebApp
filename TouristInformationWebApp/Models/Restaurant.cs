using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TouristInformation.Models
{
    public class Restaurant
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Cuisine { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        public int Stars { get; set; }

        [ForeignKey("City")]

        public virtual int CityId{ get; set; }

        public virtual City City { get; set; }


    }
}
