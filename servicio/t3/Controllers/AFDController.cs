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
    public class AFDController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            rpafd rpafd = new rpafd();

            var automata = rpafd.obtenerafd(id);

            if (automata == null)
            {
                var nf = NotFound("El afd " + id.ToString() + " no existe.");
                return nf;
            }
            automata.tabtotran();
            if (automata.GetTabTrans() != null && automata.GetNumEstado()!=0) { return Ok(automata.ERegular(automata)); }
            else
            {
                return BadRequest();
            }
            //Console.WriteLine(resp);
            //return Ok(resp);
        }
        [HttpPost("agregar")]
        public IActionResult Agregarafd(AFD nuevoafd)
        {
            rpafd repafd = new rpafd();
            repafd.Agregar(nuevoafd);
            return CreatedAtAction(nameof(Agregarafd),nuevoafd.Getid());
        }
    }
}
