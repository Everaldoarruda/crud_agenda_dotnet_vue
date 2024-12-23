using Microsoft.AspNetCore.Mvc;
using AgendaApi.Data;
using AgendaApi.Models;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]

[ApiController]
public class ContatosController : ControllerBase
{
    private readonly AgendaContext _context;

    public AgendaContext Context => _context;

    public ContatosController(AgendaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contato>>> GetContatos()
    {
        return await _context.Contatos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Contato>> GetContato(Guid id)
    {
        var contato = await _context.Contatos.FindAsync(id);
        if (contato == null) return NotFound();
        return contato;
    }

    [HttpPost]
    public async Task<ActionResult<Contato>> PostContato(Contato contato)
    {
        contato.Id = Guid.NewGuid();
        _context.Contatos.Add(contato);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetContato), new { id = contato.Id }, contato);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutContato(Guid id, Contato contato)
    {
        if (id != contato.Id) return BadRequest();
        _context.Entry(contato).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Contatos.Any(e => e.Id == id)) return NotFound();
            throw;
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContato(Guid id)
    {
        var contato = await _context.Contatos.FindAsync(id);
        if (contato == null) return NotFound();
        _context.Contatos.Remove(contato);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
