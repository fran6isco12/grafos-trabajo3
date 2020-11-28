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
        [HttpGet("union/{accion}/{id1}/{id2}")]
        public IActionResult Get(int accion,int id1,int id2)
        {
            rpap repap= new rpap();
            var ap1 = repap.obtenerap(id1);
            var ap2 = repap.obtenerap(id2);
            if (ap1 != null && ap2 != null)
            {
                if (accion == 0)
                {//poner la unionaqui 
                
                }
                else
                {
                    //poner la la concatenacion 
                }


            }
            return Ok();
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
