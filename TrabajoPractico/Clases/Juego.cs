using System;
using System.Collections.Generic;
using System.IO;
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


        public void AgregarPartida(string NombreJugador, int IDConexion, Mazo Mazo, string NombrePartida) //ver porque en hub mazo tiene que ser string
        {
            var Jugador1 = this.CrearJugador(NombreJugador, IDConexion);
            var IDPartida = Partidas.Count + 1;
            var Partida1 = new Partida().CrearPartida(Jugador1, NombrePartida, Mazo, IDPartida);

            this.Partidas.Add(Partida1);
        }

        public void UnirPartida(string NombreJugador, int IDConexion, string NombrePartida)
        {
            var Jugador2 = this.CrearJugador(NombreJugador, IDConexion);

            foreach (var item in Partidas)
            {
                if (item.Nombre == NombrePartida && item.Estado==EstadoPartida.Disponible) //ver porque no deberia pasar nunca que un jugador quiera a unirse a una partida ocupada, porque no se va a listar en pantalla.
                {
                    item.Estado = EstadoPartida.Ocupada;
                    item.JugadoresPartida.Add(Jugador2);                    
                    this.ValidarPartida(item);
                }
                /*else
                {
                    //algo deberia hacer
                }*/
            }
        }

        public bool ValidarPartida(Partida partida)
        {
            if (partida.JugadoresPartida.Count == 2)
            {
                this.EmpezarJuego(partida);
                return true;
            }
            else
                return false; //DISPARAR EVENTO O MENSAJE O LO QUE SEA
        }

        public void EmpezarJuego(Partida partida)
        {         
            partida.MezclarMazo();
            var jugador1 = partida.JugadoresPartida.First();
            var jugador2 = partida.JugadoresPartida.Last();
            partida.RepartirMazo(partida.Mazo, jugador1, jugador2);
            //mostrar cartas graficamente y atributos
        }
        
        public Jugador CrearJugador (string Nombre,int IDConexion)
        {
            var Jugador = new Jugador() { IDConexion = IDConexion, Nombre = Nombre, IDJugador = Jugadores.Count + 1 };
            Jugadores.Add(Jugador);
            return Jugador;
        }
       
        public List<Partida> ObtenerPartidas()
        {
            return Partidas.Where(x => x.Estado == EstadoPartida.Disponible).ToList();
        }
       
        public List<Mazo> ObtenerMazos()
        {
            return Mazos;
        }

        /*var lines = File.ReadAllLines(@"D:\prueba.txt");

       foreach (var line in lines)
       {
           // Lógica acá
       } */



    }
}
