using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dto.Autor;
using WebApi.Dto.Livro;
using WebApi.Models;

namespace WebApi.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();

            try
            {

                var livro = await _context.Livros.Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
                if (livro == null)
                {
                    resposta.Mensagem = "livro não encontrado.";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "livro encontrado com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int IdAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros.Include(a => a.Autor)
                    .Where(livroBanco => livroBanco.Autor.Id == IdAutor )
                    .ToListAsync();

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum ";
                    return resposta;
                }
                resposta.Dados = livro;
                resposta.Mensagem = "Autor do livro encontrado com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroCriacaoDto.Autor.Id);

                if(autor == null)
                {
                    resposta.Mensagem = "Nenhum registro de Autor Localizado!";
                    return resposta;
                }

                var livro = new LivroModel
                {
                    Name = livroCriacaoDto.Name,
                    Autor = autor
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros.
                    Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == livroEdicaoDto.Id);

                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroEdicaoDto.Autor.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro de Autor Localizado!";
                    return resposta;
                }

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro de Livro Localizado!";
                    return resposta;
                }

                livro.Name = livroEdicaoDto.Name;
                livro.Autor = autor;
                
                _context.Update(livro);

                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros.Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
                if (livro == null)
                {
                    resposta.Mensagem = "Não não encontrado.";
                    return resposta;
                }
                _context.Remove(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Livro excluído com sucesso.";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livros.Include(a => a.Autor).ToListAsync();
                resposta.Dados = livros;
                resposta.Mensagem = "Lista de livros obtida com sucesso.";

                return resposta;

            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message; 
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
