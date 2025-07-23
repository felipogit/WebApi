using WebApi.Dto.Vinculo;
using WebApi.Models;

namespace WebApi.Dto.Livro
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AutorVinculoDto Autor { get; set; }
    }   
}
