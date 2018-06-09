using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrabajoPractico.Clases;

namespace TrabajoPractico.Web.Hubs
{
    public class JuegoHub:Hub
    {        
        private static Juego juego = new Juego();

        public void CrearPartida(string usuario, string partida, string mazo)
        {
            juego.CrearJugador(usuario, Context.ConnectionId);
            juego.AgregarPartida(usuario, mazo, partida);
            // Notifico a los otros usuarios de la nueva partida.
                        
            Clients.Others.agregarPartida(new { Nombre = partida, Mazo = mazo, Usuario = usuario });

            Clients.Caller.esperarJugador();
        }

        public void UnirsePartida(string usuario, string partida)
        {
            juego.CrearJugador(usuario, Context.ConnectionId);
            juego.UnirPartida(usuario, Context.ConnectionId, partida);

            Clients.All.eliminarPartida(partida);
            var partidaAUnirse = juego.BuscarPartidaPorNombre(partida);
            var jugador1 = partidaAUnirse.JugadoresPartida.First();
            var jugador2 = partidaAUnirse.JugadoresPartida.Last();

            Clients.Client(jugador1.IDConexion).dibujarTablero(jugador1, jugador2, partidaAUnirse.Mazo);
            Clients.Client(jugador2.IDConexion).dibujarTablero(jugador1, jugador2, partidaAUnirse.Mazo);
        }

        public void ObtenerPartidas()
        {
            //Clients.Caller.agregarPartidas(partidas);
        }

        public void ObtenerMazos()
        {
            Clients.Caller.agregarMazos(new List<string>() { "Mazo 1" });
        }

        public void Cantar(string idAtributo, string idCarta)
        {            
            //if (jugada.connectionIdGanador == Context.ConnectionId)
            //{
            //    Clients.Caller.ganarMano(resultado, false);
            //    Clients.Client(jugada.connectionIdPerdedor).perderMano(resultado, false);

            //}
            //else
            //{
            //    Clients.Client(jugada.connectionIdGanador).ganarMano(resultado, false);
            //    Clients.Caller.perderMano(resultado, false);

            //}
            //if (jugada.finalizoJuego)
            //{
            //    Clients.Caller.ganar();
            //    Clients.Client(jugada.connectionIdPerdedor).perder();
            //}
        }
        
    }
}