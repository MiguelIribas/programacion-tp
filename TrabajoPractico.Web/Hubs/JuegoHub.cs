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
        /*
        private static Juego juego = new Juego();

        public void CrearPartida(string usuario, string partida, string mazo)
        {
            // Notifico a los otros usuarios de la nueva partida.
            Clients.Others.agregarPartida(nuevaPartida);

            Clients.Caller.esperarJugador();
        }

        public void UnirsePartida(string usuario, string partida)
        {
            Clients.All.eliminarPartida(partidaAUnirse.Nombre);

            Clients.Client(jugador1.ConnectionId).dibujarTablero(jugador1, jugador2, partidaAUnirse.Mazo);
            Clients.Client(jugador2.ConnectionId).dibujarTablero(jugador1, jugador2, partidaAUnirse.Mazo);
        }

        public void ObtenerPartidas()
        {
            Clients.Caller.agregarPartidas(partidas);
        }

        public void ObtenerMazos()
        {
            Clients.Caller.agregarMazos(mazos);
        }

        public void Cantar(string idAtributo, string idCarta)
        {

            
            if (jugada.connectionIdGanador == Context.ConnectionId)
            {
                Clients.Caller.ganarMano(resultado, false);
                Clients.Client(jugada.connectionIdPerdedor).perderMano(resultado, false);

            }
            else
            {
                Clients.Client(jugada.connectionIdGanador).ganarMano(resultado, false);
                Clients.Caller.perderMano(resultado, false);

            }
            if (jugada.finalizoJuego)
            {
                Clients.Caller.ganar();
                Clients.Client(jugada.connectionIdPerdedor).perder();
            }
        }
        */
    }
}