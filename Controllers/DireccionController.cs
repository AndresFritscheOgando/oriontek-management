using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oriontek_management.Data;
using Oriontek_management.Models;

namespace Oriontek_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DireccionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Direccion>>> GetDirecciones()
        {
            var direcciones = await _context.Direcciones.ToListAsync();
            if (!direcciones.Any())
                return NotFound();

            return Ok(direcciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Direccion>> GetDireccionById(int id)
        {
            var direccion = await _context.Direcciones.FirstOrDefaultAsync(d => d.Id == id);

            if (direccion is null)
            {
                return NotFound();
            }
            return Ok(direccion);
        }
        [HttpPost]
        public async Task<ActionResult<Direccion>> CrearDireccion(Direccion direccion)
        {
            if (direccion is null)
            {
                return BadRequest();
            }
            _context.Direcciones.Add(direccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDireccionById), new { id = direccion.Id }, direccion);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Direccion>> ActualizarDireccion(int id, Direccion updatedDireccion)
        {
            var direccion = await _context.Direcciones.FirstOrDefaultAsync(d => d.Id == id);

            if (direccion is null)
            {
                return NotFound();
            }

            direccion.Calle = updatedDireccion.Calle;
            direccion.Ciudad = updatedDireccion.Ciudad;
            direccion.Pais = updatedDireccion.Pais;
            // direccion.ClienteId = updatedDireccion.ClienteId;

            _context.Direcciones.Update(direccion);
            await _context.SaveChangesAsync();

            return Ok(direccion);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Direccion>> EliminarDireccion(int id)
        {
            var direccion = await _context.Direcciones.FirstOrDefaultAsync(d => d.Id == id);

            if (direccion is null)
            {
                return NotFound();
            }

            _context.Direcciones.Remove(direccion);
            await _context.SaveChangesAsync();

            return Ok(direccion);
        }
    }
}
