using Core.Entity;
using Core.Repository;

namespace Infrastructure.Repository
{
    public class PedidoRepository : EFRepository<Pedido>, IPedidoRepository
    {
        //Injeção de dependência
        //base = passa para a classe pai "EFRepository" o objeto "context"
        public PedidoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
