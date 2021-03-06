﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace t3
{
    public class AP
    {
        public int Id { get; set; }
        public int numEstados { get; set; }
        public int estadoInicial { get; set; }
        public int totalTransiciones { get; set; }
        public List<string> alfabt { get; set; }
        public List<int> finales { get; set; }
        public SortedSet<string> alfabeto = new SortedSet<string>();
        public SortedSet<int> estadosFinales;
        public SortedSet<int>[,] tablaTransiciones = new SortedSet<int>[1, 1];


        public AP() { }

        public AP(int nEstados, int eInicial, int tTransiciones, SortedSet<string> alfab, SortedSet<int>
            estadosFinals, SortedSet<int>[,] tblaTransiciones)
        {
            numEstados = nEstados;
            estadoInicial = eInicial;
            totalTransiciones = tTransiciones;
            alfabeto = alfab;
            estadosFinales = estadosFinals;
            tablaTransiciones = tblaTransiciones;
        }
        public string tabtostring(AP auto2) 
        {
            string strap2 = "";

            for (int i = 0; i < auto2.getnumEstados(); i++)
            {
                for (int j = 0; j < auto2.gettotalTransiciones(); j++)
                {
                    strap2 = strap2 + "[";
                    foreach (int tra in auto2.getTablaTransiciones()[i, j])
                    {
                        strap2 = strap2 + tra;
                    }
                    strap2 = strap2 + "]";
                }
                strap2 = strap2 + "\n";
            }
            Console.WriteLine("Se obtuvo la tabla de transiciones como string");
            return strap2;
        }
        public void setalf()
        {
            Console.WriteLine("seteo de alf");

            int con = alfabt.Count();
            for (int i = 0; i < con; i++)
            {
                addLetraAlfabeto(alfabt[i]);
            }
            Console.WriteLine("Se seteo el alfabeto");
        }
        public void setfin()
        { estadosFinales = new SortedSet<int>();
            for(int i = 0; i < finales.Count(); i++)
            {
                estadosFinales.Add(finales[i]);
            }
            Console.WriteLine("Se seteo el/los estado(s) final(es)");
        }
        public int getId()
        {
            return Id;

        }
        public int getnumEstados()
        {
            return numEstados;
        }

        public void setnumEstados(int nEstados)
        {
            this.numEstados = nEstados;
            Console.WriteLine("Se definio el numero de estados");
        }

        public int getEstadoInicial()
        {
            return estadoInicial;
        }

        public void setEstadoInicial(int q0)
        {
            this.estadoInicial = q0;
            Console.WriteLine("Se definio el estado inicial");
        }

        public int gettotalTransiciones()
        {
            return totalTransiciones;
        }

        public void settotalTransiciones(int nTransiciones)
        {
            this.totalTransiciones = nTransiciones;
            Console.WriteLine("Se definio el total de transiciones");
        }

        public SortedSet<string> getAlfabeto()
        {
            return alfabeto;
        }

        public void setAlfabeto(SortedSet<string> alfabet)
        {
            alfabeto = alfabet;
        }

        public SortedSet<int> getestadoFinal()
        {
            return estadosFinales;
        }

        public void setestadoFinal(SortedSet<int> qend)
        {
            estadosFinales = qend;
        }

        public SortedSet<int>[,] getTablaTransiciones()
        {
            Console.WriteLine("Se obtine la tabla de transiciones");
            return tablaTransiciones;
        }


        public void addEstadoFinal(int q)
        {
            estadosFinales.Add(q);
            Console.WriteLine("Se añadio un estado final");
        }

        public void addLetraAlfabeto(string letra)
        {
            alfabeto.Add(letra);
            tablaTransiciones = new SortedSet<int>[numEstados, totalTransiciones];
            iniciarTablaTransiciones();
            Console.WriteLine("Se añadio una letra al alfabeto");
        }

        private void iniciarTablaTransiciones()
        {
            for (int x = 0; x < numEstados; x++)
            {
                for (int y = 0; y < totalTransiciones; y++)
                {
                    tablaTransiciones[x, y] = new SortedSet<int>();
                }
            }
        }

        public void addTransicion(int q0, String e, int q1)
        {
            int cont = 0;
            int dif = 0;

            foreach (string trn in alfabeto)
            {
                if (trn != e && dif == 0)
                    cont++;
                if (trn == e)
                    dif++;
            }
            tablaTransiciones[q0, cont].Add(q1);
            Console.WriteLine("Se añadio una transicion");
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
