using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiVideojuegos.Entidades;

namespace WebApiVideojuegos.Controllers
{
    [ApiController]
    [Route("videojuego")]
    public class VideojuegoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VideojuegoController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Videojuego>>> GetAll()
        {
            return await _context.Videojuegos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Videojuego>> GetById(int id)
        {
            return await _context.Videojuegos.FirstOrDefaultAsync(x => x.ID == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Videojuego videojuego)
        {
            var existeCompa = await _context.Companias.AnyAsync(x => x.ID == videojuego.CompaniaID);

            if(!existeCompa)
            {
                return BadRequest("No existe la compañía.");
            }
            _context.Add(videojuego);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Videojuego videojuego, int id)
        {
            var existeVJ = await _context.Videojuegos.AnyAsync(x => x.ID == id);

            if(!existeVJ)
            {
                return BadRequest("No existe el videojuego.");
            }

            if(videojuego.ID != id)
            {
                return BadRequest("El ID del videojuego no coincide con el establecido en la URL.");
            }
            _context.Update(videojuego);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _context.Videojuegos.AnyAsync(x => x.ID == id);
            if(!exist)
            {
                return NotFound("No se encontró el videojuego en la base de datos.");
            }

            _context.Remove(new Videojuego()
            {
                ID = id
            });
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
