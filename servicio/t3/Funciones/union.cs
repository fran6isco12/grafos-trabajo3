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
            AP.Log("Se definio el numero total de estados", File.AppendText("log.txt"));

            apUnion.setEstadoInicial(0);
            AP.Log("Se seteo el estado inicial", File.AppendText("log.txt"));

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
            AP.Log("Se definion el total de transiciones", File.AppendText("log.txt"));

            foreach (string alf1 in ap1.getAlfabeto())
            {
                apUnion.addLetraAlfabeto(alf1);
            }
            foreach (string alf2 in ap2.getAlfabeto())
            {
                apUnion.addLetraAlfabeto(alf2);
            }
            apUnion.addLetraAlfabeto("@/@/@");
            AP.Log("Se definio el nuevo alfabeto para la union", File.AppendText("log.txt"));

            foreach (int eFinal in ap1.getestadoFinal())
            {
                apUnion.addEstadoFinal(eFinal + 1);
            }
            foreach (int eFinal in ap2.getestadoFinal())
            {
                apUnion.addEstadoFinal(eFinal + 1 + ap1.getnumEstados());
            }
            AP.Log("Se definio los nuevos estados finales para apUnion", File.AppendText("log.txt"));

            apUnion.addTransicion(0, "@/@/@", (ap1.getEstadoInicial() + 1));
            apUnion.addTransicion(0, "@/@/@", (ap2.getEstadoInicial() + 1 + ap1.getnumEstados()));
            AP.Log("Se definieron las transiciones necesarias para unir ap1 y ap2", File.AppendText("log.txt"));

            for (int i = 0; (i < ap1.gettotalTransiciones()); i++)
            {
                int nOrigen1;
                nOrigen1 = origen1[i] + 1;
                int nDestino1;
                nDestino1 = destino1[i] + 1;
                apUnion.addTransicion(nOrigen1, lee1[i], nDestino1);
            }
            AP.Log("Se añadieron todas las transiciones de ap2 a apUnion", File.AppendText("log.txt"));

            for (int i = 0; (i < ap2.gettotalTransiciones()); i++)
            {
                int nOrigen2;
                nOrigen2 = origen2[i] + 1 + ap1.getnumEstados();
                int nDestino2;
                nDestino2 = destino2[i] + 1 + ap1.getnumEstados();
                apUnion.addTransicion(nOrigen2, lee2[i], nDestino2);
            }
            AP.Log("Se añadieron todas las transiciones de ap2 a apUnion", File.AppendText("log.txt"));

            AP.Log("se a unido el ap1 con el ap2", File.AppendText("log.txt"));
            return apUnion;
        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }

    }
}
