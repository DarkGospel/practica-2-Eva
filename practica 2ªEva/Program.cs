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
        Versión: 0.52
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
        public static List<Aula> NumAulas = new List<Aula>();
        public static List<Ordenador> NumOrd = new List<Ordenador>();
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
        static void borraraula()//falta modificar
        {
            do
            {
                Console.Clear();
                int identificador;
                Console.WriteLine(" === Borrar Aulas ===");
                Console.WriteLine("¿Quieres borrar un aula(S/N)?: ");
                respuesta = Console.ReadLine().ToUpper();
                if(respuesta == "N") { break; }
                Console.Write("Identificador (0 ver lista de aulas): ");
                identificador = int.Parse(Console.ReadLine());
                if (identificador == 0)
                {
                    veraula();
                }
                
                for (int i=0; i < NumAulas.Count; i++)
                {
                    if (veriID(identificador) == false && identificador != 0)
                    {
                        Console.Write("¡El identificador no existe!");
                        Console.ReadKey();
                        
                    }else
                    if (identificador == NumAulas[i].Pid)
                    {
                        NumAulas.RemoveAt(i);
                    }
                }
                
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
                    /*Configuración()*/
                    ;
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
        static void borrarordenador()//falta modificar
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
                identificador = Console.ReadLine();
                if (identificador == "0")
                {
                    verordenador();
                }

                for (int i = 0; i < NumOrd.Count; i++)
                {
                    if (veriNom(identificador) == false && identificador != "0")
                    {
                        Console.Write("¡El identificador no existe!");
                        Console.ReadKey();
                    }
                    else
                    if (identificador == NumOrd[i].PidO)
                    {
                        NumOrd.RemoveAt(i);
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
                        
                        for (int u = 0; u < NumAulas.Count; u++) {
                            if(NumOrd[i].PidA == NumAulas[u].Pid)
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
                                    cont = NumAulas[u].PnomA;
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
            } while (n != "0" && n != "1" && n != "2" && n != "3" && n != "4");

            switch (n)
            {
                case "1":
                    aulas();
                    break;
                case "2":
                    /*ordenadores()*/
                    ;
                    break;
                case "3":
                    /*busqueda()*/
                    ;
                    break;
                case "4":
                    /*Listados()*/
                    break;
                default:
                    break;
            }
        }
        /*Funciones listados*/


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
                    
                    break;
                case "2":
                    
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
        static void pruebas()
        {
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

            /*NumAulas[1].agregarpc("PC02", "Intel i5", 8, "W7, Office 2010, Chrome");
            NumAulas[3].agregarpc("PC03", "Intel i5", 8, "W7, Office 2010, Chrome");
            NumAulas[4].agregarpc("PC04", "Intel i5", 8, "W7, Office 2010, Chrome");
            NumAulas[2].agregarpc("PC05", "Intel celeron", 4, "Ubuntu 14, Gedit, LibreOffice 5");
            NumAulas[2].agregarpc("PC05", "Intel celeron", 4, "Ubuntu 14, Gedit, LibreOffice 5");
            NumAulas[2].agregarpc("PC06", "Intel celeron", 4, "Ubuntu 14, Gedit, LibreOffice 5");
            NumAulas[2].agregarpc("PC07", "Intel celeron", 4, "Ubuntu 14, Gedit, LibreOffice 5");
            NumAulas[2].agregarpc("PC08", "Intel celeron", 4, "Ubuntu 14, Gedit, LibreOffice 5");*/



        }
    }
}
