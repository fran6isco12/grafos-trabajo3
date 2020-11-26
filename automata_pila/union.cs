using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_pila
{
    class union
    {
        int numEstados;
        int estadoInicial;
        int totalTransiciones;
        SortedSet<string> alfabeto;
        SortedSet<int> estadosFinales;
        SortedSet<int>[,] tabUnion;

        public union()
        {
            alfabeto = new SortedSet<string>();
            estadosFinales = new SortedSet<int>();
        }

        public AP unir(AP ap1, AP ap2, int[] origen1, string[] lee1, int[] destino1, int[] origen2, string[] lee2, int[] destino2)
        {
            AP apUnion = new AP(numEstados, estadoInicial, totalTransiciones, alfabeto, estadosFinales, tabUnion);

            apUnion.setnumEstados(ap1.getnumEstados() + ap2.getnumEstados() + 1);
            apUnion.setEstadoInicial(0);
            apUnion.settotalTransiciones(ap1.gettotalTransiciones() + ap2.gettotalTransiciones());

            foreach (string alf1 in ap1.getAlfabeto())
            {
                apUnion.addLetraAlfabeto(alf1);
            }

            foreach (string alf2 in ap2.getAlfabeto())
            {
                apUnion.addLetraAlfabeto(alf2);
            }

            apUnion.addLetraAlfabeto("@/@/@");

            foreach (int eFinal in ap1.getestadoFinal())
            {
                apUnion.addEstadoFinal(eFinal + 1);
            }

            foreach (int eFinal in ap2.getestadoFinal())
            {
                apUnion.addEstadoFinal(eFinal + 1 + ap1.getnumEstados());
            }

            apUnion.addTransicion(0, "@/@/@", (ap1.getEstadoInicial() + 1));
            apUnion.addTransicion(0, "@/@/@", (ap2.getEstadoInicial() + 1 + ap1.getnumEstados()));

            for (int i = 0; (i < ap1.gettotalTransiciones()); i++)
            {
                int nOrigen1;
                nOrigen1 = origen1[i] + 1;
                int nDestino1;
                nDestino1 = destino1[i] + 1;
                apUnion.addTransicion(nOrigen1, lee1[i], nDestino1);
            }

            for (int i = 0; (i < ap2.gettotalTransiciones()); i++)
            {
                int nOrigen2;
                nOrigen2 = origen2[i] + 1 + ap1.getnumEstados();
                int nDestino2;
                nDestino2 = destino2[i] + 1 + ap1.getnumEstados();
                apUnion.addTransicion(nOrigen2, lee2[i], nDestino2);
            }

            return apUnion;
        }

    }
}
