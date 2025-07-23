﻿using WebApi.Dto.Autor;
using WebApi.Dto.Livro;
using WebApi.Models;

namespace WebApi.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel <LivroModel>> BuscarLivroPorId(int idLivro);
        Task<ResponseModel< List <LivroModel>>> BuscarLivroPorIdAutor(int IdAutor);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto);
        Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro);
    }
}
