using Core.Entity;

namespace Core.Repository
{
    public interface ILivroRepository : IRepository<Livro>
    {
        //Uso IEnumerable, pois não traz os dados em memória, somente a referência dos objetos, ganhando desempenho
        void CadastrarEmMassa(IEnumerable<Livro> Livros);
    }
}
