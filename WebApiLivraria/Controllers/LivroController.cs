using Microsoft.AspNetCore.Mvc;
using WebApiLivraria.Repository;
using WebApiLivraria.Application.Model;
using WebApiLivraria.Application.Service;


namespace WebApiLivraria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly Context _ctx;

        public LivroController(Context context)
        {
            _ctx = context;
        }

        [HttpPost]
        [Route("[action]")]

        public IActionResult adicionarLivro([FromBody] LivroRequest request)
        {
            var livroService = new LivroService(_ctx);
            var sucesso = livroService.adicionarLivro(request);

            if (sucesso == null)
            {
                return BadRequest(sucesso);
            }
            else
            {
                return Ok(sucesso);
            }
        }

        [HttpGet]
        public IActionResult obterLivros()
        {
            var livroService = new LivroService(_ctx);
            return Ok(livroService.obterLivros());
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult obterLivro(int id)
        {
            var livroService = new LivroService(_ctx);
            return Ok(livroService.obterLivro(id));
        }


        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult deletarLivro(int id)
        {
            var livroService = new LivroService(_ctx);
            var sucesso = livroService.deletarLivro(id);

            if (sucesso)
            {
                return Ok("Livro deletado com sucesso.");
            }
            else
            {
                return BadRequest("Falha ao deletar o livro. Verifique se o ID é válido.");
            }
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public IActionResult atualizarLivro(int id, [FromBody] LivroRequest request)
        {
            var livroService = new LivroService(_ctx);
            var sucesso = livroService.atualizarLivro(id, request);

            if (sucesso)
            {
                return Ok("Livro atualizado com sucesso.");
            }
            else
            {
                return BadRequest("Falha ao atualizar o livro. Verifique se o ID é válido.");
            }
        }
    }
}