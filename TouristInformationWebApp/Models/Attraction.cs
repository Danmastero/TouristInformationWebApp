﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TouristInformation.Models
{
    public class Attraction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Description { get; set; }


        [ForeignKey("City")]
        public virtual int CityId { get; set; }

        public virtual City City { get; set; }



        public virtual ICollection<Tour> Tour { get; set; }

        //public virtual ICollection<AttractionRating> AttractionRatings{ get; set; }


    }
}
