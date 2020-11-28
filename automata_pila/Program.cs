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


            Console.Write("ingrese el num total de estados (AP 1): ");
            string v = Console.ReadLine();
            int n = Convert.ToInt32(v);
            auto1.setnumEstados(n);
            Console.WriteLine();

            auto1.setEstadoInicial(0);

            Console.Write("ingrese el num del estados finales (AP 1): ");
            string f = Console.ReadLine();
            int nf = Convert.ToInt32(f);
            Console.WriteLine();

            for(int i=0;i<nf;i++)
            {
                Console.Write("ingrese el numero del estado final (AP 1): ");
                string ef = Console.ReadLine();
                int nef = Convert.ToInt32(ef);
                auto1.addEstadoFinal(nef);
                Console.WriteLine();
            }

            Console.Clear();

            Console.Write("ingrese el num total del alfabeto (AP 1): ");
            string tr = Console.ReadLine();
            int ntr = Convert.ToInt32(tr);
            auto1.settotalTransiciones(ntr);
            Console.WriteLine();

            for (int i = 0; i < ntr; i++)
            {
                Console.WriteLine("ingrese la transicion (AP 1): ");
                string trs = Console.ReadLine();
                auto1.addLetraAlfabeto(trs);
                Console.WriteLine();
            }

            Console.Write("Cuantas transiciones piensa realizar (AP 1): ");
            string nt = Console.ReadLine();
            int t = Convert.ToInt32(nt);

            int[] origen = new int[t];
            string[] lee = new string[t];
            int[] destino = new int[t];


            for (int i=0;i<t;i++)
            {
                Console.Write("la transicion empieza en (AP 1): ");
                string ei = Console.ReadLine();
                int nei = Convert.ToInt32(ei);
                origen[i] =nei;
                Console.WriteLine();

                Console.Write("la transicion se realiza con (AP 1): ");
                string transi = Console.ReadLine();
                lee[i] = transi;
                Console.WriteLine();

                Console.Write("la transicion termina en (AP 1): ");
                string ef = Console.ReadLine();
                int nef = Convert.ToInt32(ef);
                destino[i] = nef;
                Console.WriteLine();

                auto1.addTransicion(nei, transi, nef);
            }

            Console.Clear();

            AP auto2 = new AP();


            Console.Write("ingrese el num total de estados (AP 2): ");
            string v2 = Console.ReadLine();
            int n2 = Convert.ToInt32(v2);
            auto2.setnumEstados(n2);
            Console.WriteLine();

            auto2.setEstadoInicial(0);

            Console.Write("ingrese el num del estados finales (AP 2): ");
            string f2 = Console.ReadLine();
            int nf2 = Convert.ToInt32(f2);
            Console.WriteLine();

            for (int i = 0; i < nf2; i++)
            {
                Console.Write("ingrese el numero del estado final (AP 2): ");
                string ef2 = Console.ReadLine();
                int nef2 = Convert.ToInt32(ef2);
                auto2.addEstadoFinal(nef2);
                Console.WriteLine();
            }

            Console.Clear();

            Console.Write("ingrese el num total del alfabeto (AP 2): ");
            string tr2 = Console.ReadLine();
            int ntr2 = Convert.ToInt32(tr2);
            auto2.settotalTransiciones(ntr2);
            Console.WriteLine();

            for (int i = 0; i < ntr2; i++)
            {
                Console.WriteLine("ingrese la transicion (AP 2): ");
                string trs2 = Console.ReadLine();
                auto2.addLetraAlfabeto(trs2);
                Console.WriteLine();
            }

            Console.Write("Cuantas transiciones piensa realizar (AP 2): ");
            string nt2 = Console.ReadLine();
            int t2 = Convert.ToInt32(nt2);

            int[] origen2 = new int[t2];
            string[] lee2 = new string[t2];
            int[] destino2 = new int[t2];


            for (int i = 0; i < t2; i++)
            {
                Console.Write("la transicion empieza en (AP 2): ");
                string ei2 = Console.ReadLine();
                int nei2 = Convert.ToInt32(ei2);
                origen2[i] = nei2;
                Console.WriteLine();

                Console.Write("la transicion se realiza con (AP 2): ");
                string transi2 = Console.ReadLine();
                lee2[i] = transi2;
                Console.WriteLine();

                Console.Write("la transicion termina en (AP 2): ");
                string ef2 = Console.ReadLine();
                int nef2 = Convert.ToInt32(ef2);
                destino2[i] = nef2;
                Console.WriteLine();

                auto2.addTransicion(nei2, transi2, nef2);
            }

            Console.Clear();

            Console.WriteLine("AP 1");

            string strap1="";

            for (int i=0;i<auto1.getnumEstados();i++ )
            {
                for(int j=0;j<auto1.gettotalTransiciones();j++)
                {
                    strap1 = strap1+"[";
                    foreach (int tra in auto1.getTablaTransiciones()[i, j])
                    {
                        strap1 = strap1 + tra;
                    }
                    strap1 = strap1 + "]";
                }
                strap1 = strap1 + "\n";
            }
            Console.WriteLine(strap1);
            Console.ReadLine();

            Console.WriteLine("AP 2");

            string strap2 = "";

            for (int i = 0; i < auto2.getnumEstados(); i++)
            {
                for (int j = 0; j < auto2.gettotalTransiciones(); j++)
                {
                    strap1 = strap1 + "[";
                    foreach (int tra in auto2.getTablaTransiciones()[i, j])
                    {
                        strap2 = strap2 + tra;
                    }
                    strap2 = strap2 + "]";
                }
                strap2 = strap2 + "\n";
            }
            Console.WriteLine(strap2);
            Console.ReadLine();

            Console.WriteLine("La concatenacion es:");

            AP concatenacion = new concatenacion().concatenar(auto1,auto2,origen,lee,destino,origen2,lee2,destino2);

            foreach( string alf in concatenacion.getAlfabeto())
            {
                Console.Write(alf + "  ");
            }

            Console.WriteLine();

            string strapconca = "";

            for (int i = 0; i < concatenacion.getnumEstados(); i++)
            {
                for (int j = 0; j < concatenacion.gettotalTransiciones(); j++)
                {
                    strapconca = strapconca + "[";
                    foreach (int tra in concatenacion.getTablaTransiciones()[i, j])
                    {
                        strapconca = strapconca + tra;
                    }
                    strapconca = strapconca + "]";
                }
                strapconca = strapconca + "\n";
            }
            Console.WriteLine(strapconca);
            Console.ReadLine();

            Console.WriteLine("La union es:");

            AP union = new union().unir(auto1, auto2, origen, lee, destino, origen2, lee2, destino2);

            foreach (string alf in union.getAlfabeto())
            {
                Console.Write(alf + "  ");
            }

            Console.WriteLine();

            string strapunion = "";

            for (int i = 0; i < union.getnumEstados(); i++)
            {
                for (int j = 0; j < union.gettotalTransiciones(); j++)
                {
                    strapunion = strapunion + "[";
                    foreach (int tra in union.getTablaTransiciones()[i, j])
                    {
                        strapunion = strapunion + tra;
                    }
                    strapunion = strapunion + "]";
                }
                strapunion = strapunion + "\n";
            }
            Console.WriteLine(strapunion);
            Console.ReadLine();
        }
    }
}
