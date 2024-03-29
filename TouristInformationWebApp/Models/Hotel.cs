﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TouristInformationWebApp.Models;

namespace TouristInformation.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public string Price { get; set; }


        [Required]
        [Range(1, 5)]
        public int Stars { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }
      
        [ForeignKey("City")]

        public virtual int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<HotelRating> HotelRatings{ get; set; }

    }
}
