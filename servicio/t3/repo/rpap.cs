using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace t3
{
    public class rpap
    {
        public static List<AP> _listap = new List<AP>();

        public AP obtenerap(int id)
        {
            var automata = _listap.Where(afd => afd.id == id);
            return automata.FirstOrDefault();
        }
        public void Agregar(AP nuevoap)
        {
            if (nuevoap != null)
            {
                _listap.Add(nuevoap);
            }
        }
    }
}
