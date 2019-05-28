using System.Linq;
using System.Threading.Tasks;
using CadastroPessoa.Domain;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa.Repository
{
    public class CadastroPessoaRepository : ICadastroPessoaRepository
    {
        public readonly CadastroPessoaContext _context;
                public CadastroPessoaRepository(CadastroPessoaContext context)
        {
            _context = context;
            
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

         public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

         public async Task<bool> SaveChangesAsync()
        {
          return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Pessoa[]> GetAllPessoaAsync()
        {
            IQueryable<Pessoa> query = _context.Pessoas;
            return await query.ToArrayAsync();
        }

        public async Task<Pessoa> GetAllPessoaAsyncById(int PessoaId)
        {
            IQueryable<Pessoa> query = _context.Pessoas;
            query.Where(c => c.Id == PessoaId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pessoa[]> GetAllPessoaAsyncByNome(string nome)
        {
            IQueryable<Pessoa> query = _context.Pessoas;
            query.Where(c => c.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        
    }
}