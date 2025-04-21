using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        //Injeção de dependência
        //base = passa para a classe pai "EFRepository" o objeto "context"
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Cliente ObterPedidoSeisMeses(int id)
        {
            var cliente = _context.Cliente
                .Include(c => c.Pedidos)
                .ThenInclude(p => p.Livro)
                .FirstOrDefault(c => c.Id == id) //Where
                ?? throw new Exception("Cliente não cadastrado."); 

            cliente.Pedidos = cliente.Pedidos
                .Where(c => c.DataCriacao >= DateTime.Now.AddMonths(-6))
                .Select(P =>
                {
                    P.Cliente = null; //Eliminar dependência ciclica, ou seja, não ficar buscando cliente, pois já passei na rota.
                    P.Livro.Pedidos = null; //Não buscar os pedidos novamente
                    return P;
                })
                .ToList();

            return cliente;
        }
    }
}
