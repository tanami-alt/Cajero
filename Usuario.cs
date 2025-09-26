using System;

namespace CajeroAutomatico
{
    public class Usuario
    {
        public string NumeroCuenta { get; set; } = "";
        public string Clave { get; set; } = "";
        public decimal Saldo { get; set; }

        public bool ValidarClave(string claveIngresada)
        {
            return Clave == claveIngresada;
        }

        public void CambiarClave(string nuevaClave)
        {
            Clave = nuevaClave;
        }
    }
}
