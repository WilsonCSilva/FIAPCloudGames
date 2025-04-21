namespace Core.Input
{
    public class LivroUpdateInput
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Editora { get; set; }
    }
}
