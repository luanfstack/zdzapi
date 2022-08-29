using Microsoft.AspNetCore.Mvc;
using zdzapi.Models;

namespace zdzapi.Controllers
{
    [Route("api/fornecedor")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Fornecedor> Get()
        {
            using (var ctx = new EFDBContext()) {
                var fornecedores = ctx.Fornecedor.ToList();
                return fornecedores;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Fornecedor> Get(int id)
        {
            using (var ctx = new EFDBContext())
            {
                var fornecedor = ctx.Fornecedor.Find(id);
                if (fornecedor == null)
                {
                    return NotFound();
                }
                return fornecedor;
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Post([FromBody] Fornecedor fornecedor)
        {

            using (var ctx = new EFDBContext())
            {
                ctx.Fornecedor.Add(fornecedor);
                ctx.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(int id, [FromBody] Fornecedor fornecedor)
        {
            using (var ctx = new EFDBContext())
            {
                var f = ctx.Fornecedor.Find(id);
                if (f == null)
                {
                    return NotFound();
                }
                f.Nome = fornecedor.Nome;
                f.IdProduto = fornecedor.IdProduto;
                ctx.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            using (var ctx = new EFDBContext())
            {
                var fornecedor = ctx.Fornecedor.Single(f => f.Id == id);
                if (fornecedor == null)
                {
                    return NotFound();
                }
                ctx.Remove(fornecedor);
                ctx.SaveChanges();
                return Ok();
            }
        }
    }
}
