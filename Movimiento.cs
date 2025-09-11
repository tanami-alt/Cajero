using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    internal class Movimiento
    {
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return $"{Fecha};{Tipo};{Valor}";
        }
    }
}
