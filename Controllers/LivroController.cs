using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Autor;
using WebApi.Dto.Livro;
using WebApi.Models;
using WebApi.Services.Autor;
using WebApi.Services.Livro;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livrointerface;
        public LivroController(ILivroInterface livrointerface)
        {
            _livrointerface = livrointerface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livrointerface.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorId/{idLivro}")]

        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
        {
            var livro = await _livrointerface.BuscarLivroPorId(idLivro);

            return Ok(livro);
        }

        [HttpGet("BuscarLivroPorIdAutor/{IdAutor}")]

        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorIdAutor(int IdAutor)
        {
            var livro = await _livrointerface.BuscarLivroPorIdAutor(IdAutor);

            return Ok(livro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var newLivro = await _livrointerface.CriarLivro(livroCriacaoDto);

            return Ok(newLivro);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            var livro = await _livrointerface.EditarLivro(livroEdicaoDto);
            return Ok(livro);
        }

        [HttpDelete("ExcluirLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirLivro(int idLivro)
        {
            var livro = await _livrointerface.ExcluirLivro(idLivro);
            return Ok(livro);
        }
    }
}
