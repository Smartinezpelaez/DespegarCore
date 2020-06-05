using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DespegarCore.Data;
using DespegarCore.Models;
using RestSharp;

namespace DespegarCore.Controllers
{
    public class ReservasController : Controller
    {
        private readonly DespegarContext _context;
        
        public ReservasController(DespegarContext context)
        {
            _context = context;           
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reserva.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }     

    // GET: Reservas/Create
    public IActionResult Create(int ID, int idResereva, string aerolineas, string origen, string destino, DateTime? FechayHoraSalida, int silla, int precio, string clase)
        {  
            
        DespegarCore.Models.Reserva reserva = new Reserva();
        reserva.IDReserva = idResereva;
            reserva.Origen = origen;
            reserva.Destino = destino;
            reserva.FechayHoraSalida = FechayHoraSalida;           
            reserva.Silla = silla;
            reserva.Clase = clase;
            reserva.Precio = precio;
            reserva.Aerolinea = aerolineas;              
            return View(reserva);
            
        }
               
        // POST: Reservas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDReserva,Origen,Destino,FechayHoraSalida,Silla,Clase,Precio,NombreCliente,NumeroDocumento,Aerolinea")] Reserva reserva)
        {       
            if (ModelState.IsValid)
            {
               var status = "";

                if (reserva.Aerolinea.Equals("Avianca"))
                {
                   // _context.Reserva.ToListAsync();

                    status = Services.VuelosServices.SaveReservaAvianca(reserva).ToString();
                }               
                                            
                 if (!status.Equals(""))
                 {
                    _context.Add(reserva);
                    await _context.SaveChangesAsync();
                 }                
                
                return RedirectToAction(nameof(Index));        
               
            }             
            
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var reserva = await _context.Reserva.FindAsync(id);

           // var reserva1 = await _context1.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDReserva,Origen,Destino,FechayHoraSalida,Silla,Clase,Precio,NombreCliente,NumeroDocumento,Aerolinea")] Reserva reserva)
        {
            if (id != reserva.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.ID == id);
        }
    }
}
