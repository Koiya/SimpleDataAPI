using Microsoft.EntityFrameworkCore;
using SimpleDataAPI.Models;
namespace SimpleDataAPI.Data
{
    public class APIContext : DbContext
    {
        public DbSet<PlayerRankings> Rankings { get; set; }
        public APIContext(DbContextOptions<APIContext> options)
            :base(options)
        {


        }
    }
}
