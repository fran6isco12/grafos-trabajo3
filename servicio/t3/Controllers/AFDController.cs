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

        [HttpGet]
        public IActionResult Get()
        {
            trans[0, 0] = "0,1";
            trans[0, 1] = "1";
            trans[1, 2] = "0,1";
            trans[2, 3] = "0,1";
            Console.WriteLine("2"+ "/n");
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (trans[i, j] == null)
                    {
                        trans[i, j] ="";
                    }
                }
            }
            Console.WriteLine(trans[0, 1]+"/n");
            automata = new AFD(nombre, numestados, inicial, finales, trans);
            resp = automata.ERegular(automata)+"esta es la er"+ trans[2,2]+"as"+inicial;
            Console.WriteLine(resp+"1");
            return Ok(resp);
        }
    }
}
