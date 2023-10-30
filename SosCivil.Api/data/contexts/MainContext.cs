using Microsoft.EntityFrameworkCore;
using SosCivil.Api.Data.Entities;

namespace SosCivil.Api.Data.Contexts
{
    public class MainContext : DbContext
    {
        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Occurrence> Occurrences  { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Request> Requests{ get; set; }
        public DbSet<RequestItem> RequestItems{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Cobrade> Cobrades { get; set; }
        
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
