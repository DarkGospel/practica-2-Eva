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
        Última modificación: 19/02/2018
        Versión: 0.02
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
        /// </summary>
        /*****************************************************************/
        static string n, respuesta;
        static Aula datoaula = new Aula();
        public static List<Aula> NumAulas = new List<Aula>();
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
            } while (n != "0" && n != "1" && n != "2" && n != "3" && n != "4" && n != "5");

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
            } while(n != "0" && n != "1" && n != "2" && n != "3" && n != "4");
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
            
        }

        /*Funciones aulas*/

        //Verificar si hay repetidos
        static bool veriID(uint iden)
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

        //AULAS
        static void veraula()
        {
            Console.WriteLine(@" == Listado de Aulas ==
            Id.     Nombre      Nº Ordenadores      Fecha y hora modificación
            ===     =======     ==============      ===========================");
             for(int i=0; i<NumAulas.Count; i++)
            {
                Console.WriteLine("\t{0}\t{1}\t\t{2}", NumAulas[i].Pid, NumAulas[i].PnomA, NumAulas[i].PmodA );
            }
            Console.WriteLine("===================================================================");
            Console.WriteLine("Nº Aulas: ");
            Console.WriteLine("Nº Ordenadores: ");
            Console.ReadLine();
        }
        static void anyadiraulas()
        {
            uint aula;
            string nomaula;
            DateTime modificacion;
            for (int i=0; ;i++) {
                Console.Clear();
                Aula datoaula = new Aula();
                Console.WriteLine(" === Añadir Aulas ===");
                Console.Write("Identificador (0 ver lista de aulas): ");
                aula = uint.Parse(Console.ReadLine());
                if (aula == 0)
                {
                    veraula();
                }
                Console.Write("Nombre: ");
                nomaula = Console.ReadLine();
                /*Comprobación de identificadores o aulas repetidas*/
                //CORRECTA
                    if (veriID(aula) == false && veriNom(nomaula)== false)
                    {
                        Console.WriteLine("¡Introducción de aula correcta!");
                    }
                //AMBAS REPETIDAS
                    if(veriID(aula) == true && veriNom(nomaula)== true)
                    {
                        Console.WriteLine("¡NOMBRE E IDENTIFICADOR ERRONEOS!");
                        Console.ReadLine();
                        anyadiraulas();
                    }
                //ID REPETIDO
                    if(veriID(aula) == true && veriNom(nomaula)== false)
                    {
                        Console.WriteLine("¡Identificador introducido ya existe!");
                        Console.ReadLine();
                        anyadiraulas();
                    }
                //NOMBRE DE AULA REPETIDO
                    if(veriID(aula)==false && veriNom(nomaula)== true)
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
            aulas();
        }
        static void borraraula()
        {
            do
            {
                Console.Clear();
                uint identificador;
                Console.WriteLine(" === Borrar Aulas ===");
                Console.WriteLine("¿Quieres borrar un aula(S/N)?: ");
                respuesta = Console.ReadLine().ToUpper();
                if(respuesta == "N") { break; }
                Console.Write("Identificador (0 ver lista de aulas): ");
                identificador = uint.Parse(Console.ReadLine());
                if (identificador == 0)
                {
                    veraula();
                }
                for(int i=0; i < NumAulas.Count; i++)
                {
                    if(identificador == NumAulas[i].Pid)
                    {
                        NumAulas.RemoveAt(i);
                    }
                }
                
            } while (respuesta != "N");
            aulas();
        }
        static void modificaraula()
        {

        }

        /*ordenadores*/
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
            } while (n != "0" && n != "1" && n != "2" && n != "3" && n != "4" && n != "5");

            switch (n)
            {
                case "1":
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
                    ;
                    break;
                case "5":
                    /*Configuración()*/
                    ;
                    break;
                default:
                    break;
            }
        }
        /*Funciones ordenadores*/


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
            } while (n != "0" && n != "1" && n != "2" && n != "3");

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
                default:
                    break;
            }
        }
        /*Funciones configuracion*/
    }
}
