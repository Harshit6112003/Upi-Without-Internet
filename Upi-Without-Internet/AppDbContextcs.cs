using Microsoft.EntityFrameworkCore;
using Upi_Without_Internet.Models;

namespace Upi_Without_Internet
{
    public class AppDbContextcs : DbContext
    {

        public AppDbContextcs(DbContextOptions<AppDbContextcs> options) : base(options) { }
        public DbSet<Payment> Payments { get; set; }
    }
}
