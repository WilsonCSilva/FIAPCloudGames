﻿using Core.Entity;
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
                var livrosDto = new List<LivroDto>();
                var Livros = _livroRepository.ObterTodos();

                foreach (var livro in Livros)
                {
                    livrosDto.Add(new LivroDto() 
                    { 
                        Id = livro.Id,
                        DataCriacao = livro.DataCriacao,
                        Nome = livro.Nome,
                        Editora = livro.Editora,
                        Pedidos = livro.Pedidos.Select(pedido => new Pedido()
                        {
                            ClienteId = pedido.ClienteId,
                            LivroId = pedido.LivroId,
                        }).ToList()
                    });
                }

                return Ok(livrosDto);
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

        [HttpPost("cadastro_em_massa")]
        public IActionResult CadastroEmMassa()
        {
            try
            {
                var livros = new List<Livro>()
                {
                    new Livro() { Nome = "Livro 1", Editora = "Editora"},
                    new Livro() { Nome = "Livro 2", Editora = "Editora"},
                    new Livro() { Nome = "Livro 3", Editora = "Editora"},
                    new Livro() { Nome = "Livro 4", Editora = "Editora"},
                    new Livro() { Nome = "Livro 5", Editora = "Editora"},
                    new Livro() { Nome = "Livro 6", Editora = "Editora"},
                    new Livro() { Nome = "Livro 7", Editora = "Editora"},
                    new Livro() { Nome = "Livro 8", Editora = "Editora"},
                    new Livro() { Nome = "Livro 9", Editora = "Editora"},
                    new Livro() { Nome = "Livro 10", Editora = "Editora"},
                };

                _livroRepository.CadastrarEmMassa(livros);
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
