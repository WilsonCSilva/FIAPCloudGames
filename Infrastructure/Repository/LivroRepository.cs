using Core.Entity;
using Core.Repository;

namespace Infrastructure.Repository
{
    public class LivroRepository : EFRepository<Livro>, ILivroRepository
    {
        //Injeção de dependência
        //base = passa para a classe pai "EFRepository" o objeto "context"
        public LivroRepository(ApplicationDbContext context) : base(context)
        { 
        }

        public void CadastrarEmMassa(IEnumerable<Livro> Livros)
        {
            //var tempo1 = System.Diagnostics.Stopwatch.StartNew();

            //_context.AddRange(Livros);
            //_context.SaveChanges();

            //tempo1.Stop();
            //var milisegundos = tempo1.ElapsedMilliseconds;

            var tempo2 = System.Diagnostics.Stopwatch.StartNew();

            _context.BulkInsert(Livros);

            tempo2.Stop();
            var milisegundos2 = tempo2.ElapsedMilliseconds;

            //System.Diagnostics.Debug.WriteLine($"Tempo AddRange: {milisegundos} ms");
            System.Diagnostics.Debug.WriteLine($"Tempo BulkInsert: {milisegundos2} ms");
        }
    }
}
