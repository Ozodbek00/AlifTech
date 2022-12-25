using AlifTech.Domain.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace AlifTech.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        /// <summary>
        /// Users table.
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Wallets table.
        /// </summary>
        public virtual DbSet<Wallet> Wallets { get; set; }

        /// <summary>
        /// Transactions table.
        /// </summary>
        public virtual DbSet<Transaction> Transactions { get; set; }
    }
}
