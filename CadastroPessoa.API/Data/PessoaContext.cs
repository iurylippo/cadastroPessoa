using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa.API.Model.Data
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) : base (options) {}

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}