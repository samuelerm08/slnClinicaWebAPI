using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WSClinica.Context;
using WSClinica.Models;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : Controller
    {
        //INYECCION DE DEPENDENCIA -> INIT
        private readonly DbClinicaContext context;

        public HabitacionController(DbClinicaContext context)
        {
            this.context = context;
        }

        //SELECT
        [HttpGet]
        public ActionResult<IEnumerable<Habitacion>> Get()
        {
            return context.Habitaciones.ToList();
        }

        //SELECT BY ID
        [HttpGet("{id}")]
        public ActionResult<Habitacion> GetById(int id)
        {
            var hab = (from h in context.Habitaciones
                            where id == h.ID
                            select h).SingleOrDefault();
            return hab;
        }

        //INSERT
        [HttpPost]
        public ActionResult Post(Habitacion habitacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Habitaciones.Add(habitacion);
            context.SaveChanges();
            return Ok();
        }

        //UPDATE            
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Habitacion h)
        {
            if (id != h.ID)
            {
                return BadRequest();
            }

            context.Entry(h).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //DELETE            
        [HttpDelete("{id}")]
        public ActionResult<Habitacion> Delete(int id)
        {
            var hab = (from h in context.Habitaciones
                            where h.ID == id
                            select h).SingleOrDefault();

            if (hab == null)
            {
                return NotFound();
            }

            context.Habitaciones.Remove(hab);
            context.SaveChanges();

            return hab;
        }
    }
}
