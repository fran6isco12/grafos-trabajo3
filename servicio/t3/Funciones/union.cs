using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace t3
{
    public class union
    {
        int numEstados;
        int estadoInicial;
        int totalTransiciones;
        SortedSet<string> alfabeto;
        SortedSet<int> estadosFinales;
        SortedSet<int>[,] tabUnion=new SortedSet<int>[1,1];

        public union()
        {
            alfabeto = new SortedSet<string>();
            estadosFinales = new SortedSet<int>();
        }

        public AP unir(AP ap1, AP ap2, int[] origen1, string[] lee1, int[] destino1, int[] origen2, string[] lee2, int[] destino2)
        {
            AP apUnion = new AP(numEstados, estadoInicial, totalTransiciones, alfabeto, estadosFinales, tabUnion);

            apUnion.setnumEstados(ap1.getnumEstados() + ap2.getnumEstados() + 1);
            Console.WriteLine("Se definio el numero total de estados");

            apUnion.setEstadoInicial(0);
            Console.WriteLine("Se seteo el estado inicial");

            SortedSet<string> alfUnion = new SortedSet<string>();
            foreach (string letra1 in ap1.getAlfabeto())
            {
                alfUnion.Add(letra1);
            }
            foreach (string letra2 in ap2.getAlfabeto())
            {
                alfUnion.Add(letra2);
            }
            int cont = 0;
            foreach (string letra in alfUnion)
            {
                cont++;
            }
            apUnion.settotalTransiciones(1 + cont);
            Console.WriteLine("Se definion el total de transiciones");

            foreach (string alf1 in ap1.getAlfabeto())
            {
                apUnion.addLetraAlfabeto(alf1);
            }
            foreach (string alf2 in ap2.getAlfabeto())
            {
                apUnion.addLetraAlfabeto(alf2);
            }
            apUnion.addLetraAlfabeto("@/@/@");
            Console.WriteLine("Se definio el nuevo alfabeto para la union");

            foreach (int eFinal in ap1.getestadoFinal())
            {
                apUnion.addEstadoFinal(eFinal + 1);
            }
            foreach (int eFinal in ap2.getestadoFinal())
            {
                apUnion.addEstadoFinal(eFinal + 1 + ap1.getnumEstados());
            }
            Console.WriteLine("Se definio los nuevos estados finales para apUnion");

            apUnion.addTransicion(0, "@/@/@", (ap1.getEstadoInicial() + 1));
            apUnion.addTransicion(0, "@/@/@", (ap2.getEstadoInicial() + 1 + ap1.getnumEstados()));
            Console.WriteLine("Se definieron las transiciones necesarias para unir ap1 y ap2");

            for (int i = 0; (i < ap1.gettotalTransiciones()); i++)
            {
                int nOrigen1;
                nOrigen1 = origen1[i] + 1;
                int nDestino1;
                nDestino1 = destino1[i] + 1;
                apUnion.addTransicion(nOrigen1, lee1[i], nDestino1);
            }
            Console.WriteLine("Se añadieron todas las transiciones de ap2 a apUnion");

            for (int i = 0; (i < ap2.gettotalTransiciones()); i++)
            {
                int nOrigen2;
                nOrigen2 = origen2[i] + 1 + ap1.getnumEstados();
                int nDestino2;
                nDestino2 = destino2[i] + 1 + ap1.getnumEstados();
                apUnion.addTransicion(nOrigen2, lee2[i], nDestino2);
            }
            Console.WriteLine("Se añadieron todas las transiciones de ap2 a apUnion");

            Console.WriteLine("se a unido el ap1 con el ap2");
            return apUnion;
        }



    }
}
