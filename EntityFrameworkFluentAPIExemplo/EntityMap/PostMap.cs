using EntityFrameworkFluentAPIExemplo.Models;
using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkFluentAPIExemplo.EntityMap
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            // defino o nome da tabela no banco
            ToTable("Posts");

            // defino a chave primária
            HasKey(p => p.Id);

            // A propriedade Title é configurada respectivamente com:
            // Máximo de Caracters = 255
            // É única, ou seja, não haverá títulos iguais.
            // É obrigatório, ou seja, não pode ser nulo.
            Property(p => p.Title).HasMaxLength(255).IsUnicode().IsRequired();

            Property(p => p.CreatedAt).IsRequired();

            // A propriedade Title é configurada respectivamente com:
            // Opcional, ou seja, poderá ser nula.
            Property(p => p.UpdatedAt).IsOptional();

            Property(p => p.Slug).HasMaxLength(255).IsUnicode().IsRequired();

            // Relacionamento de N para N
            HasMany(c => c.Categories)
                .WithMany(p => p.Posts)
                .Map(pc => 
                    pc.ToTable("PostsCategories") // Nome da tabela de relacionamento que será criada. 
                        .MapLeftKey("PostId") // Nome da chave estrangeira de Post
                        .MapRightKey("CategoryId")); // Nome da chave estrangeira de Category
        }
    }
}