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
        private string IDordenador;
        private DateTime modificadorOrd;
        private uint aulaasign;
        private float ram;
        private float hdd;
        private string procesador;
        private string tarjetagraf;
        private string aplicaciones;
        
        public Ordenador(string id, DateTime umod, uint aula, float RAM, float disco, string cpu, string grafica)
        {
            this.IDordenador = id;
            this.modificadorOrd = umod;
            this.aulaasign = aula;
            this.ram = RAM;
            this.hdd = disco;
            this.procesador = cpu;
            this.tarjetagraf = grafica;
        }

    }
}
