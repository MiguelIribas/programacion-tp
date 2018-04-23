using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Clases
{
    public class Juego
    {
        public List<Partida> Partidas { get; set; }
        public List<Mazo> Mazos { get; set; }
        public List<Jugador> Jugadores { get; set; }

        public void EmpezarJuego(Partida Partida)
        {
            Partida.MezclarMazo();
            Partida.RepartirMazo();
        }

        public void EmpezarPartida(string NombreJugador, int IDConexion, Mazo Mazo, string NombrePartida)
        {
            var Jugador1 = new Jugador() { IDConexion = IDConexion, Nombre = NombreJugador,IDJugador=Jugadores.Count+1 };
            var IDPartida = Partidas.Count + 1;
            var Partida1 = new Partida().CrearPartida(Jugador1, NombrePartida, Mazo, IDPartida);

            this.Partidas.Add(Partida1);
            this.Jugadores.Add(Jugador1);
        }

        public void UnirPartida(Jugador Jugador2, string NombrePartida)
        {
            foreach (var item in Partidas)
            {
                if (item.Nombre==NombrePartida)
                {
                    item.JugadoresPartida.Add(Jugador2);
                    this.EmpezarJuego(item);
                }
            }
        }

        

    }
}
