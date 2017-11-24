using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class cliente
    {
        public int id { get; set; }
        public string nombre{get;set;}
        public string paterno { get; set; }
        public string materno { get; set; }
        public int ci { get; set; }
        public int usuario { get; set; }
        public cliente() { }
        public cliente(int iid, string inombre,string ipaterno ,string imaterno, int ici,int iusuario)
        {
            this.id = iid;
            this.nombre = inombre;
            this.paterno = ipaterno;
            this.materno = imaterno;
            this.ci = ici;
            this.usuario = iusuario;
        }

    }
}
