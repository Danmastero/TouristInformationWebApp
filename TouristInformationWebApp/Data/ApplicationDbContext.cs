using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TouristInformation.Models;
using TouristInformationWebApp.Models;

namespace TouristInformationWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TouristInformation.Models.Country> Country { get; set; }
        public DbSet<TouristInformation.Models.Continent> Continent { get; set; }
        public DbSet<Attraction> Attraction { get; set; }
        public DbSet<Tour> Tour { get; set; }
        public DbSet<TouristInformation.Models.Dish> Dish { get; set; }
        
        public DbSet<TouristInformation.Models.Restaurant> Restaurant { get; set; }
        public DbSet<TouristInformation.Models.Culinary> Culinary { get; set; }
        public DbSet<TouristInformation.Models.City> City { get; set; }
        public DbSet<TouristInformation.Models.Hotel> Hotel { get; set; }
        public DbSet<TouristInformationWebApp.Models.HotelComments> HotelComments { get; set; }
        public DbSet<TouristInformationWebApp.Models.Reservation> Reservation { get; set; }
    }
}
