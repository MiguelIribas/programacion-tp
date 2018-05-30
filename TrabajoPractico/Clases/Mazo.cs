using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Clases
{
    public class Mazo
    {
        public int IDMazo { get; set; }
        public string Nombre { get; set; }
        public List<Carta> Cartas { get; set; } 

        public Mazo()
        {
            this.Cartas = new List<Carta>();
        }
    }
}
