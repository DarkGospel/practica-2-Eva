using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_2ªEva
{
    class Program
    {
        /*********************************
        Autor: Juan Manuel Silva Cerrejón
        Fecha creación: 14/02/2018
        Última modificación: 05/03/2018
        Versión: 0.7
        ***********************************/
        /// <summary>
        /// MODIFICACIONES DE PROGRAM.CS
        /// 
        /// En la modificación del 15/02/2018
        /// Se han creado los menús.
        /// El menú busqueda se tiene que hacer por iniciativa del alumno
        /// 
        /// Modificacion del 19/02/2018
        /// Se han creado atributos y metodos en la clase aula
        /// Se han añadido subfunciones a la funcion aula, son veraula, anyadiraula, borraraula.
        /// Se procederá a hacer funcionar la primera parte de aula con objetos.
        /// Empezamos github
        /// 
        /// Modificacion 26/02/2018
        /// Rehacer parte de la ultima modifacion por borrado inesperado.
        /// 
        /// Modificacion 27/02/2018
        /// Terminada la comprobacion de ID y Nombres de aula repetidos
        /// Finalizada la funcion de borrar un aula
        /// 
        /// Modificacion 05/03/2018
        /// Terminada la parte de la funcion aulas.
        /// Comienzo con el material de parte grafica.
        /// </summary>
        /*****************************************************************/
        static string n, respuesta;
        static Aula datoaula = new Aula();
        static List<Aula> NumAulas = new List<Aula>();
        static List<Ordenador> NumOrd = new List<Ordenador>();
        static List<Aula> Aula_Ord = new List<Aula>();
        static List<Ordenador> Ordenador_Ord = new List<Ordenador>();
        /*****************************************************************/
        static void Main()
        {
            menu();
        }
        static void menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine(@"        === GESTIÓN DE ORDENADORES ===
            1. Aulas/Salas del centro.
            2. Ordenadores.
            3. Búsquedas.
            4. Listados.
            5. Configuración.
            0. Salir.");

                Console.Write(" Elegir opción: ");
                n = Console.ReadLine();
            switch (n)
            {
                case "1":
                    aulas();
                    break;
                case "2":
                    ordenadores();
                    break;
                case "3": 
                    busquedas();
                    break;
                case "4": 
                    listados();
                    break;
                case "5":
                    configuracion();
                    break;
                default:
                    break;
            }
            } while (n != "0");
        }
        static void aulas()
        {
            do
            {
                Console.Clear();
                Console.WriteLine(@"        === Aulas ===
            1. Ver aulas.
            2. Añadir Aula.
            3. Borrar Aula.
            4. Modificar Aula
            0. Volver al menú principal");

                Console.Write("Elegir opción: ");
                n = Console.ReadLine();
            
            switch (n)
            {
                case "1":
                    veraula();
                    break;
                case "2":
                    anyadiraulas();
                    break;
                case "3":
                    borraraula();
                    break;
                case "4":
                    modificaraula();
                    break;
                case "0":
                    menu();
                    break;
                default:
                    aulas();
                    break;
            }
            } while (n != "0" );
        }

        /*Funciones aulas*/

        //Verificar si hay repetidos
        static bool veriID(int iden)
        {
            for (int i=0; i<NumAulas.Count; i++) {
                if (iden == NumAulas[i].Pid)
                {
                    return true;
                }
            }
            return false;
        }
        static bool veriNom(string nom)
        {
            for(int i=0; i<NumAulas.Count; i++)
            {
                if(nom == NumAulas[i].PnomA)
                {
                    return true;
                }
            }
            return false;
        }

        //AULAS("Terminada")
        static void veraula()
        {
            Console.Clear();
            Console.WriteLine(@"                                == Listado de Aulas ==
            
            Id.         Nombre      Nº Ordenadores      Fecha y hora modificación
            ===         =======     ==============      ==========================");
             for(int i=0; i<NumAulas.Count; i++)
            {
                int cont = 0;
                for (int u=0; u<NumOrd.Count; u++)
                {
                    if (NumOrd[u].PidA == NumAulas[i].Pid)
                    {
                        cont++;
                    }
                }
                Console.WriteLine("\t      {0} \t{1}\t\t{2}\t\t{3}", NumAulas[i].Pid, NumAulas[i].PnomA, cont, NumAulas[i].PmodA );
            }
            Console.WriteLine("\t   =======================================================================");
            Console.WriteLine("\nNº Aulas: {0}", NumAulas.Count);
            Console.WriteLine("Nº Ordenadores: {0}", NumOrd.Count);
            Console.ReadKey();
        }
        static void anyadiraulas()
        {
            int aula;
            string nomaula;
            DateTime modificacion;
            for (int i=0; ;i++) {
                Console.Clear();
                Aula datoaula = new Aula();
                Console.WriteLine(" === Añadir Aulas ===");
                Console.Write("Identificador (0 ver lista de aulas): ");
                    if (NumAulas.Count >= max)
                    {
                        Console.WriteLine("¡Error! Número maximo de aulas introducido");
                        Console.ReadKey();
                        break;
                    }

                aula = int.Parse(Console.ReadLine());
                    if (aula == 0)
                    {
                        veraula();
                        continue;
                    }
                    Console.Write("Nombre: ");
                    nomaula = Console.ReadLine();
                    /*Comprobación de identificadores o aulas repetidas*/
                    //CORRECTA
                    if (veriID(aula) == false && veriNom(nomaula) == false)
                    {
                        Console.WriteLine("¡Introducción de aula correcta!");
                    }
                    //AMBAS REPETIDAS
                    if (veriID(aula) == true && veriNom(nomaula) == true)
                    {
                        Console.WriteLine("¡NOMBRE E IDENTIFICADOR ERRONEOS!");
                        Console.ReadLine();
                        anyadiraulas();
                    }
                    //ID REPETIDO
                    if (veriID(aula) == true && veriNom(nomaula) == false)
                    {
                        Console.WriteLine("¡Identificador introducido ya existe!");
                        Console.ReadLine();
                        anyadiraulas();
                    }
                    //NOMBRE DE AULA REPETIDO
                    if (veriID(aula) == false && veriNom(nomaula) == true)
                    {
                        Console.WriteLine("¡El nombre introducido ya existe!");
                        Console.ReadLine();
                        anyadiraulas();
                    }
                
              
                //Continuamos con la funcion
                modificacion = DateTime.Now;

                

                //datos introducidos en lista y objeto
                datoaula.LeerAulas(aula, nomaula, modificacion);                
                NumAulas.Add(datoaula);
                
                Console.Write("¿más aulas(S/N)?: ");
                respuesta = Console.ReadLine().ToUpper();
                if(respuesta == "N")
                {
                    break;
                }
            }
            
        }
        static void borraraula()
        {
            
            do
            {
                Console.Clear();
                int identificador;
                Console.WriteLine(" === Borrar Aulas ===");
                
                Console.Write("Identificador (0 ver lista de aulas): ");
                identificador = int.Parse(Console.ReadLine());
                if (identificador == 0)
                {
                    veraula();
                }
                if (veriID(identificador) == false && identificador != 0)
                {
                    Console.Write("¡El identificador no existe!");
                    Console.ReadKey();
                }
                int cont = 0;
                for (int u = 0; u < NumOrd.Count; u++)
                {
                    if(identificador== NumOrd[u].PidA)
                    {
                        cont++;
                    }
                }
                for (int i = 0; i <NumAulas.Count; i++)
                {
                    for (int u = 0; u <NumOrd.Count; u++)
                    {
                        if (identificador == NumAulas[i].Pid)
                        {
                            string respuesta2;
                            Console.WriteLine("Se procedera a borrar el aula: {0}", NumAulas[i].PnomA);
                            Console.WriteLine("Esta aula tiene {0} ordenadores que serán también eliminados.", cont);
                            Console.WriteLine("¿desea continuar borrando el aula (S/N)?  ");
                            respuesta2 = Console.ReadLine().ToUpper();
                            if (respuesta2 == "S")
                            {
                                Console.WriteLine(".........{0} borrada", NumAulas[i].PnomA);
                                NumAulas.RemoveAt(i);
                                NumOrd.RemoveAt(u);
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.WriteLine(".............. No se ha borrado el aula");
                                Console.ReadKey();
                                break;
                            }
                        }
                }
                }
                Console.WriteLine("¿Quieres borrar mas aula(S/N)?: ");
                respuesta = Console.ReadLine().ToUpper();
                if (respuesta == "N") { break; }

            } while (respuesta != "N");
            
        }
        static void modificaraula()
        {
            do
            {
                Console.Clear();
                DateTime modificador = DateTime.Now;
                int identificador;
                string nuevaA;
                Console.WriteLine(" === Modificar Aulas ===");
                Console.WriteLine("¿Quieres modificar un aula(S/N)?: ");
                respuesta = Console.ReadLine().ToUpper();
                if (respuesta == "N") { break; }
                Console.Write("Identificador (0 ver lista de aulas): ");
                identificador = int.Parse(Console.ReadLine());
                if (identificador == 0)
                {
                    veraula();
                }

                for (int i = 0; i < NumAulas.Count; i++)
                {
                    if (veriID(identificador) == false && identificador != 0)
                    {
                        Console.Write("¡El identificador no existe!");
                        Console.ReadKey();
                        
                    }else if(identificador == NumAulas[i].Pid)
                    {
                        Console.WriteLine("Nombre de aula antigua: {0}", NumAulas[i].PnomA);
                        Console.Write("Nombre del aula nueva: ");
                        nuevaA = Console.ReadLine();
                        NumAulas[i].PnomA = nuevaA;
                        NumAulas[i].PmodA = modificador;
                    }
                }

            } while (respuesta != "N");
            
        }

        /*ORDENADORES*/
        static void ordenadores()
        {
            do
            {
                Console.Clear();
                Console.WriteLine(@"        === GESTIÓN DE ORDENADORES ===
            1. Ver lista de ordenadores. 
            2. Añadir ordenador.
            3. Borrar ordenador.
            4. Cambiar ordenador de aula.
            5. Modificar ordenador.
            0. Volver al menú principal.");

                Console.Write(" Elegir opción: ");
                n = Console.ReadLine();
            
            switch (n)
            {
                case "1":
                    verordenador();
                    break;
                case "2":
                    addordenador();
                    break;
                case "3":
                    borrarordenador();
                    break;
                case "4":
                    cambiarUO();
                    break;
                case "5":
                    modificarO();
                    break;
                case "0":
                    menu();
                    break;
                default:
                    break;
            }
            } while (n != "0");
        }
        /*Funciones ordenadores*/
        static bool veriNom2(string nom)
        {
            for (int i = 0; i < NumOrd.Count; i++)
            {
                if (nom == NumOrd[i].PidO)
                {
                    return true;
                }
            }
            return false;
        }
        static void verordenador()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("=== Lista de Ordenadores ===");
            Console.SetCursorPosition(6, 4);
            Console.WriteLine("Id.      Aula        F.Creación");
            Console.WriteLine("========  =============  =====================");

            for (int i = 0; i < NumOrd.Count; i++)
            {
                Console.WriteLine("{0}      \t{1}     \t  {2}", NumOrd[i].PidO, NumOrd[i].PidA, NumOrd[i].UmodO);
            }
            Console.ReadKey();

        }
        static void addordenador()
        {
            int aula;
            string ordenador, procesador, grafica, aplicaciones;
            float ram, hdd;
            DateTime modificacion;
            for (int i = 0; ; i++)
            {
                Console.Clear();
                
                Console.WriteLine(" === Añadir Ordenador ===");
                Console.Write("Identificador Ordenador (0 ver lista de ordeandores): ");
                ordenador = Console.ReadLine();
                if (ordenador == "0")
                {
                    verordenador();
                }
                if(NumOrd.Count >= maxord)
                {
                    Console.WriteLine("¡ERROR! Máximo de ordenadores introducidos");
                    Console.ReadKey();
                    break;
                }
                /*Comprobación de identificadores repetidos*/

                //CORRECTA
                if (veriNom(ordenador) == false)
                {
                    Console.WriteLine("¡Introducción de ID correcto!");
                }

                //REPETIDo
                if (veriNom(ordenador) == true)
                {
                    Console.WriteLine("¡IDENTIFICADOR ERRONEO!");
                    Console.ReadLine();
                    anyadiraulas();
                }

                Console.Write("Id. aula en la que se encuentra: ");
                aula = int.Parse(Console.ReadLine());                                          //Identificador AULA

                Console.WriteLine("Introduzca las caracteristicas del <{0}>", ordenador);
                Console.Write("RAM: ");
                ram = float.Parse(Console.ReadLine());

                Console.Write("\nDisco duro: ");
                hdd = float.Parse(Console.ReadLine());

                Console.Write("\nProcesador: ");
                procesador = Console.ReadLine();

                Console.Write("\nTarjeta Gráfica: ");
                grafica = Console.ReadLine();

                /*Aplicaciones de ordenador (Buscar manera de guardar separados por ,)*/
                Console.Write("\nAplicaciones: ");
                aplicaciones = Console.ReadLine();

                //Modificación
                modificacion = DateTime.Now;

                //datos introducidos en lista y objeto
                NumOrd.Add(new Ordenador(ordenador, modificacion, aula, ram, hdd, procesador, grafica, aplicaciones));

                Console.Write("¿más ordenadores(S/N)?: ");
                respuesta = Console.ReadLine().ToUpper();
                if (respuesta == "N")
                {
                    break;
                }
            }
        }
        static void borrarordenador()
        {
            do
            {
                Console.Clear();
                string identificador;
                Console.WriteLine(" === Borrar Ordenador ===");
                Console.WriteLine("¿Quieres borrar un ordenador(S/N)?: ");
                respuesta = Console.ReadLine().ToUpper();
                if (respuesta == "N") { break; }
                Console.Write("Identificador (0 ver lista de ordenadores): ");
                identificador = Console.ReadLine().ToUpper();
                if (identificador == "0")
                {
                    verordenador();
                }
                if (veriNom2(identificador) == false && identificador != "0")
                {
                    Console.Write("¡El identificador no existe!");
                    Console.ReadKey();
                }
                for (int i = 0; i < NumOrd.Count; i++)
                {                   
                    if (identificador == NumOrd[i].PidO)
                    {
                        string respuesta2;
                        
                        for (int u = 0; u < NumAulas.Count; u++)
                        {
                            if (NumOrd[i].PidA == NumAulas[u].Pid)
                            {
                                Console.WriteLine("Se procedera a borrar el ordenador <{0}> situado en el <{1}>", NumOrd[i].PidO, NumAulas[u].PnomA);
                                Console.WriteLine("¿desea continuar borrando el ordenador (S/N)?  ");
                                respuesta2 = Console.ReadLine().ToUpper();
                                if (respuesta2 == "S")
                                {
                                    Console.WriteLine(".........{0} borrado correctamente", NumOrd[i].PidO);
                                    NumOrd.RemoveAt(i);
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine(".............. No se ha borrado el ordenador");
                                    Console.ReadKey();
                                    break;
                                }
                            }
                        }
                    }
                }

            } while (respuesta != "N");
        }
        static void cambiarUO()
        {
            do
            {
                string identificador;
                int idaula;
                Console.WriteLine(" === Cambiar Ubicacion Ordenador ===");
                Console.Write("Identificador (0 ver lista de ordenadores): ");
                identificador = Console.ReadLine();
                if (identificador == "0")
                {
                    verordenador();
                }

                for (int i = 0; i < NumOrd.Count; i++)
                {
                    if (identificador == NumOrd[i].PidO)
                    {
                        string cont;

                        for (int u = 0; u < NumAulas.Count; u++)
                        {
                            if (NumOrd[i].PidA == NumAulas[u].Pid)
                            {
                                cont = NumAulas[u].PnomA;
                                Console.WriteLine("Seleccionado {0} situado en <{1}>", NumOrd[i].PidO, cont);

                                Console.Write("Seleccione nueva ubicación (0 lista aulas): ");
                                idaula = int.Parse(Console.ReadLine());
                                if (idaula == 0)
                                {
                                    veraula();
                                }
                                if (veriID(idaula) == false && idaula != 0)
                                {
                                    Console.Write("¡El aula no existe!");
                                    Console.ReadKey();
                                }
                                if (veriID(idaula) == true && idaula != 0)
                                {
                                    NumOrd[i].PidA = idaula;
                                    cont = NumAulas[idaula - 1].PnomA;
                                    Console.WriteLine(".... El ordenador {0} se ha movido correctamente al <{1}>", NumOrd[i].PidO, cont);
                                }
                            }
                        }
                    }
                }
                Console.Write("¿Mover más (S/N)? ");
                respuesta = Console.ReadLine().ToUpper();
                if (respuesta == "N") { break; }
            } while (respuesta != "N");
        }
        static void modificarO()
        {
            Console.Clear();
            string identificador, respuesta2, nuevoID, nuevaApli, nuevaCpu, nuevaGpu;
            float nuevaRam, nuevoDisco;
            do
            {
                Console.WriteLine("====== MODIFICAR ORDENADOR =======");
                Console.WriteLine("Identificador de ordenador (0 ver lista ordenadores): ");
                identificador = Console.ReadLine().ToUpper();
                if (identificador == "0")
                {
                    verordenador();
                }
                if (veriNom2(identificador) == false && identificador != "0")
                {
                    Console.Write("¡El identificador no existe!");
                    Console.ReadKey();
                }
                Console.WriteLine("¿Desea modificar su identificador (S/N)? ");
                respuesta2 = Console.ReadLine().ToUpper();
                for (int i = 0; i < NumOrd.Count; i++)
                {
                    if (identificador == NumOrd[i].PidO)
                    {
                        if (respuesta2 == "S")
                        {
                            Console.Write("Introduce el nuevo identificador: ");
                            nuevoID = Console.ReadLine().ToUpper();
                            NumOrd[i].PidO = nuevoID;
                            NumOrd[i].UmodO = DateTime.Now;
                        }
                        else
                        if (respuesta2 == "N")
                        {
                            Console.WriteLine("El ordenador se encuentra en el aula con ID <{0}>", NumOrd[i].PidA);
                            Console.Write("Modifique las características  del <{0}> (en blanco se mantienen)", NumOrd[i].PidO);
                            Console.Write("\nRAM <{0} GB>: ", NumOrd[i].PRAM);
                            nuevaRam = float.Parse(Console.ReadLine().ToString());
                            NumOrd[i].PRAM = nuevaRam;
                            Console.Write("\nDisco duro < {0} GB>: ", NumOrd[i].PHDD);
                            nuevoDisco = float.Parse(Console.ReadLine());
                            NumOrd[i].PHDD = nuevoDisco;
                            Console.Write("\nProcesador < {0} >: ", NumOrd[i].PCPU);
                            nuevaCpu = Console.ReadLine();
                            if(nuevaCpu != string.Empty)
                            {
                                NumOrd[i].PCPU = nuevaCpu;
                            }
                            Console.Write("\nTarjeta Gráfica: ", NumOrd[i].PGPU);
                            nuevaGpu = Console.ReadLine();
                            if (nuevaGpu != string.Empty)
                            {
                                NumOrd[i].PGPU = nuevaGpu;
                            }
                            Console.WriteLine("\nModifique las aplicaciones (separadas por comas) del <{0}> (en blanco se mantienen) <{1}>: ", NumOrd[i].PidO, NumOrd[i].PAPLI);
                            nuevaApli = Console.ReadLine();
                            if (nuevaApli != string.Empty)
                            {
                                NumOrd[i].PAPLI = nuevaApli;
                            }
                            NumOrd[i].UmodO = DateTime.Now;
                        }
                    }
                }
                Console.Write("¿Más ordenadores (S/N)? ");
                respuesta = Console.ReadLine().ToUpper();
            } while (respuesta != "N");
        }

        /*busquedas*/
        static void busquedas(){ }
        /*Funciones busquedas*/


        /*listados*/
        static void listados()
        {
            do
            {
                Console.Clear();
                Console.WriteLine(@"        === LISTADOS ===
            1. Nº ordenadores por aula.
            2. Lista de ordenadores ordenados por aula e identificador.
            3. Aplicaciones instaladas por cada ordenador.
            4. Características de cada ordenador.
            0. Volver al menú principal.");

                Console.Write(" Elegir opción: ");
                n = Console.ReadLine();
            

            switch (n)
            {
                case "1":
                    nordAula();
                    break;
                case "2":
                    listordAula();
                    break;
                case "3":
                    listApli();
                    break;
                case "4":
                    caracOrd();
                    break;
                case "0":
                    menu();
                    break;
                default:
                    break;
            }
            } while (n != "0");
        }
        /*Funciones listados*/
        static void nordAula()
        {
            int n = 0;
            Console.Clear();
            Console.WriteLine("=== LISTA DE AULAS ordenadas ===");
            Console.WriteLine("Id.              Nombre              NºOrdenadores");
            Console.WriteLine("=====           =============        ===============");
            Aula_Ord = NumAulas.OrderBy(Aula => Aula.PnomA).ToList();
            for (int i=0; i < Aula_Ord.Count; i++)
            {
                n++;
                int cont = 0;
                for (int u = 0; u < NumOrd.Count; u++)
                {
                    if (NumAulas[i].Pid == NumOrd[u].PidA)
                    {
                        cont++;
                    }
                }
                Console.WriteLine("{0}\t\t{1}\t\t\t{2}", Aula_Ord[i].Pid, Aula_Ord[i].PnomA, cont);
                n++;
                if (n == 8 && Aula_Ord.Count > 8)
                {
                    Console.WriteLine("Pulsa para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    n = 0;
                }
                
            }
            Console.ReadKey();
        }
        static void listordAula()
        {
            int n = 0;
            Console.Clear();
            Console.WriteLine("             === LISTADO DE ORDENADORES ORDENADOS POR AULA E IDENT. ===");
            Console.WriteLine("Id.            Aula                  Aplicaciones");
            Console.WriteLine("=======        =========             =================================");
            Aula_Ord = NumAulas.OrderBy(Aula => Aula.PnomA).ToList();
            Ordenador_Ord = NumOrd.OrderBy(Ordenador => Ordenador.PidO).ToList(); 
            for (int i = 0; i < Aula_Ord.Count; i++)
            {
                for (int u = 0; u < Ordenador_Ord.Count; u++)
                {
                    if (Aula_Ord[i].Pid == Ordenador_Ord[u].PidA)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t\t{2}", NumOrd[u].PidO, NumAulas[i].PnomA, NumOrd[u].PAPLI);
                        n++;
                        if (n == 8 && NumOrd.Count > 8)
                        {
                            Console.WriteLine("Pulsa para continuar");
                            Console.ReadKey();
                            Console.Clear();
                            n = 0;
                        }
                        
                    }
                   
                }
            }
            Console.WriteLine("======================================================================");
            Console.Write("Nº Ordenadores: {0}", NumOrd.Count);
            Console.ReadKey();
        }
        static void listApli()
        {
            int n = 0;
            Console.Clear();
            Console.WriteLine("=== APLICACIONES INSTALADAS POR ORDENADOR ===");
            Console.WriteLine("Id.     Aplicaciones");
            Console.WriteLine("====    ========================================");
            Ordenador_Ord = NumOrd.OrderBy(Ordenador => Ordenador.PidO).ToList();
            for (int i = 0; i < Ordenador_Ord.Count; i++)
            {
                Console.WriteLine("{0}      {1}", NumOrd[i].PidO, NumOrd[i].PAPLI);
                n++;
                if (n == 8 && NumOrd.Count > 8)
                {
                    Console.WriteLine("Pulsa para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    n = 0;
                }
            }
            Console.WriteLine("=================================================");
            Console.WriteLine("Nº Ordenadores: {0}", NumOrd.Count);
            Console.ReadKey();
        }
        static void caracOrd()
        {
            int n = 0;
            Console.Clear();
            Console.WriteLine("=== CARACTERÍSTICAS POR ORDENADOR ===");
            Console.WriteLine("Id.      RAM          Disco D.       T. Gráf     \t\tProces.     \tAlta/Mod.");
            Console.WriteLine("=====    ==========   ==========     ========    \t\t========    \t=========");
            for (int i = 0; i < NumOrd.Count; i++)
            {
                Console.WriteLine("{0}      {1}          {2}           {3}          {4}         {5}", NumOrd[i].PidO, NumOrd[i].PRAM, NumOrd[i].PHDD, NumOrd[i].PGPU, NumOrd[i].PCPU, NumOrd[i].UmodO);
                n++;
                if (n == 8 && NumOrd.Count > 8)
                {
                    Console.WriteLine("Pulsa para continuar");
                    Console.ReadKey();
                    Console.Clear();
                    n = 0;
                }
            }
            Console.WriteLine("===============================================================================================================");
            Console.WriteLine("Nº Ordenadores: {0}", NumOrd.Count);
            Console.ReadLine();
        }

        /*configuracion*/
        static void configuracion()
        {
            do
            {
                Console.Clear();
                Console.WriteLine(@"        === CONFIGURACIÓN ===
            1. Número máximo de aulas.
            2. Número máximo de ordenadores por aula.
            3. Inicialización automática para pruebas.
            0. Volver al menú principal.");

                Console.Write(" Elegir opción: ");
                n = Console.ReadLine();
            
            switch (n)
            {
                case "1":
                    maxaulas();
                    break;
                case "2":
                    Maxord();
                    break;
                case "3":
                    pruebas();
                    break;
                case "0":
                    menu();
                    break;
                default:
                    break;
            }
            } while (n != "0");
        }
        /*Funciones configuracion*/
        static int max = 5;
        static int maxord = 15;
        static int maxaulas()
        {
            string respuesta2;
            Console.WriteLine("Valor maximo de aulas por defecto {0}", max);
            Console.WriteLine("¿Quieres cambiar el valor (S/N)?");
            respuesta2 = Console.ReadLine().ToUpper();
            if (respuesta2 == "S")
            {
                Console.Write("Nuevo valor maximo de aulas: ");
                max = int.Parse(Console.ReadLine());
            }
            else { }
            Console.ReadKey();
            return max;
        }
        static int Maxord()
        {
            string respuesta2;
            Console.WriteLine("Valor maximo de ordenadores en aulas por defecto {0}", maxord);
            Console.WriteLine("¿Quieres cambiar el valor (S/N)?");
            respuesta2 = Console.ReadLine().ToUpper();
            if (respuesta2 == "S")
            {
                Console.Write("Nuevo valor maximo de aulas: ");
                maxord = int.Parse(Console.ReadLine());
            }
            else { }
            Console.ReadKey();
            return maxord;
        }
        static void pruebas()
        {
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                NumAulas.Add(new Aula(i + 1, $"Aula {i + 1}", DateTime.Now));
            }
                NumOrd.Add(new Ordenador ( "PC 01", DateTime.Now, 1, 8, 500, "intel core i5", "Intel Graphics", "W7, Office 2010, Chrome"));
                NumOrd.Add(new Ordenador("PC 02", DateTime.Now, 2, 8, 500, "intel core i5", "Intel Graphics", "W7, Office 2010, Chrome"));
                NumOrd.Add(new Ordenador("PC 03", DateTime.Now, 4, 8, 500, "intel core i5", "Intel Graphics", "W7, Office 2010, Chrome"));
                NumOrd.Add(new Ordenador("PC 04", DateTime.Now, 5, 8, 500, "intel core i5", "Intel Graphics", "W7, Office 2010, Chrome"));
                NumOrd.Add(new Ordenador("PC 05", DateTime.Now, 3, 4, 500, "intel celeron", "Intel Graphics", "Ubuntu 14, Gedit, LibreOffice 5"));
                NumOrd.Add(new Ordenador("PC 06", DateTime.Now, 3, 4, 500, "intel celeron", "Intel Graphics", "Ubuntu 14, Gedit, LibreOffice 5"));
                NumOrd.Add(new Ordenador("PC 07", DateTime.Now, 3, 4, 500, "intel celeron", "Intel Graphics", "Ubuntu 14, Gedit, LibreOffice 5"));
                NumOrd.Add(new Ordenador("PC 08", DateTime.Now, 3, 4, 500, "intel celeron", "Intel Graphics", "Ubuntu 14, Gedit, LibreOffice 5"));

            Console.WriteLine("Se han creado aulas y ordenadores correctamente.");
            Console.ReadKey();
            
        }
    }
}
