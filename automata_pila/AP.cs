﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Automata_pila
{
    class AP
    {
        int numEstados;
        int estadoInicial;
        int totalTransiciones;
        SortedSet<string> alfabeto;
        SortedSet<int> estadosFinales;
        SortedSet<int>[,] tablaTransiciones;

        public AP()
        {
            alfabeto = new SortedSet<string>();
            estadosFinales = new SortedSet<int>();
        }

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

        public int getnumEstados()
        {
            return numEstados;
        }

        public void setnumEstados(int nEstados)
        {
            this.numEstados = nEstados;
        }

        public int getEstadoInicial()
        {
            return estadoInicial;
        }

        public void setEstadoInicial(int q0)
        {
            this.estadoInicial = q0;
        }

        public int gettotalTransiciones()
        {
            return totalTransiciones;
        }

        public void settotalTransiciones(int nTransiciones)
        {
            this.totalTransiciones = nTransiciones;
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
            return tablaTransiciones;
        }

        public void setTablaTransiciones(SortedSet<int>[,] tblaTransiciones)
        {
            tablaTransiciones = tblaTransiciones;
        }

        public void addEstadoFinal(int q)
        {
            estadosFinales.Add(q);
        }

        public void addLetraAlfabeto(string letra)
        {
            alfabeto.Add(letra);
            tablaTransiciones = new SortedSet<int>[numEstados,totalTransiciones];
            iniciarTablaTransiciones();
        }

        private void iniciarTablaTransiciones()
        {
            for (int x = 0; x < numEstados; x++)
            {
                for (int y = 0; y < totalTransiciones; y++)
                {
                    tablaTransiciones[x,y] = new SortedSet<int>();
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
            tablaTransiciones[q0,cont].Add(q1);
        }
    }
}
