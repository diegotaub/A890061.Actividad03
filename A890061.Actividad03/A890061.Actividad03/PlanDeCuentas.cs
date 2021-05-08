using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A890061.Actividad03
{
    public static class PlanDeCuentas
    {
        public static List<Cuenta> LeerCuentas(string nombreArchivo)
        {

            var listadecuentas = new List<Cuenta>();
            foreach (string cuenta in File.ReadAllLines($@"{Environment.CurrentDirectory}\{nombreArchivo}").Skip(1))
            {
                string codigo = cuenta.Split('|')[0];
                string nombre = cuenta.Split('|')[1];
                string tipo = cuenta.Split('|')[2];
                listadecuentas.Add(new Cuenta(codigo, nombre, tipo));
            }

            return listadecuentas;
        }
    }
}
