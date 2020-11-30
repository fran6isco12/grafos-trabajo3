using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace t3
{
    public class AFD
    {   
        public int Id { get; set; }
        public int NEstados { get; set; }
        public int EInicial { get; set; }
        public List<int> EFinales { get; set; }
        public List<string> tab { get; set; }

        public AFD() { }
        public AFD(int id, int estados, int inicial, List<int> finales, List<string> tabla)
        {
            Id = id;
            NEstados = estados;
            EInicial = inicial;
            EFinales = finales;
            tab= tabla;
            
        }

        public string[,] tabtotran()
        {
            Log("ingresa trancisiones a la tabla", File.AppendText("logafd.txt"));
            int con = 0;
            string[,] Trancision = new string[NEstados, NEstados];
            for(int i = 0; i < NEstados; i++)
            {
                for(int j = 0; j < NEstados; j++)
                {
                    if (con < tab.Count())
                    {
                        Trancision[i, j] = tab[con];
                        con += 1;
                    }
                }
            }
            
            return Trancision;
        }

        public int Getid()
        {
            
            return Id;

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
            
            return tabtotran();
        }

        public string ERegular(AFD automata)
        {
            Log("iniciando expresion regular", File.AppendText("logafd.txt"));
            string expresion="";
            Boolean iniciales=false;

            Boolean finales=false;

            int incial=automata.GetInicial();

            List<int> final = automata.GetEsFinales();

            int numestados = automata.GetNumEstado();

            string[,] trancisiones= new string[numestados,numestados];
            if (automata.GetInicial()<automata.GetNumEstado()&&automata.GetTabTrans()[automata.GetInicial(), automata.GetInicial()] != "")
            {
                Log("comprobando estado inicial", File.AppendText("logafd.txt"));
                iniciales = true;
            }
            for (int i = 0; i < automata.GetEsFinales().Count(); i++)
            {
                for (int j = 0; j < automata.GetNumEstado(); j++)
                {
                    if (automata.GetTabTrans()[final[i], j] != "")
                    {
                        Log("comprobando estados finales", File.AppendText("logafd.txt"));
                        finales = true;
                    }
                }
            }
            Log("agregando trancisiones", File.AppendText("logafd.txt"));
            if (iniciales != false)
            {

                numestados += 1;
                if (finales != false)
                {
                    
                    numestados += 1;

                    trancisiones = new string[numestados, numestados];
                    for (int i = 0; i < final.Count(); i++)
                    {
                        trancisiones[final[i] + 1, numestados - 1] = "E";
                    }
                }
                else
                {
                    trancisiones = new string[numestados, numestados];
                }
                trancisiones[0, automata.GetInicial() + 1] = "(E";
                for (int i = 0; i < automata.GetNumEstado(); i++)
                {
                    for (int j = 0; j < automata.GetNumEstado(); j++)
                    {
                        trancisiones[i + 1, j + 1] = automata.GetTabTrans()[i, j];
                    }
                }
            }
            else
            {
                if (finales != false)
                {
                    
                    numestados += 1;
                    trancisiones = new string[numestados, numestados];
                    for (int i = 0; i < final.Count(); i++)
                    {
                        trancisiones[final[i] + 1, numestados - 1] = "E";
                    }
                    for (int i = 0; i < automata.GetNumEstado(); i++)
                    {
                        for (int j = 0; j < automata.GetNumEstado(); j++)
                        {
                            trancisiones[i + 1, j + 1] = automata.GetTabTrans()[i, j];
                        }
                    }
                }
                else
                {
                    trancisiones = automata.GetTabTrans();
                }
            }
            Log("procesado de er", File.AppendText("logafd.txt"));
            for (int i = numestados; i > 2; i--)
            {
                
                trancisiones = Eliminarestado(0, 1, 2, trancisiones, i);                    
            }
            Log("limpiezxa y estandarizado de la er", File.AppendText("logafd.txt"));
            string extr="";
            expresion = trancisiones[0, 1];
            if (expresion.Contains(";"))
            {
               
                for (int i = 0; i < expresion.Count();i++)
                {
                    if (expresion.Substring(i,1)==";")
                    {
                        extr = extr + "+";
                    }
                    else
                    {
                        if (expresion.Substring(i, 1) == "E")
                        {
                            Console.WriteLine("elimina E");
                        }
                        else {
                            extr = extr + expresion.Substring(i, 1);
                        }
                    }
                }
            }
            else
            {
                extr = expresion;
                expresion = "";
            }
            if (extr.Contains("()"))
            {
                expresion = "";
                for(int i = 0; i < extr.Count(); i++)
                {
                    if ((i+2)<extr.Count()&&extr.Substring(i, 2) == "()")
                    {
                        i += 1;
                    }
                    else
                    {
                        expresion = expresion + extr.Substring(i, 1);
                    }
                }
                extr = expresion;
            }
            Log("retornando er:"+extr, File.AppendText("logafd.txt"));
            return extr;
        }
        public string[,] Eliminarestado(int origen, int eliminar, int destino, string[,] trancisiones, int numestados)
        {
            Log("inicio de la eliminacion de estados", File.AppendText("logafd.txt"));
            string[,] nuevatrancision= new string[numestados - 1, numestados - 1];

            nuevatrancision[0, 1] = trancisiones[0, 1];

            if (trancisiones[eliminar, eliminar]!=null)
            {
                Log("eliminando trancisiones de n. a eliminar sobre si mismo", File.AppendText("logafd.txt"));
                for (int i = 0; i < trancisiones[eliminar, eliminar].Count(); i++)
                {
                    if (i == 0)
                    {
                        nuevatrancision[0, 1] = nuevatrancision[0, 1] + "(";
                        nuevatrancision[0, 1] = nuevatrancision[0, 1] + trancisiones[eliminar, eliminar].Substring(i, 1);
                    }

                    else
                    {
                        if (trancisiones[eliminar, eliminar].Substring(i, 1) == ",")
                        {
                            nuevatrancision[0, 1] = nuevatrancision[0, 1] + "+";
                        }
                        else
                        {
                            if (i == trancisiones[eliminar, eliminar].Count() - 1)
                            {
                                if (i == 0)
                                {
                                    nuevatrancision[0, 1] = nuevatrancision[0, 1] + "(";
                                }
                                nuevatrancision[0, 1] = nuevatrancision[0,1] + trancisiones[eliminar, eliminar].Substring(i, 1);
                                nuevatrancision[0, 1] = nuevatrancision[0, 1] + ")*";
                            }
                            else
                            {
                                nuevatrancision[0, 1] = nuevatrancision[0,1] + trancisiones[eliminar, eliminar].Substring(i, 1);
                            }
                        }
                    }

                }
            }
            if (trancisiones[eliminar, destino]!= null)
            {
                Log("eliminando trancision de n a eliminar que apuntan n destino", File.AppendText("logafd.txt"));
                for (int i = 0; i < trancisiones[eliminar, destino].Count(); i++)
                {
                    if (i == 0)
                    {   
                        nuevatrancision[0, 1] = nuevatrancision[0, 1] + "(";
                        nuevatrancision[0, 1] = nuevatrancision[0, 1] + trancisiones[eliminar, destino].Substring(i, 1);
                        if (i == trancisiones[eliminar, destino].Count() - 1)
                        {
                            nuevatrancision[0, 1] = nuevatrancision[0, 1] + ")";
                        }
                    }

                    else
                    {
                        if (trancisiones[eliminar, destino].Substring(i, 1) == ",")
                        {
                            nuevatrancision[0, 1] = nuevatrancision[0, 1] + "+";
                        }
                        else
                        {
                            if (i == trancisiones[eliminar, destino].Count() - 1)
                            {
                                if (i == 0)
                                {
                                    nuevatrancision[0, 1] = nuevatrancision[0, 1] + "(";
                                    nuevatrancision[0, 1] = nuevatrancision[0, 1] + trancisiones[eliminar, destino].Substring(i, 1);
                                    nuevatrancision[0, 1] = nuevatrancision[0, 1] + ")";
                                }
                                else
                                {
                                    nuevatrancision[0, 1] = nuevatrancision[0, 1] + trancisiones[eliminar, destino].Substring(i, 1);
                                    nuevatrancision[0, 1] = nuevatrancision[0, 1] + ")";
                                }
                            }
                            else
                            {
                                nuevatrancision[0, 1] = nuevatrancision[0,1] + trancisiones[eliminar, destino].Substring(i, 1);
                            }
                        }
                    }

                }
            }
            
            for (int i = 1; i < numestados-1; i++)
            {
               for(int  j = 1; j < numestados - 1; j++)
                {
                    nuevatrancision[i, j] = trancisiones[i + 1, j + 1];

                }
            }
            nuevatrancision[0, 1] = nuevatrancision[0, 1] + ")";
            if (trancisiones[eliminar, numestados - 1]!=null&&numestados!=3)
            {
                Log("eliminando trancision de n a eliminar que apuntan hacia el nodo final", File.AppendText("logafd.txt"));
                nuevatrancision[0, numestados - 2] = trancisiones[0, numestados - 1] + ";("+trancisiones[0,1]+")" + trancisiones[eliminar, numestados - 1] + ")"; 
            }
            if (numestados == 3)
            {
                nuevatrancision[0, 1] = nuevatrancision[0, 1] + trancisiones[0, numestados - 1];
            }
            Log("retornando nueva tabla", File.AppendText("logafd.txt"));
            return nuevatrancision;
        }
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
            w.Close();
        }
    }


}
