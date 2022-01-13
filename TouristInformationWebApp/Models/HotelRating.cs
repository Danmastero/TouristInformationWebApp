using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TouristInformation.Models
{
    public class HotelRating
    {
        [Required]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Comment { get; set; }


        [Required]
        [Range(1, 6)]
        public int Rating { get; set; }

        [ForeignKey("Hotel")]
        public virtual int HotelId { get; set; }

        public virtual Hotel Hotel{ get; set; }


    }
}