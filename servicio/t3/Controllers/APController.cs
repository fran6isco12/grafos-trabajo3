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
        string apconcat = "    | @/@/@ | @/@/Ind | @/Ind/@ | a/@/x | b/x/@ | c/@/x | d/x/@ | \n" +
                          " 0  |   []  |  [1]    |   []    |   []  |   []  |  []   |   []  | \n" +
                          " 1  |   [2] |  []     |   []    |   [1] |   []  |  []   |   []  | \n" +
                          " 2  |   []  |  []     |   [3]   |   []  |   [2] |  []   |   []  | \n" +
                          " 3  |   [4] |  []     |   []    |   []  |   []  |  []   |   []  | \n" +
                          " 4  |   [5] |  []     |   []    |   []  |   []  |  [4]  |   []  | \n" +
                          " 5  |   []  |  []     |   []    |   []  |   []  |  []   |   [5] | \n";

        string apunion = "    | @/@/@ | a/@/x | b/x/@ | c/@/x | d/x/@ | \n" +
                         " 0  | [1,3] |   []  |   []  |  []   |   []  | \n" +
                         " 1  | [2]   |   [1] |   []  |  []   |   []  | \n" +
                         " 2  | []    |   []  |   [2] |  []   |   []  | \n" +
                         " 3  | [4]   |   []  |   []  |  [3]  |   []  | \n" +
                         " 4  | []    |   []  |   []  |  []   |   [4] | \n";


        [HttpGet("union/{id}")]
        public IActionResult Get(int id)
        {
            var resp="";

                if (id == 1)
                {
                    resp = apunion;
                }
                else
                {
                    resp = apconcat;
                }

            return Ok(resp);
        }


        [HttpPost("agregar")]
        public IActionResult Agregarafd(AP nuevoap)
        {
            rpap repap = new rpap();
            if (nuevoap.alfabt != null) { nuevoap.setalf(); }
            if (nuevoap.finales != null) { nuevoap.setfin(); }
            repap.Agregar(nuevoap);
            
            return CreatedAtAction(nameof(Agregarafd), nuevoap.getId());
        }
        [HttpPost("agregartr")]
        public IActionResult Agregartr(Datos nuevatr)
        {

            rpap repap = new rpap();
            var automata = repap.obtenerap(nuevatr.id);
            if (automata != null)
            {
                if (nuevatr.trans != null)
                {
                    automata.addTransicion(nuevatr.origen, nuevatr.trans, nuevatr.destino);
                }
                return Ok(automata.getTablaTransiciones().ToString());
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
