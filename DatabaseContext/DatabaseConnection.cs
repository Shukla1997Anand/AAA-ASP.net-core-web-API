using AAA_ASP.net_core_web_API.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace AAA_ASP.net_core_web_API.DatabaseContext
{
    public class DatabaseConnection : DbContext//entity framework
    {
        public DatabaseConnection(DbContextOptions<DatabaseConnection> options) : base(options)
        {

        }
        public DbSet<Laptop> Laptop { get; set; }
    }
}
