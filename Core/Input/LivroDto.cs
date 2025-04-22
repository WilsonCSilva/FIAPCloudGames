using Core.Entity;

namespace Core.Input
{
    public class LivroDto
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public required string Nome { get; set; }
        public required string Editora { get; set; }

        #region [Navegação]

        public ICollection<Pedido> Pedidos { get; set; }

        #endregion
    }
}
