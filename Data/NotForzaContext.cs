using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Downloads.Data
{
    public class NotForzaContext : DbContext
    {
        public NotForzaContext(DbContextOptions<NotForzaContext> options) : base(options) { }

        public DbSet<Car> Car { get; set; }
        public DbSet<PlayerStats> PlayerStats { get; set; }
    }
    public class Car
    {
        [Key]
        public int CarID {get; set; }
        public string? CarName {get; set; }
        public string? CarModel {get; set; }
        public int CarYear {get; set; }
        public string? CarGrade {get; set; }
        public int CarCost {get; set; }
        public string? CarDescription {get; set; } = string.Empty;
        public string? CarPicURL {get; set; } = string.Empty;

        
    }

    public class PlayerStats
    {
        [Key]
        public int PlayerID { get; set; }
        public required string Username {get; set;}
        public int Currency { get; set; }
        public int SocialLevel { get; set; }
        public int RankLevel { get; set; }
        public int XP { get; set; }
        public required string  HouseLocation { get; set; }
        public required string ProfilePic { get; set; }
        public string? Bio { get; set; }
    }

}

