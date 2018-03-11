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
        private int aulaasign;
        private float ram;
        private float hdd;
        private string procesador;
        private string tarjetagraf;
        private string aplicaciones;
        
        /// <summary>
        /// Constructor de ordenadores.
        /// </summary>
        /// <param name="id"> numero de pc</param>
        /// <param name="umod"> ultima modificacion </param>
        /// <param name="aula"> identificador del aula</param>
        /// <param name="RAM"> ram guardada</param>
        /// <param name="disco"> disco y tamaño</param>
        /// <param name="cpu"> procesador </param>
        /// <param name="grafica"> tarjeta grafica</param>
        public Ordenador(string id, DateTime umod, int aula, float RAM, float disco, string cpu, string grafica, string apli)
        {
            this.IDordenador = id;
            this.modificadorOrd = umod;
            this.aulaasign = aula;
            this.ram = RAM;
            this.hdd = disco;
            this.procesador = cpu;
            this.tarjetagraf = grafica;
            this.aplicaciones = apli;
        }
       
        
        public string PidO
        {
            get
            {
                return IDordenador;
            }
            set
            {
                IDordenador = value;
            }
        }
        public int PidA
        {
            get
            {
                return aulaasign;
            }
            set
            {
                aulaasign = value;
            }
        }
        public DateTime UmodO
        {
            get
            {
                return modificadorOrd;
            }
            set
            {
                modificadorOrd = value;
            }
        }
    }
}
