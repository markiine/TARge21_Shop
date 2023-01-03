using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Domain;

namespace TARge21Shop.Data
{
    public class TARge21ShopContext : DbContext
    {
        public TARge21ShopContext(DbContextOptions<TARge21ShopContext> options) : base(options)
        {
        }

        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToDatabase> FileToDatabases { get; set; }
        public DbSet<Car> Cars { get; set; }

    }
}
