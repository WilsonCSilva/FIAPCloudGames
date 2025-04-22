using Core.Entity;
using Core.Input;
using Core.Repository;

namespace Infrastructure.Repository
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        //Injeção de dependência
        //base = passa para a classe pai "EFRepository" o objeto "context"
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ClienteDto ObterPedidoSeisMeses(int id)
        {
            //Usando lazyloading
            var cliente = _context.Cliente
                .FirstOrDefault(c => c.Id == id)
                ?? throw new Exception("Cliente não cadastrado.");

            return new ClienteDto()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                DataCriacao = cliente.DataCriacao,
                DataDeNascimento = cliente.DataDeNascimento,
                CPF = cliente.CPF,
                Pedidos = cliente.Pedidos
                    .Where(p => p.DataCriacao >= DateTime.Now.AddMonths(-6))
                    .Select(p => new PedidoDto()
                    {
                        Id = p.Id,
                        DataCriacao = p.DataCriacao,
                        LivroId = p.LivroId,
                        ClienteId = p.ClienteId,
                        Livro = new LivroDto()
                        {
                            Id = p.Livro.Id,
                            DataCriacao = p.Livro.DataCriacao,
                            Nome = p.Livro.Nome,
                            Editora = p.Livro.Editora,
                        }
                    }).ToList()
            };
        }
    }
}
