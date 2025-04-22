namespace Core.Entity
{
    public class Livro : EntityBase
    {
        public required string Nome { get; set; }
        public required string Editora { get; set; }

        #region [Navegação]

        public virtual ICollection<Pedido> Pedidos { get; set; }

        #endregion

        public Livro()
        {
            DataCriacao = DateTime.Now;
        }
    }
}
