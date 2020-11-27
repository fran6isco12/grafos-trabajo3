using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace t3
{
    public class rpap
    {
        public static List<AP> _listaap = new List<AP>();

        public AP obtenerap(int id)
        {
            var automataPila = _listaap.Where(ap => ap.Id == id);
            return automataPila.FirstOrDefault();
        }
        public void Agregar(AP nuevoap)
        {
            if (nuevoap != null)
            {
                _listaap.Add(nuevoap);
            }
        }
    }
}
