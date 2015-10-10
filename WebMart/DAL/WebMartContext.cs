using WebMart.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebMart.DAL
{
    public class WebMartContext : DbContext
    {

        public WebMartContext()
            : base("WebMartContext")
        {
        }

        
        public DbSet<Student> Students { get; set; }
        public DbSet<TestOrder> TestOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}