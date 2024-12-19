using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Dominio
{
    internal class Produktua
    {
        public virtual int Id { get; set; }
        public virtual string Izena { get; set; }
        public virtual string Deskribapena { get; set; }
        public virtual float Prezioa { get; set; }
        public virtual float ErosketaPrezioa { get; set; }
        public virtual int Kantitatea { get; set; }
        public virtual int KantitateMin { get; set; }
        public virtual int Mota { get; set; }
        public virtual int ErosketaKantitatea { get; set; }
        public virtual byte Aktibo { get; set; }


    }
}
