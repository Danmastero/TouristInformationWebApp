using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TouristInformation.Models;

namespace TouristInformationWebApp.Models
{
    public class HotelComments
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

            public string Comments { get; set; }

            public DateTime? ThisDateTime { get; set; }

            [ForeignKey("Hotel")] 
            public int HotelId { get; set; }

            public int? Rating { get; set; }

            public virtual Hotel Hotel{ get; set; }


    }
}
