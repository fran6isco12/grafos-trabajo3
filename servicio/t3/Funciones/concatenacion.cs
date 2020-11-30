using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace t3
{
    public class concatenacion
    {
        int numEstados;
        int estadoInicial;
        int totalTransiciones;
        SortedSet<string> alfabeto;
        SortedSet<int> estadosFinales;
        SortedSet<int>[,] tabUnion=new SortedSet<int>[1, 1];

        public concatenacion()
        {
            alfabeto = new SortedSet<string>();
            estadosFinales = new SortedSet<int>();
        }

        public AP concatenar(AP ap1, AP ap2, int[] origen1, string[] lee1, int[] destino1, int[] origen2, string[] lee2, int[] destino2)
        {

            AP apConca = new AP(numEstados, estadoInicial, totalTransiciones, alfabeto, estadosFinales, tabUnion);

            apConca.setnumEstados(ap1.getnumEstados() + ap2.getnumEstados() + 2);
            Console.WriteLine("Se definio el numero tota de estados");

            apConca.setEstadoInicial(0);
            Console.WriteLine("Se definio el estado inicial");

            SortedSet<string> alfConca = new SortedSet<string>();
            foreach (string letra1 in ap1.getAlfabeto())
            {
                alfConca.Add(letra1);
            }
            foreach (string letra2 in ap2.getAlfabeto())
            {
                alfConca.Add(letra2);
            }
            int cont = 0;
            foreach (string letra in alfConca)
            {
                cont++;
            }
            apConca.settotalTransiciones(3 + cont);
            Console.WriteLine("Se definio el total de transiciones");

            apConca.addLetraAlfabeto("@/@/Ind");
            apConca.addLetraAlfabeto("@/Ind/@");
            apConca.addLetraAlfabeto("@/@/@");
            foreach (string alf1 in ap1.getAlfabeto())
            {
                apConca.addLetraAlfabeto(alf1);
            }
            foreach (string alf2 in ap2.getAlfabeto())
            {
                apConca.addLetraAlfabeto(alf2);
            }
            Console.WriteLine("Se definio el nuevo alfabeto para la concatenacion");

            foreach (int eFinal in ap2.getestadoFinal())
            {
                apConca.addEstadoFinal(eFinal + 3 + ap1.getnumEstados());
            }
            Console.WriteLine("Se definio el/los nuevos estado(s) final(es) para apConca");

            apConca.addTransicion(0, "@/@/Ind", (ap1.getEstadoInicial() + 1));
            apConca.addTransicion(ap1.gettotalTransiciones(), "@/Ind/@", (ap1.getnumEstados() + 1));
            apConca.addTransicion((ap1.gettotalTransiciones() + 1), "@/@/@", (ap1.gettotalTransiciones() + 2));
            Console.WriteLine("Se definieron las transiciones necesarias para concatenar ap1 y ap2");

            for (int i = 0; (i < ap1.gettotalTransiciones()); i++)
            {
                int nOrigen1;
                nOrigen1 = origen1[i] + 1;
                int nDestino1;
                nDestino1 = destino1[i] + 1;
                apConca.addTransicion(nOrigen1, lee1[i], nDestino1);
            }
            Console.WriteLine("Se añadieron todas las transiciones de ap1 a apConca");

            for (int i = 0; (i < ap2.gettotalTransiciones()); i++)
            {
                int nOrigen2;
                nOrigen2 = origen2[i] + 2 + ap1.getnumEstados();
                int nDestino2;
                nDestino2 = destino2[i] + 2 + ap1.getnumEstados();
                apConca.addTransicion(nOrigen2, lee2[i], nDestino2);
            }
            Console.WriteLine("Se añadieron todas las tranciones de ap2 a apConca");

            Console.WriteLine("se a concatenado el ap1 con el ap2");
            return apConca;
        }



    }
}
