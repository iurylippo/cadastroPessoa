using System.Threading.Tasks;
using CadastroPessoa.Domain;
using CadastroPessoa.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : Controller
    {
        private readonly ICadastroPessoaRepository _repo;

        public PessoaController(ICadastroPessoaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllPessoaAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou!");
            }
           
        }

        [HttpGet("{PessoaId}")]
        public async Task<IActionResult> Get(int PessoaId)
        {
            try
            {
                var results = await _repo.GetAllPessoaAsyncById(PessoaId);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou!");
            }
           
        }

        [HttpGet("getByNome/{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var results = await _repo.GetAllPessoaAsyncByNome(nome);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou!");
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pessoa model)
        {
            try
            {
                model.Imc = model.Peso/(model.Altura * model.Altura);
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/pessoa/{model.Id}", model);
                }
                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou!");
            }

           return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int PessoaId, Pessoa model)
        {
            try
            {
                var pessoa = await _repo.GetAllPessoaAsyncById(PessoaId);
                if (pessoa == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/pessoa/{model.Id}", model);
                }
                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou!");
            }

           return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int PessoaId)
        {
            try
            {
                var pessoa = await _repo.GetAllPessoaAsyncById(PessoaId);
                if (pessoa == null) return NotFound();

                _repo.Delete(pessoa);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou!");
            }

           return BadRequest();
        }
    }
}