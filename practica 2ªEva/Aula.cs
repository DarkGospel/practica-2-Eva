using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_2ªEva
{
    /*********************************
    Autor: Juan Manuel Silva Cerrejón
    Fecha creación: 14/02/2018
    Última modificación: 19/02/2018
    Versión: 0.01.02
    ***********************************/
    /*.01 - Creacion de los atributos ID nombreaula*/
    /*.02 - Creacion de los metodos nombreaula, leeraula*/
    class Aula
    {
        private int ID;
        private string nombreaula;
        public void VerAulas()
        {
            Console.WriteLine(@" == Listado de Aulas ==
            Id.     Nombre      Nº Ordenadores      Fecha y hora modificación
            ===     =======     ==============      ===========================

            {0}     {1}               {2}                       {3}

            ===================================================================
            Nº Aulas: {4}
            Nº Ordenadores: {5}", ID, nombreaula);

        }
        public void LeerAulas()
        {
            
        }

    }
}
