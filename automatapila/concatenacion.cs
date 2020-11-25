using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_pila
{
    class concatenacion
    {
        int numEstados;
        int estadoInicial;
        int totalTransiciones;
        SortedSet<string> alfabeto;
        SortedSet<int> estadosFinales;
        SortedSet<int>[,] tablaTransiciones;

        public AP concatenar(AP ap1, AP ap2)
        {
            numEstados = ap1.getnumEstados() + ap2.getnumEstados() + 2;
            estadoInicial = 0;
            totalTransiciones = 2 + ap1.gettotalTransiciones() + ap2.gettotalTransiciones();

            alfabeto.Add("@/@/Ind");
            alfabeto.Add("@/Ind/@");
            alfabeto.Add("@/@/@");
            foreach( string alf1 in ap1.getAlfabeto())
            {
                alfabeto.Add(alf1);
            }

            foreach (string alf2 in ap2.getAlfabeto())
            {
                alfabeto.Add(alf2);
            }

            foreach (int eFinal in ap2.getestadoFinal())
            {
                estadosFinales.Add(eFinal+2+ap1.getnumEstados());
            }

            SortedSet<int>[,] tabUnion = new SortedSet<int>[numEstados,totalTransiciones];
            for (int x = 0; x < numEstados; x++)
            {
                for (int y = 0; y < totalTransiciones; y++)
                {
                    tabUnion[x, y] = new SortedSet<int>();
                }
            }

            int cont1 = 0;
            int dif1 = 0;

            foreach (string trn in alfabeto)
            {
                if (trn != "@/@/Ind" && dif1 == 0)
                    cont1++;
                if (trn == "@/@/Ind")
                    dif1++;
            }
            tabUnion[0, cont1].Add(ap1.getEstadoInicial()+1);

            int cont2 = 0;
            int dif2 = 0;
            foreach (string trn in alfabeto)
            {
                if (trn != "@/Ind/@" && dif2 == 0)
                    cont2++;
                if (trn == "@/Ind/@")
                    dif2++;
            }
            tabUnion[(ap1.getnumEstados()),cont2].Add(1+ap1.getnumEstados());

            int cont3 = 0;
            int dif3 = 0;
            foreach (string trn in alfabeto)
            {
                if (trn != "@/@/@" && dif2 == 0)
                    cont3++;
                if (trn == "@/@/@")
                    dif3++;
            }
            tabUnion[(2+ap1.getnumEstados()), cont3].Add(ap2.getEstadoInicial() + ap1.getnumEstados()+2);

            return new AP(numEstados, estadoInicial,totalTransiciones,alfabeto,estadosFinales,tabUnion);
        }
    }
}
