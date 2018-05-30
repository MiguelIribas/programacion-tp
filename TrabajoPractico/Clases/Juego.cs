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

        public Juego()
        {
            this.Jugadores = new List<Jugador>();
            this.Mazos = new List<Mazo>();
            this.Partidas = new List<Partida>();
        }

        public void AgregarPartida(string nombrejugador, string mazo, string nombrepartida) //ver porque en hub mazo tiene que ser string
        {
            var Jugador1 = Jugadores.Where(x => x.Nombre == nombrejugador).Single();
            var IDPartida = Partidas.Count + 1;
            var Mazo = Mazos.Where(x => x.Nombre == mazo).Single();

            var Partida1 = new Partida().CrearPartida(Jugador1, nombrepartida, Mazo, IDPartida);

            this.Partidas.Add(Partida1);
        }

        public void UnirPartida(string NombreJugador, string IDConexion, string NombrePartida)
        {
            var Jugador2 = Jugadores.Where(x => x.Nombre == NombreJugador).Single();

            foreach (var item in Partidas)
            {
                if (item.Nombre == NombrePartida && item.Estado==EstadoPartida.Disponible) //ver porque no deberia pasar nunca que un jugador quiera a unirse a una partida ocupada, porque no se va a listar en pantalla.
                {
                    item.Estado = EstadoPartida.Ocupada;
                    item.JugadoresPartida.Add(Jugador2);                    
                    this.ValidarPartida(item);
                }
                
            }
        }

        public Partida BuscarPartidaPorNombre(string partida)
        {
            var Partida = Partidas.Where(x => x.Nombre == partida).Single();
            return Partida;
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
        
        public void CrearJugador (string Nombre,string IDConexion)
        {
            var Jugador = new Jugador() { IDConexion = IDConexion, Nombre = Nombre, IDJugador = Jugadores.Count + 1 };
            Jugadores.Add(Jugador);
            
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
