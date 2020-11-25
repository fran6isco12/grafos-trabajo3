using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_pila
{
    class Program
    {
        static void Main(string[] args)
        {
            AP auto1 = new AP();


            Console.Write("ingrese el num total de estados: ");
            string v = Console.ReadLine();
            int n = Convert.ToInt32(v);
            auto1.setnumEstados(n);
            Console.WriteLine();

            auto1.setEstadoInicial(0);

            Console.Write("ingrese el num del estados finales: ");
            string f = Console.ReadLine();
            int nf = Convert.ToInt32(f);
            Console.WriteLine();

            for(int i=0;i<nf;i++)
            {
                Console.Write("ingrese el numero del estado final: ");
                string ef = Console.ReadLine();
                int nef = Convert.ToInt32(ef);
                auto1.addEstadoFinal(nef);
                Console.WriteLine();
            }

            Console.Clear();

            Console.Write("ingrese el num total del alfabeto: ");
            string tr = Console.ReadLine();
            int ntr = Convert.ToInt32(tr);
            auto1.settotalTransiciones(ntr);
            Console.WriteLine();

            for (int i = 0; i < ntr; i++)
            {
                Console.WriteLine("ingrese la transicion: ");
                string trs = Console.ReadLine();
                auto1.addLetraAlfabeto(trs);
                Console.WriteLine();
            }

            Console.Write("Cuantas transiciones piensa realizar: ");
            string nt = Console.ReadLine();
            int t = Convert.ToInt32(nt);

            int[] origen = new int[t];
            string[] lee = new string[t];
            int[] destino = new int[t];


            for (int i=0;i<t;i++)
            {
                Console.Write("la transicion empieza en: ");
                string ei = Console.ReadLine();
                int nei = Convert.ToInt32(ei);
                origen[i] =nei;
                Console.WriteLine();

                Console.Write("la transicion se realiza con: ");
                string transi = Console.ReadLine();
                lee[i] = transi;
                Console.WriteLine();

                Console.Write("la transicion termina en: ");
                string ef = Console.ReadLine();
                int nef = Convert.ToInt32(ef);
                destino[i] = nef;
                Console.WriteLine();

                auto1.addTransicion(nei, transi, nef);
            }

            Console.Clear();

            for (int i=0;i<auto1.getnumEstados();i++ )
            {
                for(int j=0;j<auto1.gettotalTransiciones();j++)
                {
                    Console.Write("[");
                    foreach (int tra in auto1.getTablaTransiciones()[i, j])
                    {
                        Console.Write(tra);
                    }
                    Console.Write("]");
                }
                Console.WriteLine();
            }
            Console.ReadLine();

            Console.WriteLine("La concatenacion es:");

            AP union = new concatenacion().concatenar(auto1,auto1,origen,lee,destino,origen,lee,destino);

            foreach( string alf in union.getAlfabeto())
            {
                Console.Write(alf + "  ");
            }

            Console.WriteLine();

            for (int i = 0; i < union.getnumEstados(); i++)
            {
                for (int j = 0; j < union.gettotalTransiciones(); j++)
                {
                    Console.Write("[");
                    foreach (int tra in union.getTablaTransiciones()[i, j])
                    {
                        Console.Write(tra);
                    }
                    Console.Write("]");
                }
                Console.WriteLine();
            }
        }
    }
}
