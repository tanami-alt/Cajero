using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    internal class ArchivoHelper
    {
        private static string usuariosfile = "usuarios.txt";

        public static list<usuario> leerusuarios()
        {
            var usuarios = new list<usuario>();
            if (file.exists(usuariosfile))
            {
                var lineas = file.readalllines(usuariosfile);
                foreach (var linea in lineas)
                {
                    var datos = linea.split(';');
                    usuarios.add(new usuario
                    {
                        numerocuenta = datos[0],
                        clave = datos[1],
                        saldo = decimal.parse(datos[2])
                    });
                }
            }
            //        return usuarios;
            //    }

            //    public static void GuardarUsuarios(List<Usuario> usuarios)
            //    {
            //        var lineas = new List<string>();
            //        foreach (var usuario in usuarios)
            //        {
            //            lineas.Add($"{usuario.NumeroCuenta};{usuario.Clave};{usuario.Saldo}");
            //        }
            //        File.WriteAllLines(usuariosFile, lineas);
            //    }

            //    public static void GuardarMovimiento(string numeroCuenta, Movimiento mov)
            //    {
            //        string archivoMov = $"movimientos_{numeroCuenta}.txt";
            //        File.AppendAllText(archivoMov, mov.ToString() + Environment.NewLine);
            //    }

            //    public static List<Movimiento> LeerMovimientos(string numeroCuenta)
            //    {
            //        var movimientos = new List<Movimiento>();
            //        string archivoMov = $"movimientos_{numeroCuenta}.txt";
            //        if (File.Exists(archivoMov))
            //        {
            //            var lineas = File.ReadAllLines(archivoMov);
            //            foreach (var linea in lineas)
            //            {
            //                var datos = linea.Split(';');
            //                movimientos.Add(new Movimiento
            //                {
            //                    Fecha = DateTime.Parse(datos[0]),
            //                    Tipo = datos[1],
            //                    Valor = decimal.Parse(datos[2])
            //                });
            //            }
            //        }
            //        return movimientos;
            //    }
            //}
        }
