using CajeroAutomatico;

class Program
{
    static void Main(string[] args)
    {
        Cajero cajero = new Cajero();

        Console.WriteLine("=== Bienvenido al Cajero ===");
        Console.Write("Ingrese su número de cuenta: ");
        string cuenta = Console.ReadLine();
        Console.Write("Ingrese su clave: ");
        string clave = Console.ReadLine();

        if (cajero.IniciarSesion(cuenta, clave))
        {
            int opcion;
            do
            {
                Console.WriteLine("\n--- Menú Cajero ---");
                Console.WriteLine("1. Depósito");
                Console.WriteLine("2. Retiro");
                Console.WriteLine("3. Consulta de saldo");
                Console.WriteLine("4. Últimos 5 movimientos");
                Console.WriteLine("5. Cambio de clave");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese valor a depositar: ");
                        decimal dep = decimal.Parse(Console.ReadLine());
                        cajero.Depositar(dep);
                        break;
                    case 2:
                        Console.Write("Ingrese valor a retirar: ");
                        decimal ret = decimal.Parse(Console.ReadLine());
                        cajero.Retirar(ret);
                        break;
                    case 3:
                        cajero.ConsultarSaldo();
                        break;
                    case 4:
                        cajero.ConsultarMovimientos();
                        break;
                    case 5:
                        Console.Write("Ingrese nueva clave: ");
                        string nuevaClave = Console.ReadLine();
                        cajero.CambiarClave(nuevaClave);
                        break;
                    case 6:
                        Console.WriteLine("Gracias por usar el cajero.");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

            } while (opcion != 6);
        }
        else
        {
            Console.WriteLine("Credenciales incorrectas. Acceso denegado.");
        }
    }
}
