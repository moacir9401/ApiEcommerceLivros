using ApiEcommerceLivros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;

namespace ApiEcommerceLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrariaController : ControllerBase
    {
        private readonly ToDoContext _context;

        public LivrariaController(ToDoContext context)
        {
            _context = context;

            if (!_context.todoProduts.Any())
            {

                _context.todoProduts.Add(new Produto { ID = "1", Nome = "Ebook 1", Preco = 24.0, Quantidade = 1, Categoria = "Ação", Img = "img1" });
                _context.todoProduts.Add(new Produto { ID = "2", Nome = "Ebook 2", Preco = 30, Quantidade = 3, Categoria = "Ação", Img = "img2" });
                _context.todoProduts.Add(new Produto { ID = "3", Nome = "Ebook 3", Preco = 4.0, Quantidade = 10, Categoria = "Ação", Img = "img3" });
                _context.todoProduts.Add(new Produto { ID = "4", Nome = "Ebook 4", Preco = 94.0, Quantidade = 5, Categoria = "Ação", Img = "img4" });
                _context.todoProduts.Add(new Produto { ID = "5", Nome = "Ebook 5", Preco = 120.0, Quantidade = 22, Categoria = "Ação", Img = "img5" });

                _context.SaveChanges(); 
            }
           
        }

        [HttpGet]
        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            return await _context.todoProduts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetItem(string id)
        {
            var item = await _context.todoProduts.FindAsync(id.ToString());

            if (item == null) return NotFound();

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            await _context.AddAsync(produto);
            _context.SaveChanges();

            return produto;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> UpdateProduto( Produto produto, string id)
        {
            var item = await _context.todoProduts.FindAsync(id.ToString());

            item.Nome = produto.Nome;
            item.Preco = produto.Preco;
            item.Quantidade = produto.Quantidade;
            item.Categoria = produto.Categoria;
            item.Img = produto.Img;
             
            _context.SaveChanges();

            return item;

        }
    }
}
