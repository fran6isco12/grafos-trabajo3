using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace t3.Controllers
{
    public class APController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class APController : ControllerBase
        {
            public int numEstados = 1;
            public int inicial = 0;
            public int totalTransiciones = 1;
            public SortedSet<string> alfabeto = new SortedSet<string> { "a" };
            public SortedSet<int> estadosFinales = new SortedSet<int> { 0 };
            public SortedSet<int>[,] tablaTransiciones = new SortedSet<int>[1,1];
            public AP ap1;

            [HttpGet("{id}")]
            public IActionResult Get(int id)
            {

            }
            [HttpPost("agregar")]
            public IActionResult Agregarafd(AFD nuevoafd)
            {

            }
        }
    }
}
