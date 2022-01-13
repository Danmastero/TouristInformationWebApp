using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TouristInformation.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")]

        public int Population { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string Description { get; set; }

        [ForeignKey("Country")]

        public virtual int CountryId { get; set; }
        public virtual Country Country { get; set; }

       
        public virtual ICollection<Restaurant> Restaurants { get; set; }

        public virtual ICollection<Attraction> Attractions { get; set; }
        public virtual ICollection<Hotel> Hotel { get; set; }



    }
}
