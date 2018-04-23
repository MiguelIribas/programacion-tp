using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Clases
{
    public class Partida
    {
        public int IDPartida { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public List<Jugador> JugadoresPartida { get; set; }
        public Mazo Mazo { get; set; }

        public Partida CrearPartida(Jugador Jugador1, string Nombre, Mazo Mazo, int IDPartida)
        {
            this.IDPartida = IDPartida;
            this.Nombre = Nombre;
            this.Estado = true;
            this.JugadoresPartida.Add(Jugador1);
            this.Mazo = Mazo;

            return this;
        }

        public void MezclarMazo()
        {

        }

        public void RepartirMazo()
        {

        }


    }
}
