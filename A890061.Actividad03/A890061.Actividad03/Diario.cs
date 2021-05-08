using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A890061.Actividad03
{
    public static class Diario
    {
        public static int ObtenerMaxNroAsiento(string nombreArchivo)
        {

            var listadeNroDeAsientos = new List<int>();
            if (File.Exists($@"{Environment.CurrentDirectory}\{nombreArchivo}"))
            {
                foreach (string asiento in File.ReadAllLines($@"{Environment.CurrentDirectory}\{nombreArchivo}"))
                {
                    int NroAsiento = Convert.ToInt32(asiento.Split('|')[0]);
                    listadeNroDeAsientos.Add(NroAsiento);
                    
                }
                return listadeNroDeAsientos[listadeNroDeAsientos.Count - 1];
            }
            else
            {
                return 0;
            }            

        }

        public static void GuardarAsientos(List<Asiento> listadeasientos, string nombreArchivo)
        {

            foreach (Asiento asiento in listadeasientos)
            {
                foreach(Movimiento movimiento in asiento.ListaDeMovimientos)
                {
                    File.AppendAllText($@"{Environment.CurrentDirectory}\{nombreArchivo}",
                    $"{asiento.NroAsiento}|{asiento.Fecha.ToString("d")}|{movimiento.CodigoDeCuenta}|" +
                    $"{movimiento.Debe}|{movimiento.Haber}" + Environment.NewLine);
                }
                
            }

        }
    }
}
