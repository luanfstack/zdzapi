using Microsoft.AspNetCore.Mvc;
using zdzapi.Models;

namespace zdzapi.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            using (var ctx = new EFDBContext()) { 
                var categorias = ctx.Categoria.ToList();
                return categorias;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Categoria> Get(int id)
        {
            using (var ctx = new EFDBContext()){ 
                var categoria = ctx.Categoria.Find(id);
                if (categoria == null) {
                    return NotFound();
                }
                return categoria;
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Post([FromBody] Categoria categoria)
        {
            using (var ctx = new EFDBContext()) { 
                ctx.Categoria.Add(categoria);
                ctx.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(int id, [FromBody] Categoria categoria)
        {
            using (var ctx = new EFDBContext()) {
                var c = ctx.Categoria.Find(id);
                if (c == null) {
                    return NotFound();
                }
                c.Nome = categoria.Nome;
                ctx.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            using (var ctx = new EFDBContext()) {
                var categoria = ctx.Categoria.Single(c => c.Id == id);
                if (categoria == null) {
                    return NotFound();
                }
                ctx.Remove(categoria);
                ctx.SaveChanges();
                return Ok();
            }
        }
    }
}