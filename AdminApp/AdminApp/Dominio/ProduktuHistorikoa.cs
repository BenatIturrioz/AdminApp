using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Dominio
{
    internal class ProduktuHistorikoa
    {
        public virtual int Id { get; set; }
        public virtual int ProduktuaId { get; set; }
        public virtual int ErabiltzaileaId { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual string Ekintza { get; set; }
        public virtual byte? Galera { get; set; }
    }
}
