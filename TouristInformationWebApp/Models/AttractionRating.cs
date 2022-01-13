using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TouristInformation.Models
{
    public class AttractionRating
    {
        [Required]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Comment { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [ForeignKey("Attraction")]
        public virtual int AttractionId { get; set; }

        public virtual Attraction Attraction { get; set; }


    }
}