using Business.Interfaz;
using Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaBusiness PersonaBusiness;
        public PersonasController(IPersonaBusiness personaBusiness)
        {
            PersonaBusiness = personaBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<List<Persona>>> GetAll()
        {
            return await PersonaBusiness.GetAll();
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            return await PersonaBusiness.Get(id);
        }

        // POST api/<PersonasController>
        [HttpPost]
        public async Task<ActionResult<bool>> Save(Persona pesona)
        {
            return await PersonaBusiness.Save(pesona);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Update(Persona pesona)
        {
            return await PersonaBusiness.Update(pesona);
        }


        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await PersonaBusiness.Delete(id);
        }
    }
}
