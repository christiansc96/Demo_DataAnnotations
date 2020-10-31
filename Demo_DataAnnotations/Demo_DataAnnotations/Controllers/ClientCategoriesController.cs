using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo_DataAnnotations.Context;
using Demo_DataAnnotations.Models.DBModels;

namespace Demo_DataAnnotations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientCategoriesController : ControllerBase
    {
        private readonly DevTeam504Context _context;

        public ClientCategoriesController(DevTeam504Context context)
        {
            _context = context;
        }

        // GET: api/ClientCategories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categoriesFromDatabase = await _context.CategoriaCliente.Select(category => new 
            {
                category.CodCategoriaCliente,
                category.NombreCategoriaCliente,
                category.DescripcionCategoriaCliente,
                category.Activo
            }).ToListAsync();
            return Ok(categoriesFromDatabase);
        }

        // GET: api/ClientCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var categoryFromDatabase = await _context.CategoriaCliente.FindAsync(id);
            bool validateIfCategoryExist = categoryFromDatabase == null;
            if (validateIfCategoryExist)
            {
                return NotFound();
            }

            return Ok(new 
            {
                categoryFromDatabase.CodCategoriaCliente,
                categoryFromDatabase.NombreCategoriaCliente,
                categoryFromDatabase.DescripcionCategoriaCliente,
                categoryFromDatabase.Activo
            });
        }

        // PUT: api/ClientCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoriaCliente model)
        {
            bool compareId = id != model.CodCategoriaCliente;
            if (compareId)
            {
                return BadRequest();
            }

            var categoryFromDatabase = await _context.CategoriaCliente.FindAsync(id);
            bool validateIfCategoryExist = categoryFromDatabase == null;
            if (validateIfCategoryExist)
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

        // POST: api/ClientCategories
        [HttpPost]
        public async Task<IActionResult> PostCategory(CategoriaCliente model)
        {
            _context.CategoriaCliente.Add(model);

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

        // DELETE: api/ClientCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var categoryFromDatabase = await _context.CategoriaCliente.FindAsync(id);
            bool validateIfCategoryExist = categoryFromDatabase == null;
            if (validateIfCategoryExist)
            {
                return NotFound();
            }

            _context.CategoriaCliente.Remove(categoryFromDatabase);
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