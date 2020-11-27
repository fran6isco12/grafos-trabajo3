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
        public int numestados = 4;
        public string nombre = "pueba";
        public int inicial = 0;
        public List<int> finales = new List<int> { 2, 3 };
        public string[,] trans = new string[4, 4];
        public AFD automata;
        public string resp;

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

            return Ok(automata.ERegular(automata));
            //Console.WriteLine(resp);
            //return Ok(resp);
        }
        [HttpPost("agregar")]
        public IActionResult Agregarafd(AFD nuevoafd)
        {
            rpafd repafd = new rpafd();
            repafd.Agregar(nuevoafd);
            return CreatedAtAction(nameof(Agregarafd), nuevoafd.Id);
        }
    }
}
