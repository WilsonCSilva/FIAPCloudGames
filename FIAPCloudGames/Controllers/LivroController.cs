using Core.Entity;
using Core.Input;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FIAPCloudGames.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;

        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_livroRepository.ObterTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                return Ok(_livroRepository.ObterPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //input = baseado no coneito de dto (data transfer object),
        //separa para maipular as informações conforme necessário, ou seja, menos exposição.

        [HttpPost]
        public IActionResult Post([FromBody] LivroInput input)
        {
            try
            {
                var livro = new Livro()
                {
                    Nome = input.Nome,
                    Editora = input.Editora
                };
                _livroRepository.Cadastrar(livro);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }   
        }

        [HttpPut]
        public IActionResult Put([FromBody] LivroUpdateInput input)
        {
            try
            {
                var livro = _livroRepository.ObterPorId(input.Id);
                livro.Nome = input.Nome;
                livro.Editora = input.Editora;
                _livroRepository.Alterar(livro);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _livroRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
