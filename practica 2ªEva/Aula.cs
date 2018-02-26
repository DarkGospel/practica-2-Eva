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
        private uint ID;
        private string nombreaula;
        private DateTime modificaaula;
       
        public void LeerAulas(uint id, string NOM, DateTime modiaula)
        {
            this.ID = id;
            this.nombreaula = NOM;
            this.modificaaula = modiaula;
        }
        public uint Pid
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
        public string PnomA
        {
            get
            {
                return nombreaula;
            }
            set
            {
                nombreaula = value;
            }
        }
        public DateTime PmodA
        {
            get
            {
                return modificaaula;
            }
            set
            {
                modificaaula = value;
            }
        }
    }
}
