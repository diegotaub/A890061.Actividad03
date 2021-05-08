using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A890061.Actividad03
{
    public class Asiento
    {
        public Asiento(int nroasiento, DateTime fecha)
        {
            Fecha = fecha;
            NroAsiento = nroasiento;
            ListaDeMovimientos = new List<Movimiento>();
        }


        public int NroAsiento { get; set; }
        public DateTime Fecha { get; set; }
        public List<Movimiento> ListaDeMovimientos  { get; set; }
    }
}
