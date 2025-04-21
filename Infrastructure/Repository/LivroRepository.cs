using Core.Entity;
using Core.Repository;

namespace Infrastructure.Repository
{
    public class LivroRepository : EFRepository<Livro>, ILivroRepository
    {
        //Injeção de dependência
        //base = passa para a classe pai "EFRepository" o objeto "context"
        public LivroRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
