using System;

namespace CajeroAutomatico
{
    internal class Movimiento
    {
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } = "";
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return $"{Fecha};{Tipo};{Valor}";
        }
    }
}
