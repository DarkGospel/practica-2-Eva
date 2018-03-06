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
    Última modificación: 14/02/2018
    Versión: 0.01
    ***********************************/
    class Ordenador
    {
        private uint IDordenador;
        private DateTime modificadorOrd;
        private uint aulaasign;
        private float ram;
        private float hdd;
        private string procesador;
        private string tarjetagraf;
        private string aplicaciones;
        
        public Ordenador(uint id, DateTime umod, uint aula)
        {
            this.IDordenador = id;
            this.modificadorOrd = umod;
            this.aulaasign = aula;

        }

    }
}
