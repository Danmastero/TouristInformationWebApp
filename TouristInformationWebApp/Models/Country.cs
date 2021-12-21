using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TouristInformation.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Capital { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Language { get; set; }

        [Required]
        public int Population { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Description { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Currency { get; set; }

        [ForeignKey("Continent")]

        public virtual int ContinentId { get; set; }


        public virtual Continent Continent { get; set; }
        public virtual ICollection<City> City { get; set; }
        public virtual Culinary Culinary { get; set; }


    }
}
