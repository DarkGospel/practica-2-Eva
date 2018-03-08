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
    Última modificación: 27/02/2018
    Versión: 0.01.04
    ***********************************/
    /*.01 - Creacion de los atributos ID nombreaula modificacion*/
    /*.02 - Creacion del metodo leeraula*/
    /*.04 - Creacion de las variables publicas de aula*/
    class Aula
    {
        private int ID;
        private string nombreaula;
        private DateTime modificaaula;
        List<Ordenador> PCs;
        //metodo para introducir datos en aula
        public void LeerAulas(int id, string NOM, DateTime modiaula)
        {
            this.ID = id;
            this.nombreaula = NOM;
            this.modificaaula = modiaula;
        }
        public Aula() { } //constructor por defecto
        public Aula(int id, string nom, DateTime umod)//constructor para pruebas
        {
            this.ID = id;
            this.nombreaula = nom;
            this.modificaaula = umod;
            PCs = new List<Ordenador>();
        }
        public void agregarpc(string id, string cpu, float ram, string apli)
        {
            PCs.Add(new Ordenador(id, cpu, ram, apli, DateTime.Now, this.ID));
        }
        // variables publicas de aula
        public int Pid
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
