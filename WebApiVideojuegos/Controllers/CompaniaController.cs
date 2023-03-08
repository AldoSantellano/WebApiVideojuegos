using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using WebApiVideojuegos.Entidades;

namespace WebApiVideojuegos.Controllers
{
    [ApiController]
    [Route("api/companias")]
    public class CompaniaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public CompaniaController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public ActionResult<List<Compania>> Get()
        {
            return new List<Compania>()
            {
                new Compania() { ID = 1, Nombre = "Intelligent Systems", Direccion = "Washington St 801", Telefono = 8289001231},
                new Compania() {ID = 2, Nombre = "HAL Laboratory", Direccion = "Kanda Square 2-2-1", Telefono = 4551234371}
            };
        }

        [HttpPost]
        public async Task<ActionResult> Post(Compania compania)
        {
            dbContext.Add(compania);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("/lista")]
        public async Task<ActionResult<List<Compania>>> GetAll()
        {
            return await dbContext.Companias.Include(x => x.videojuegos).ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Compania compania, int id)
        {
            if(compania.ID != id)
            {
                return BadRequest("El ID de la compañía no coincide con el estabablecido en la url.");
            }

            dbContext.Update(compania);
            await dbContext.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Companias.AnyAsync(x => x.ID == id);
            if(!exist)
            {
                return NotFound("No se encontró la Compañía."); 
            }

            dbContext.Remove(new Compania()
            {
                ID = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
