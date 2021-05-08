using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A890061.Actividad03
{
    public class Cuenta
    {
        public Cuenta(string codigo, string nombre, string tipo)
        {
            Codigo = codigo;
            Nombre = nombre;
            Tipo = tipo;
        }

        public Cuenta()
        {

        }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }


    }
}
