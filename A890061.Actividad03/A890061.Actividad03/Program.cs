using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A890061.Actividad03
{
    class Program
    {
        static void Main(string[] args)
        {

            string agregarAsiento;
            string agregarMovimiento = "1";
            int cantidadMovimientos;
            string codigoIngresado;
            bool existe;
            var CuentaElegida = new Cuenta();
            double montoIngresado;
            DateTime fechaIngresada;
            double debe = 0;
            double haber = 0;

            List<Cuenta> listadecuentas = PlanDeCuentas.LeerCuentas("Actividad 03 - Plan de cuentas.txt");
            var listadeasientos = new List<Asiento>();

            int MaxNroAsiento = Diario.ObtenerMaxNroAsiento("Diario.txt");
 

            Console.WriteLine("Bienvenido. Pulse la tecla correspondiente para continuar:");
            Console.WriteLine("1 - Agregar Asiento");
            Console.WriteLine("0 - Salir");

            agregarAsiento = Console.ReadLine();

            while(agregarAsiento != "1" && agregarAsiento != "0")
            {
                Console.Write("Opción incorrecta, ingrésela nuevamente: ");
                agregarAsiento = Console.ReadLine();
            }

            while(agregarAsiento == "1")
            {
                
                debe = 0;
                haber = 0;
                cantidadMovimientos = 1;
                Console.WriteLine($"Usted está agregando el asiento n° {MaxNroAsiento + 1} en el diario:");
                Console.Write("Ingrese la fecha del asiento (MM/DD/YYYY): ");
                while(!DateTime.TryParse(Console.ReadLine(), out fechaIngresada))
                {
                    Console.Write("No es una fecha correcta, ingrésela de nuevo: ");
                }

                var nuevoAsiento = new Asiento(MaxNroAsiento + 1, fechaIngresada);

                listadeasientos.Add(nuevoAsiento);
                agregarMovimiento = "1";
                while (agregarMovimiento == "1")
                {
                    var movimiento = new Movimiento();
                    nuevoAsiento.ListaDeMovimientos.Add(movimiento);
                    existe = false;
                    Console.Write($"Ingrese el código de cuenta del movimiento n° {cantidadMovimientos}: ");
                    codigoIngresado = Console.ReadLine();

                    while (!existe)
                    {
                        foreach (Cuenta cuenta in listadecuentas)
                        {
                            if (cuenta.Codigo == codigoIngresado)
                            {
                                existe = true;
                                movimiento.CodigoDeCuenta = cuenta.Codigo;
                                CuentaElegida.Nombre = cuenta.Nombre;
                                CuentaElegida.Tipo = cuenta.Tipo;


                                break;
                            }
                        }
                        if (existe)
                        {
                            break;
                        }

                        Console.Write("No existe una cuenta con ese código. Ingrese uno nuevamente: ");
                        codigoIngresado = Console.ReadLine();
                    }
                    Console.WriteLine($"Usted ha elegido la cuenta '{CuentaElegida.Nombre}'. Código: {movimiento.CodigoDeCuenta}. Tipo: {CuentaElegida.Tipo}.");
                    Console.Write($"Ingrese el monto a cargar. Para cargar una disminución, utilice un número negativo: ");

                    while (!(double.TryParse(Console.ReadLine(), out montoIngresado) && montoIngresado != 0))
                    {
                        Console.Write("El monto debe ser numérico distinto de 0, ingréselo nuevamente: ");
                    }
                    if (montoIngresado > 0)
                    {
                        if (CuentaElegida.Tipo == "Activo")
                        {
                            movimiento.Debe += montoIngresado;
                        }
                        else
                        {
                            movimiento.Haber += montoIngresado;
                        }
                    }
                    else
                    {
                        if (CuentaElegida.Tipo == "Activo")
                        {
                            movimiento.Haber += Math.Abs(montoIngresado);
                        }
                        else
                        {
                            movimiento.Debe += Math.Abs(montoIngresado);
                        }
                    }
                    cantidadMovimientos++;
                    Console.WriteLine($"Para agregar otro movimiento para el asiento n° {MaxNroAsiento + 1}, pulse 1.");
                    Console.WriteLine($"Para terminar el asiento n° {MaxNroAsiento + 1}, pulse 0.");

                    agregarMovimiento = Console.ReadLine();
                    while (agregarMovimiento != "1" && agregarMovimiento != "0")
                    {
                        Console.Write("Opción incorrecta, ingrésela nuevamente: ");
                        agregarMovimiento = Console.ReadLine();
                    }

                    
                        debe += movimiento.Debe;
                        haber += movimiento.Haber;
                    

                    if(agregarMovimiento == "0" && haber != debe)
                    {
                        Console.WriteLine($"El Debe ({debe}) no coincide con el Haber ({haber}).");
                        Console.WriteLine("Para terminar con el asiento debe ingresar nuevos movimientos para que los valores coincidan.");
                        agregarMovimiento = "1";
                    }
                    
                }

                MaxNroAsiento++;
                Console.WriteLine("Pulse la tecla correspondiente para continuar:");
                Console.WriteLine("1 - Agregar nuevo Asiento");
                Console.WriteLine("0 - Guardar y Salir");
                agregarAsiento = Console.ReadLine();
                while (agregarAsiento != "1" && agregarAsiento != "0")
                {
                    Console.Write("Opción incorrecta, ingrésela nuevamente: ");
                    agregarAsiento = Console.ReadLine();
                }

            }

            Diario.GuardarAsientos(listadeasientos, "Diario.txt");
            
          
        }
    }
}
