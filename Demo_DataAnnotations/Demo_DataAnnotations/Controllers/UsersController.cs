using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo_DataAnnotations.Context;
using Demo_DataAnnotations.Models.DBModels;

namespace Demo_DataAnnotations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DevTeam504Context _context;

        public UsersController(DevTeam504Context context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var usersFromDatabase = await _context.Usuarios.ToListAsync();
            return Ok(usersFromDatabase);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var userFromDatabase = await _context.Usuarios.FindAsync(id);
            bool validateIfUserExist = userFromDatabase == null;
            if (validateIfUserExist)
            {
                return NotFound();
            }

            return Ok(userFromDatabase);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Usuarios model)
        {
            bool compareId = id != model.Id;
            if (compareId)
            {
                return BadRequest();
            }

            var userFromDatabase = await _context.Usuarios.FindAsync(id);
            bool validateIfUserExist = userFromDatabase == null;
            if (validateIfUserExist)
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

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser(Usuarios model)
        {
            _context.Usuarios.Add(model);
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

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userFromDatabase = await _context.Usuarios.FindAsync(id);
            bool validateIfUserExist = userFromDatabase == null;
            if (validateIfUserExist)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(userFromDatabase);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}