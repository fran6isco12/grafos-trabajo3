﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace t3
{
    public class rpafd
    {
        public static List<AFD> _listaafd= new List<AFD>();

        public AFD obtenerafd(int id)
        {
            var automata = _listaafd.Where(afd => afd.Id == id);
            return automata.FirstOrDefault();
        }
        public void Agregar(AFD nuevoafd)
        {
            if (nuevoafd != null)
            {
                _listaafd.Add(nuevoafd);
            }
        }
    }
}
