using Core.Entity;

namespace Core.Input
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public required string Nome { get; set; }
        public DateTime? DataDeNascimento { get; set; }
        public required string CPF { get; set; }

        #region [Navegação]

        public ICollection<PedidoDto> Pedidos { get; set; }

        #endregion
    }
}
