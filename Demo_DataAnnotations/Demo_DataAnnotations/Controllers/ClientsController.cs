using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo_DataAnnotations.Context;
using Demo_DataAnnotations.Models.DBModels;
using System.Linq;

namespace Demo_DataAnnotations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly DevTeam504Context _context;

        public ClientsController(DevTeam504Context context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clientsFromDatabase = await _context.Clientes.Select(client => new
            {
                client.CodCliente,
                client.CodCategoriaCliente,
                client.NombreCliente,
                client.NombreNegocio,
                client.ContactoPrincipal,
                client.CorreoElectronico,
                client.DireccionNegocio,
                client.Activo,
                client.Rtn
            }).ToListAsync();

            return Ok(clientsFromDatabase);
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var clientFromDatabase = await _context.Clientes.FindAsync(id);
            bool validateIfClientExist = clientFromDatabase == null;
            if (validateIfClientExist)
            {
                return NotFound();
            }

            return Ok(new 
            {
                clientFromDatabase.CodCliente,
                clientFromDatabase.CodCategoriaCliente,
                clientFromDatabase.NombreCliente,
                clientFromDatabase.NombreNegocio,
                clientFromDatabase.ContactoPrincipal,
                clientFromDatabase.CorreoElectronico,
                clientFromDatabase.DireccionNegocio,
                clientFromDatabase.Activo,
                clientFromDatabase.Rtn
            });
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientes(int id, Clientes model)
        {
            bool compareId = id != model.CodCliente;
            if (compareId)
            {
                return BadRequest();
            }

            var clientFromDatabase = await _context.Clientes.FindAsync(id);
            bool validateIfClientExist = clientFromDatabase == null;
            if (validateIfClientExist)
            {
                return NotFound();
            }

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<IActionResult> PostClientes(Clientes clientes)
        {
            _context.Clientes.Add(clientes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientes(int id)
        {
            var clientFromDatabase = await _context.Clientes.FindAsync(id);
            bool validateIfClientExist = clientFromDatabase == null;
            if (validateIfClientExist)
            {
                return NotFound();
            }

            _context.Clientes.Remove(clientFromDatabase);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}