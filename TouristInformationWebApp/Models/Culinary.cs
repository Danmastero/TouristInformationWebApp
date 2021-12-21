
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace TouristInformation.Models
{ 
    public class Culinary 
    { 

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; }
    
    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string Description { get; set; }
   
    [Required]
    public virtual ICollection<Dish> Dishes{ get; set; }

    public virtual Country Country { get; set; }
    
    [ForeignKey("Country")]
    public virtual int CountryId { get; set; }

    

    }
}   