using CadastroPessoa.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroPessoa.Repository
{
    public class CadastroPessoaContext : DbContext
    {
        public CadastroPessoaContext(DbContextOptions<CadastroPessoaContext> options) : base (options) {}

        public DbSet<Pessoa> Pessoas { get; set; }

        
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasMaxLength(100);
            builder.Property(p => p.Cpf).HasMaxLength(11);
            builder.Property(p => p.Idade).HasMaxLength(3);
            builder.Property(p => p.Peso).HasMaxLength(5);
            builder.Property(p => p.Altura).HasMaxLength(5);
            builder.Property(p => p.Imc).HasMaxLength(5);
        }
    }
}