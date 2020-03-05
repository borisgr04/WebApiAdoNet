using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApiAdoNet.Models;

namespace WebApiAdoNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private PersonaService _personaService;

        public IConfiguration Configuration { get; }

        public PersonaController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _personaService = new PersonaService(connectionString);
        }
        // GET: api/Persona
        [HttpGet]
        public IEnumerable<PersonaViewModel> Gets()
        {
            var personas = _personaService.Consultar().Select(p=> new PersonaViewModel(p));
            return personas;
        }

        // GET: api/Persona/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Persona
        [HttpPost]
        public ActionResult<string> Post(PersonaModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            string mensaje = _personaService.Guardar(persona);
            return Ok(mensaje);
        }

        private Persona MapearPersona(PersonaModel personaInput)
        {
            var persona = new Persona();
            persona.Identificacion = personaInput.Identificacion;
            persona.Nombre = personaInput.Nombre;
            persona.Edad = personaInput.Edad;
            persona.Sexo = personaInput.Sexo;
            return persona;
        }

        // PUT: api/Persona/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
