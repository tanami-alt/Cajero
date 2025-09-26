using CajeroAutomatico;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Cajero cajero = new Cajero();

            Console.WriteLine("=== Bienvenido al Cajero ===");
            Console.Write("Ingrese su número de cuenta: ");
            string cuenta = Console.ReadLine() ?? "";
            Console.Write("Ingrese su clave: ");
            string clave = Console.ReadLine() ?? "";

            if (cajero.IniciarSesion(cuenta, clave))
            {
                Console.WriteLine("¡Acceso exitoso!");
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
                    
                    if (int.TryParse(Console.ReadLine(), out opcion))
                    {
                        switch (opcion)
                        {
                            case 1:
                                Console.Write("Ingrese valor a depositar: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal dep))
                                {
                                    cajero.Depositar(dep);
                                    Console.WriteLine("Depósito realizado exitosamente.");
                                }
                                else
                                {
                                    Console.WriteLine("Valor inválido.");
                                }
                                break;
                            case 2:
                                Console.Write("Ingrese valor a retirar: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal ret))
                                {
                                    cajero.Retirar(ret);
                                }
                                else
                                {
                                    Console.WriteLine("Valor inválido.");
                                }
                                break;
                            case 3:
                                cajero.ConsultarSaldo();
                                break;
                            case 4:
                                cajero.ConsultarMovimientos();
                                break;
                            case 5:
                                Console.Write("Ingrese nueva clave: ");
                                string nuevaClave = Console.ReadLine() ?? "";
                                cajero.CambiarClave(nuevaClave);
                                Console.WriteLine("Clave cambiada exitosamente.");
                                break;
                            case 6:
                                Console.WriteLine("Gracias por usar el cajero.");
                                break;
                            default:
                                Console.WriteLine("Opción inválida.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Por favor ingrese un número válido.");
                    }

                } while (opcion != 6);
            }
            else
            {
                Console.WriteLine("Credenciales incorrectas. Acceso denegado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        
        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}
