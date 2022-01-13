using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TouristInformation.Models;

namespace TouristInformationWebApp.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [Range(1,50)]
        [Required]
        public int NumOfSeats { get; set; }


        [ForeignKey("Tour")]

        public virtual int TourId { get; set; }
        public virtual Tour Tour { get; set; }



        [Required]
        public DateTime Date { get; set; }

    }
}