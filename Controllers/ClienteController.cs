using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oriontek_management.Data;
using Oriontek_management.Models;

namespace Oriontek_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            var clientes = await _context.Clientes.ToListAsync();
            if (!clientes.Any())
                return NotFound();

            return Ok(clientes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClienteById(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            if (cliente is null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }
        [HttpPost]
        public async Task<ActionResult<Cliente>> CrearCliente(Cliente cliente)
        {
            if (cliente is null)
            {
                return BadRequest();
            }
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClienteById), new { id = cliente.Id }, cliente);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> ActualizarCliente(int id, Cliente updatedCliente)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            if (cliente is null)
            {
                return NotFound();
            }

            cliente.Nombre = updatedCliente.Nombre;
            cliente.Email = updatedCliente.Email;
            cliente.Direcciones = updatedCliente.Direcciones;

            await _context.SaveChangesAsync();

            return Ok(cliente);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> EliminarCliente(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            if (cliente is null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok(cliente);
        }
    }
}
