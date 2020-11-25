using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_pila
{
    class unir
    {
        Automata_pila unir(Automata_pila automata1, Automata_pila automata2)
        {
            Vector<String> alf = new Vector<String>();
            alf.addAll(automata1.getAlfabeto());
            if (alf.indexOf("@") == -1)
            {
                alf.add("@");
            }
            nombre = automata1.getNombre() + "+" + automata2.getNombre();
            numestados = automata1.getnumEstados() + automata2.getnumEstados() + 1;
            estadoInicial = 0;
            tabtrans = new TreeSet[numestados][alf.size()];
            tabtrans[0][alf.indexOf("@")].add(automata1.getEstadoInicial() + 1);
            tabtrans[0][alf.indexOf("@")].add(automata2.getEstadoInicial() + 1 + automata1.getnumEstados());
            for (int i = 0; i < automata1.getnumEstados(); i++)
            {
                for (int j = 0; j < alf.size(); j++)
                {
                    tabtrans[i + 1][j] = automata1.getTablaTransiciones()[i][j] + 1;
                }
            }
            for (int i = 0; i < automata2.getnumEstados(); i++)
            {
                for (int j = 0; j < alf.size(); j++)
                {
                    tabtrans[i + automata1.getnumEstados() + 1][j] = automata1.getTablaTransiciones()[i][j] + automata1.getnumEstados() + 1;
                }
            }
            Integer[] finales = new Integer[automata1.getestadoFinal().size()];
            finales = automata1.getestadoFinal().toArray(finales);
            for (int i = 0; i < automata1.getestadoFinal().size(); i++)
            {
                finales[i] = finales[i] + 1;
                estadoFinal.add(finales[i]);
            }
            finales = new Integer[automata2.getestadoFinal().size()];
            finales = automata2.getestadoFinal().toArray(finales);
            for (int i = 0; i < automata2.getestadoFinal().size(); i++)
            {
                finales[i] = finales[i] + automata1.getnumEstados() + 1;
                estadoFinal.add(finales[i]);
            }
            alfabeto = automata1.getAlfabeto();
            return new Automata(nombre, numestados, alfabeto, estadoInicial, estadoFinal, tabtrans);
        }
    }
}
