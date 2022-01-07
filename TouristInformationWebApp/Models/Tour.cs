using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TouristInformation.Models
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int AvailableSpots { get; set; }

        

        [ForeignKey("Attraction")]
        public virtual int AttractionId { get; set; }

        public virtual Attraction Attraction { get; set; }


    }
}
