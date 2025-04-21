using Core.Entity;

namespace Core.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPedidoSeisMeses(int id);
    }
}
