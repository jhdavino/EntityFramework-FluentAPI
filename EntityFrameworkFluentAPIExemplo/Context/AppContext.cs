using EntityFrameworkFluentAPIExemplo.EntityMap;
using EntityFrameworkFluentAPIExemplo.Models;
using System.Data.Entity;

namespace EntityFrameworkFluentAPIExemplo.Context
{
    public class AppContext : DbContext
    {
        public AppContext()
            :base("DefaultConnection")
        {}

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configuração da entidade Post
            modelBuilder.Configurations.Add(new PostMap());

            // Configuração da entidade Category
            modelBuilder.Configurations.Add(new CategoryMap());

            // As configurações de relacionamento estão na classe PostMap,
            // mas também poderia estar aqui, usando o modelBuilder.

            base.OnModelCreating(modelBuilder);
        }
    }
}