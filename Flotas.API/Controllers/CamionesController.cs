﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Flotas.API.Data;
using Flotas.Modelos;

namespace Flotas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamionesController : ControllerBase
    {
        private readonly SqlServerDbContext _context;

        public CamionesController(SqlServerDbContext context)
        {
            _context = context;
        }

        // GET: api/Camiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Camion>>> GetCamion()
        {
            return await _context.Camiones.ToListAsync();
        }

        // GET: api/Camiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Camion>> GetCamion(int id)
        {
            var camion = await _context.Camiones.FindAsync(id);

            if (camion == null)
            {
                return NotFound();
            }

            return camion;
        }

        // PUT: api/Camiones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCamion(int id, Camion camion)
        {
            var camionToUpdate = await _context.Camiones.FindAsync(id);
            if (camionToUpdate == null)
            {
                return NotFound();
            }

            // Actualizar solo las propiedades que quieres permitir cambiar
            camionToUpdate.ConductorId = camion.ConductorId;
            camionToUpdate.Marca = camion.Marca;
            camionToUpdate.Modelo = camion.Modelo;
            camionToUpdate.Anio = camion.Anio;
            camionToUpdate.Placa = camion.Placa;
            camionToUpdate.KilometrajeActual = camion.KilometrajeActual;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CamionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Camiones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Camion>> PostCamion(Camion camion)
        {
            _context.Camiones.Add(camion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCamion", new { id = camion.Id }, camion);
        }

        // DELETE: api/Camiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCamion(int id)
        {
            var camion = await _context.Camiones.FindAsync(id);
            if (camion == null)
            {
                return NotFound();
            }

            _context.Camiones.Remove(camion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CamionExists(int id)
        {
            return _context.Camiones.Any(e => e.Id == id);
        }
    }
}
