using System;
using System.Collections.Generic;
using System.Linq;

namespace CajeroAutomatico
{
    internal class Cajero
    {
        private Usuario? usuarioActual;
        private List<Usuario> usuarios;

        public Cajero()
        {
            usuarios = ArchivoHelper.LeerUsuarios();
        }

        public bool IniciarSesion(string cuenta, string clave)
        {
            foreach (var usuario in usuarios)
            {
                if (usuario.NumeroCuenta == cuenta && usuario.ValidarClave(clave))
                {
                    usuarioActual = usuario;
                    return true;
                }
            }
            return false;
        }

        public void Depositar(decimal valor)
        {
            if (usuarioActual != null)
            {
                usuarioActual.Saldo += valor;
                ArchivoHelper.GuardarMovimiento(usuarioActual.NumeroCuenta,
                    new Movimiento { Fecha = DateTime.Now, Tipo = "Deposito", Valor = valor });
                ArchivoHelper.GuardarUsuarios(usuarios);
            }
        }

        public void Retirar(decimal valor)
        {
            if (usuarioActual != null)
            {
                if (usuarioActual.Saldo >= valor)
                {
                    usuarioActual.Saldo -= valor;
                    ArchivoHelper.GuardarMovimiento(usuarioActual.NumeroCuenta,
                        new Movimiento { Fecha = DateTime.Now, Tipo = "Retiro", Valor = valor });
                    ArchivoHelper.GuardarUsuarios(usuarios);
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente.");
                }
            }
        }

        public void ConsultarSaldo()
        {
            if (usuarioActual != null)
            {
                Console.WriteLine($"Saldo actual: {usuarioActual.Saldo}");
            }
        }

        public void ConsultarMovimientos()
        {
            if (usuarioActual != null)
            {
                var movimientos = ArchivoHelper.LeerMovimientos(usuarioActual.NumeroCuenta);
                foreach (var mov in movimientos.TakeLast(5))
                {
                    Console.WriteLine($"{mov.Fecha} - {mov.Tipo} - {mov.Valor}");
                }
            }
        }

        public void CambiarClave(string nuevaClave)
        {
            if (usuarioActual != null)
            {
                usuarioActual.CambiarClave(nuevaClave);
                ArchivoHelper.GuardarUsuarios(usuarios);
            }
        }
    }
}
