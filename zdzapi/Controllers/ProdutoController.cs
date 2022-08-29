using Microsoft.AspNetCore.Mvc;
using zdzapi.Models;

namespace zdzapi.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            using (var ctx = new EFDBContext()) {
                return ctx.Produto.ToList();
            }
        }

        [HttpGet("{id}")]
        public Produto Get(int id)
        {
            using (var ctx = new EFDBContext()) {
                return ctx.Produto.Find(id);
            }
        }

        [HttpPost]
        public void Post([FromBody] Produto produto)
        {
            using (var ctx = new EFDBContext()) {
                ctx.Produto.Add(produto);
                ctx.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(int id, [FromBody] Produto produto)
        {
            using (var ctx = new EFDBContext()) {
                var p = ctx.Produto.Find(id);
                if (p == null)
                {
                    return NotFound();
                }
                p.Nome = produto.Nome;
                p.Quantidade = produto.Quantidade;
                p.IdCategoria = produto.IdCategoria;
                ctx.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var ctx = new EFDBContext()) {
                ctx.Remove(ctx.Produto.Single(p => p.Id == id));
                ctx.SaveChanges();
            }
        }
    }
}