using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Clases
{
    public enum EstadoPartida
    {
        Disponible,Ocupada,Finalizada
    }
    public class Partida
    {
        public int IDPartida { get; set; }
        public string Nombre { get; set; }
        public EstadoPartida Estado { get; set; }
        public Jugador Turno { get; set; }
        public List<Jugador> JugadoresPartida { get; set; }
        public Mazo Mazo { get; set; }

        public Partida CrearPartida(Jugador Jugador1, string Nombre, Mazo Mazo, int IDPartida)
        {
            this.IDPartida = IDPartida;
            this.Nombre = Nombre;
            this.Estado = EstadoPartida.Disponible;
            this.Turno = Jugador1;
            this.JugadoresPartida.Add(Jugador1);
            this.Mazo = Mazo;

            return this;
        }

        public List<Carta> MezclarMazo(List<Carta> cartas)
        {
            List<Carta> arr = cartas;
            List<Carta> arrDes = new List<Carta>();

            Random randNum = new Random();

            while (arr.Count > 0)
            {
                int val = randNum.Next(0, arr.Count - 1);
                arrDes.Add(arr[val]);
                arr.RemoveAt(val);
            }

            return arrDes;

        }

        public void RepartirMazo(Mazo mazo, Jugador jugador1, Jugador jugador2)
        {
            var elementos = mazo.Cartas.Count;
            
            foreach (var item in mazo.Cartas)
            {
                if (elementos/2 <= elementos)
                {
                    jugador1.CartasJugador.Add(item);
                }
                else
                {
                    jugador2.CartasJugador.Add(item);
                }
            }   
        }

        public Carta MostrarCarta(Jugador Jugador)
        {
            return Jugador.CartasJugador.First();
        }

        public Jugador DevolverTurno()
        {
            return Turno;
        }

    }
}
