using FinalProjApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProjApi.Data
{
    public class FinalProjectDBContext : DbContext
    {
        public FinalProjectDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<OutfitWeather> Outfits { get; set; }
        public DbSet<ZipCodeKey> ZipCodeKeys { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
