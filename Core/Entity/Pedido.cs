namespace Core.Entity
{
    public class Pedido : EntityBase
    {
        public required int ClienteId { get; set; }
        public required int LivroId { get; set; }

        #region [Navegação]

        //Virtual para poder usar lazy loading
        public virtual Cliente Cliente { get; set; }
        public virtual Livro Livro { get; set; }

        #endregion
    }
}
