using Microsoft.EntityFrameworkCore;

namespace WebAppAPITest.Model
{
    public class OrderTblDBContext : DbContext
    {
        public OrderTblDBContext()
        {
        }

        public OrderTblDBContext(DbContextOptions<OrderTblDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=khuong\\SQLEXPRESS03;Initial Catalog=OrderSystem;User ID=sa;Password=25122004;Encrypt=False");
        }

        public DbSet<OrderTbl> Orders { get; set; }
    }
}
