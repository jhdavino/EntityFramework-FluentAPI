using EntityFrameworkFluentAPIExemplo.Models;
using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkFluentAPIExemplo.EntityMap
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // defino o nome da tabela no banco
            ToTable("Categories");

            // defino a chave primária
            HasKey(p => p.Id);
            
            Property(p => p.Name).HasMaxLength(55).IsUnicode().IsRequired();

            Property(p => p.Description).HasMaxLength(255).IsRequired();

            Property(p => p.CreatedAt).IsRequired();

            Property(p => p.UpdatedAt).IsOptional();

            //Não precisamos criar um relacionamento aqui, pois já fizemos isso no mapeamento de Post
        }
    }
}