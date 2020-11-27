using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace t3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            rpap rpap = new rpap();

            var ap = rpap.obtenerap(id);

            if (ap == null)
            {
                var nf = NotFound("El AP " + id.ToString() + " no existe.");
                return nf;
            }
            ap.getEstadoInicial();
            return Ok(ap.getEstadoInicial());
        }
        [HttpPost("agregar")]
        public IActionResult Agregarafd(AP nuevoap)
        {
            rpap repap = new rpap();
            repap.Agregar(nuevoap);
            return CreatedAtAction(nameof(Agregarafd), nuevoap.getId());
        }
    }
}
