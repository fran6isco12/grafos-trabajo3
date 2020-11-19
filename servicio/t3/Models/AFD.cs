using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace t3
{
    public class AFD
    {
        public string Nombre { get; set; }
        public int NEstados { get; set; }
        public int EInicial { get; set; }
        public List<int> EFinales { get; set; }
        public string[,] Trancision { get; set; }

        public AFD(string name, int estados, int inicial, List<int> finales, string[,] tabla)
        {
            Nombre = name;
            NEstados = estados;
            EInicial = inicial;
            EFinales = finales;
            Trancision= tabla;
            
        }

        public string GetNombre()
        {
            return Nombre;

        }

        public int GetNumEstado()
        {
            return NEstados;
        }

        public List<int> GetEsFinales()
        {
            return EFinales;
        }

        public int GetInicial()
        {
            return EInicial;
        }

        public string[,] GetTabTrans()
        {
            return Trancision;
        }

        public string ERegular(AFD automata)
        {
            string expresion;
            Boolean iniciales=false;
            Boolean finales=false;
            int incial=automata.GetInicial();
            List<int> final = automata.GetEsFinales();
            int numestados = automata.GetNumEstado();
            string[,] transiciones= new string[numestados,numestados];
            for (int i = 0; i < automata.GetNumEstado(); i++)
            {
                if (automata.GetTabTrans()[i,automata.GetInicial()] != "")
                {
                    iniciales = true;
                }
            }

            for(int i = 0; i < automata.GetEsFinales().Count();i++) 
            {
                for(int j = 0; j > automata.GetNumEstado(); j++)
                {
                    if (automata.GetTabTrans()[j,i] != "")
                    {
                        finales = true;
                    }
                }
            }
            if (iniciales != false)
            {
                numestados += 1;
                if (finales != false)
                {
                    transiciones = new string[numestados, numestados];
                    numestados += 1;
                    for(int i = 0; i < final.Count(); i++)
                    {
                        transiciones[final[i]+1, numestados - 1]="E";
                        final.Clear();
                        final.Add(numestados - 1);
                    }
                }
                else
                {
                    transiciones = new string[numestados, numestados];
                }
                transiciones[0, automata.GetInicial() + 1] = "E";
                for(int i = 1; i < automata.GetNumEstado(); i++)
                {
                    for (int j = 0; j < automata.GetNumEstado(); j++)
                    {
                        transiciones[i + 1, j + 1] = automata.GetTabTrans()[i, j];
                    }
                }
            }
            else
            {
                if (finales != false)
                {
                    transiciones = new string[numestados, numestados];
                    numestados += 1;
                    for (int i = 0; i < final.Count(); i++)
                    {
                        transiciones[final[i] + 1, numestados - 1] = "E";
                        final.Clear();
                        final.Add(numestados - 1);
                    }
                }
            }


            return expresion;
        }
        public string[,] Eliminarestado(int origen, int eliminar,int destino, String[,] trancisiones,int numestados)
        {
            String[,] nuevatrancision= new String[numestados - 1, numestados - 1];
            nuevatrancision[0, 1] = trancisiones[0, 1];
            for(int i = 0; i < trancisiones[eliminar, eliminar].Count(); i++)
            {
                
                if(trancisiones[eliminar, eliminar].Substring(i, 1) != "")
                {
                    if (i == 0)
                    {
                        nuevatrancision[0, 1] = nuevatrancision[0, 1] + "(";
                        nuevatrancision[0, 1] = nuevatrancision[0, 1]+[eliminar, eliminar].Substring(i, 1);
                    }

                    else
                    {
                        if (trancisiones[eliminar, eliminar].Substring(i, 1) != ",")
                        {
                            nuevatrancision[0, 1] = nuevatrancision[0, 1] + "+";
                        }
                        else
                        {
                            if (i == trancisiones[eliminar, eliminar].Count() - 1)
                            {
                                nuevatrancision[0, 1] = nuevatrancision + nuevatrancision[eliminar, eliminar].Substring(i, 1);
                                nuevatrancision[0, 1] = nuevatrancision[0, 1] + ")*";
                            }
                            else
                            {
                                nuevatrancision[0, 1] = nuevatrancision + nuevatrancision[eliminar, eliminar].Substring(i, 1);
                            }
                        }
                    }
                }
            }
            for(int i = 0; i < trancisiones[eliminar, destino].Count(); i++)
            {
                if (trancisiones[eliminar, destino].Substring(i, 1) != "")
                {
                    if (i == 0)
                    {
                        nuevatrancision[0, 1] = nuevatrancision[0, 1] + "(";
                        nuevatrancision[0, 1] = nuevatrancision[0, 1] +[eliminar, eliminar].Substring(i, 1);
                    }

                    else
                    {
                        if (trancisiones[eliminar, eliminar].Substring(i, 1) != ",")
                        {
                            nuevatrancision[0, 1] = nuevatrancision[0, 1] + "+";
                        }
                        else
                        {
                            if (i == trancisiones[eliminar, eliminar].Count() - 1)
                            {
                                nuevatrancision[0, 1] = nuevatrancision + nuevatrancision[eliminar, eliminar].Substring(i, 1);
                                nuevatrancision[0, 1] = nuevatrancision[0, 1] + ")*";
                            }
                            else
                            {
                                nuevatrancision[0, 1] = nuevatrancision + nuevatrancision[eliminar, eliminar].Substring(i, 1);
                            }
                        }
                    }
                }
            

        }

    }
}
