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
        /// En la modificación del 15/02/2018
        /// Se han creado los menús.
        /// El menú busqueda se tiene que hacer por iniciativa del alumno
        /// 
        /// Modificacion del 19/02/2018
        /// Se han creado atributos y metodos en la clase aula
        /// Se han añadido subfunciones a la funcion aula, son veraula, anyadiraula, borraraula.
        /// Se procederá a hacer funcionar la primera parte de aula con objetos.
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
                    /*busqueda()*/
                    ;
                    break;
                case "4":
                    /*Listados()*/
                    ;
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
        static void veraula()
        {

        }
        static void anyadiraulas()
        {
            int aula;
            string nomaula;
            DateTime modificacion;
            do
            {
                Console.WriteLine(" === Añadir Aulas ===");
                Console.Write("Identificador (0 ver lista de aulas): ");
                aula = int.Parse(Console.ReadLine());
                if(aula == 0)
                {
                    veraula();
                    break;
                }
                Console.Write("Nombre: ");
                nomaula = Console.ReadLine();
                modificacion = DateTime.Now;

                Console.Write("¿más aulas(S/N)?: ");
                respuesta = Console.ReadLine().ToUpper();
                
            } while (respuesta != "N");
            aulas();
        }
        static void borraraula()
        {
            do
            {
                int identificador;
                Console.WriteLine(" === Borrar Aulas ===");
                Console.Write("Identificador (0 ver lista de aulas): ");
                identificador = int.Parse(Console.ReadLine());
                if (identificador == 0)
                {
                    veraula();
                }
                Console.WriteLine("¿borrar más (S/N)?: ");
                respuesta = Console.ReadLine().ToUpper();
            } while (respuesta != "N");
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
