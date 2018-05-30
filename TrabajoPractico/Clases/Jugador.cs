using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Clases
{
    public class Jugador
    {
        public int IDJugador { get; set; }
        public string IDConexion { get; set; }
        public string Nombre { get; set; }
        public List<Carta> CartasJugador { get; set; }

        public Jugador()
        {
            this.CartasJugador = new List<Carta>();
            this.IDJugador = 0;
            
        }
 
    }
}
