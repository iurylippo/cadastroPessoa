using System.Threading.Tasks;
using CadastroPessoa.Domain;

namespace CadastroPessoa.Repository
{
    public interface ICadastroPessoaRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Pessoas
        Task<Pessoa[]> GetAllPessoaAsyncByNome(string nome);
        Task<Pessoa[]> GetAllPessoaAsync();

        Task<Pessoa> GetAllPessoaAsyncById(int PessoaId);
    }
}