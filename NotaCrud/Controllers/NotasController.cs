using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotaCrud.Models;

namespace NotaCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {

        private readonly NotaContext _context;

        public NotasController(NotaContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult>CrearNota(Nota nota)
        {
            await _context.Notas.AddAsync(nota);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<Nota>
            {
                success = true,
                message = "Nota creada correctamente",
                data = nota
            });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nota>>>listarNotas()
        {
            var notas = await _context.Notas.ToListAsync();

            return Ok(new ApiResponse<List<Nota>>
            {
                success = true,
                data = notas
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>verNotaDetalle(int id)
        {
            Nota nota = await _context.Notas.FindAsync(id);

            if (nota == null)
            {
                return NotFound();
            }

            return Ok(new ApiResponse<Nota>
            {
                success = true,
                message = "",
                data = nota
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>actualizarNota(int id, Nota nota)
        {
            var notaExistente = await _context.Notas.FindAsync(id);

            if (notaExistente == null)
                return NotFound(new ApiResponse<string>
                {
                    success = false,
                    message = "Nota no encontrada"
                });

            notaExistente.sTitulo = nota.sTitulo;
            notaExistente.sDescripcion = nota.sDescripcion;

            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<Nota>
            {
                success = true,
                message = "Nota actualizada correctamente",
                data = notaExistente
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>eliminarNota(int id)
        {
            var nota = await _context.Notas.FindAsync(id);

            if (nota == null)
                return NotFound(new ApiResponse<string>
                {
                    success = false,
                    message = "Nota no encontrada"
                });

            nota.bEstado = false;

            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<string>
            {
                success = true,
                message = "Nota eliminada correctamente"
            });
        }

    }
}
