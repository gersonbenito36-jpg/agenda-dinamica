using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaContacto.API.Models;
using AgendaContacto.API.Data;


namespace AgendaContacto.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ContactosController : ControllerBase
    {   

        //EST ES MI CONSTRUCTOR
        private readonly AppDbContext _context; //ESTE ES MI PUENTE A LA BASE DE DATOS  _context
        public ContactosController(AppDbContext context)
        {
            _context = context;
        }
         // GET: api/contactos
         [HttpGet]
         public async Task<ActionResult<IEnumerable<Contacto>>> GetContactos()
         {
            return await _context.Contactos.ToListAsync();
         }

         [HttpGet("{id}")]
         public async Task<ActionResult<Contacto>> GetContacto(int id)
         {
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null) return NotFound();
            return contacto;
         }

         [HttpPost]
         public async Task<ActionResult<Contacto>> PostContacto(Contacto contacto)
         {
            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetContacto), new { id = contacto.Id }, contacto);
         }

         [HttpPut("{id}")]
         public async Task<IActionResult> PutContacto(int id, Contacto contacto)
         {
            if(id !=contacto.Id) return BadRequest();
            _context.Entry(contacto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
         }
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteContacto(int id)
         {
            var contacto = await _context.Contactos.FindAsync(id);
            if(contacto == null) return NotFound();
            _context.Contactos.Remove(contacto);
            await _context.SaveChangesAsync();
            return NoContent();
         }
    }
}