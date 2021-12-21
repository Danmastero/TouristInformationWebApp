
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace TouristInformation.Models
{   
  
    public class Dish
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Description { get; set; }

        [ForeignKey("Culinary")]

        public virtual int CulinaryId { get; set; }

        public virtual Culinary Culinary { get; set; }

    }
}  