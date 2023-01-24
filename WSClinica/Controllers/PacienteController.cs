using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WSClinica.Context;
using WSClinica.Models;
using Microsoft.EntityFrameworkCore;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : Controller
    {
        //INYECCION DE DEPENDENCIA -> INIT
        private readonly DbClinicaContext context;

        public PacienteController(DbClinicaContext context)
        {
            this.context = context;
        }

        //SELECT
        [HttpGet]
        public ActionResult<IEnumerable<Paciente>> Get()
        {
            return context.Pacientes.ToList();
        }

        //SELECT BY AGE
        [HttpGet("pacientes/{idMedico}")]
        public ActionResult<IEnumerable<Paciente>> Get(int idMedico)
        {
            List<Paciente> pacientes = (from p in context.Pacientes
                                        where idMedico == p.MedicoId
                                        select p).ToList();

            return pacientes;
        }

        //SELECT BY ID
        [HttpGet("{id}")]
        public ActionResult<Paciente> GetById(int nroHistClinica)
        {
            var paciente = (from p in context.Pacientes
                            where nroHistClinica == p.NroHistClinica
                            select p).SingleOrDefault();
            return paciente;
        }



        //INSERT
        [HttpPost]
        public ActionResult Post(Paciente p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Pacientes.Add(p);
            context.SaveChanges();
            return Ok();
        }

        //UPDATE            
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Paciente p)
        {
            if (id != p.Id)
            {
                return BadRequest();
            }

            context.Entry(p).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //DELETE            
        [HttpDelete("{id}")]
        public ActionResult<Paciente> Delete(int id)
        {
            var paciente = (from p in context.Pacientes
                            where p.Id == id
                            select p).SingleOrDefault();

            if (paciente == null)
            {
                return NotFound();
            }

            context.Pacientes.Remove(paciente);
            context.SaveChanges();

            return paciente;
        }
    }
}
