namespace Core.Entity
{
    public class Pedido : EntityBase
    {
        public required int ClienteId { get; set; }
        public required int LivroId { get; set; }

        #region [Navegação]

        public Cliente Cliente { get; set; }
        public Livro Livro { get; set; }

        #endregion
    }
}
