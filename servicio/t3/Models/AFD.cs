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
        public string[,] Trancision { get; set; }

        public AFD(int id, int estados, int inicial, List<int> finales, string[,] tabla)
        {
            Id = id;
            NEstados = estados;
            EInicial = inicial;
            EFinales = finales;
            Trancision= tabla;
            
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
            return Trancision;
        }

        public string ERegular(AFD automata)
        {
            string expresion="";
            Boolean iniciales=false;

            Boolean finales=false;

            int incial=automata.GetInicial();

            List<int> final = automata.GetEsFinales();

            int numestados = automata.GetNumEstado();
            expresion = expresion + numestados + "/";

            string[,] trancisiones= new string[numestados,numestados];
            if (automata.GetTabTrans()[automata.GetInicial(), automata.GetInicial()] != "")
            {
               iniciales = true;
            }
            for (int i = 0; i < automata.GetEsFinales().Count(); i++)
            {
                for (int j = 0; j < automata.GetNumEstado(); j++)
                {
                    if (automata.GetTabTrans()[final[i], j] != "")
                    {
                        finales = true;
                    }
                }
            }
            if (iniciales != false)
            {
                expresion = expresion + automata.GetTabTrans()[0, 0]+".";
                numestados += 1;
                expresion = expresion + numestados + "//";
                if (finales != false)
                {
                    
                    numestados += 1;
                    expresion = expresion + numestados + "///";
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
                expresion = expresion + trancisiones[1, 1]+"///////";
            }
            else
            {
                if (finales != false)
                {
                    
                    numestados += 1;
                    expresion = expresion+ numestados + "////";
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


            /*while (numestados>2 )
             {
                 trancisiones = Eliminarestado(0, 1, 2, trancisiones, numestados);
                 numestados -= 1;                
                 using (StreamWriter w = File.AppendText("log.txt"))
                 {
                     Log(con+"indice", w);
                 }
                 con += 1;
             }*/
            expresion = "";
            //expresion = expresion + "/1/" +  trancisiones[0, numestados-1] + "*/";
            trancisiones = Eliminarestado(0, 1, 2, trancisiones, numestados);
            numestados -= 1;
            //expresion = expresion + "/2/" +  trancisiones[0, 1] + "*/";
            trancisiones = Eliminarestado(0, 1, 2, trancisiones, numestados);
            numestados -= 1;
            //expresion = expresion + "/3/" + trancisiones[0, 1] + "*/";
            trancisiones = Eliminarestado(0, 1, 2, trancisiones, numestados);
            numestados -= 1;
            expresion = expresion + "/4/" + trancisiones[0, 1] + "/4/";
            trancisiones = Eliminarestado(0, 1, 2, trancisiones, numestados);
            //expresion = expresion + "/5/" + trancisiones[0, numestados - 2]+"/5/";
            /*for (int i=0; i < trancisiones[0, 1].Count(); i++)
                {
                if(trancisiones[0, 1].Substring(i, 0) !=";")
                {
                    trancisiones[0, 1] = trancisiones[0, 1].Substring(i, 0);
                }
            }*/
            expresion = trancisiones[0, 1];
            return expresion;
        }
        public string[,] Eliminarestado(int origen, int eliminar, int destino, string[,] trancisiones, int numestados)
        {
            string[,] nuevatrancision= new string[numestados - 1, numestados - 1];

            nuevatrancision[0, 1] = trancisiones[0, 1];

            if (trancisiones[eliminar, eliminar]!=null)
            {
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
            /*if (trancisiones[eliminar, numestados-1]!=null)
            {              
                for(int i=0;i< trancisiones[eliminar, numestados - 1].Count(); i++)
                {
                    if (i == 0)
                    {   
                        nuevatrancision[0, numestados-2] = nuevatrancision[0, 1] + ";(";
                        nuevatrancision[0, numestados - 2] = nuevatrancision[0,1] +trancisiones[eliminar, numestados-1].Substring(i, 1);
                        if(i == trancisiones[eliminar, eliminar].Count() - 1)
                        {
                            nuevatrancision[0, 1] = nuevatrancision[0, 1] + ")";
                        }
                    }
                    else
                    {
                        if (i == trancisiones[eliminar, eliminar].Count() - 1)
                        {
                            nuevatrancision[0, numestados - 2] = nuevatrancision[0, 1] + trancisiones[eliminar, numestados-1].Substring(i, 1);
                            nuevatrancision[0, numestados - 2] = nuevatrancision[0, 1] + ")";
                        }
                        else
                        {
                            nuevatrancision[0, numestados - 2] = nuevatrancision[0, 1] + trancisiones[eliminar, numestados-1].Substring(i, 1);
                        }
                    }
                }

            }*/
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
                nuevatrancision[0, numestados - 2] = trancisiones[0, numestados - 1] + ";("+trancisiones[0,1]+")" + trancisiones[eliminar, numestados - 1] + ")"; 
            }
            if (numestados == 3)
            {
                nuevatrancision[0, 1] = nuevatrancision[0, 1] + trancisiones[0, numestados - 1];
            }
            return nuevatrancision;
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
