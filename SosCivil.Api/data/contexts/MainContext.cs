using Microsoft.EntityFrameworkCore;
using SosCivil.Api.Data.Entities;

namespace SosCivil.Api.Data.Contexts
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
