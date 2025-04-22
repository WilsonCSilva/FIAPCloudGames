using Core.Entity;

namespace Core.Input
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public required int ClienteId { get; set; }
        public required int LivroId { get; set; }

        #region [Navegação]

        public  ClienteDto Cliente { get; set; }
        public  LivroDto Livro { get; set; }

        #endregion
    }
}
