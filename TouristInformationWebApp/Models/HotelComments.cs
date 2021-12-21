using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TouristInformationWebApp.Models
{
    public class HotelComments
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

            public string Comments { get; set; }

            public DateTime? ThisDateTime { get; set; }

            public int HotelId { get; set; }

            public int? Rating { get; set; }
        

    }
}
