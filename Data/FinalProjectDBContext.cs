using Microsoft.EntityFrameworkCore;

namespace FinalProjApi.Data
{
    public class FinalProjectDBContext : DbContext
    {
        public FinalProjectDBContext(DbContextOptions options) : base(options)
        {

        }

    }
}
