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
           
            var DatosJugador1 = partidaAUnirse.ObtenerCartas(jugador1.IDConexion);
            var DatosJugador2 = partidaAUnirse.ObtenerCartas(jugador2.IDConexion);

            Clients.Client(jugador1.IDConexion).dibujarTablero(new { Cartas= DatosJugador1, Nombre= jugador1.Nombre },
                                                                new { Cartas=DatosJugador2, Nombre=jugador2.Nombre },
                                                                new { Nombre=partidaAUnirse.Mazo.Nombre, NombreAtributos=partidaAUnirse.Mazo.AtributosMazo });
            Clients.Client(jugador2.IDConexion).dibujarTablero(new { Cartas = DatosJugador1, Nombre = jugador1.Nombre },
                                                                new { Cartas = DatosJugador2, Nombre = jugador2.Nombre },
                                                                new { Nombre = partidaAUnirse.Mazo.Nombre, NombreAtributos = partidaAUnirse.Mazo.AtributosMazo });
        }

        public void ObtenerPartidas()
        {
            Clients.Caller.agregarPartidas(juego.ObtenerPartidas());
        }

        public void ObtenerMazos()
        {
            Clients.Caller.agregarMazos(juego.NombreMazos());
            
        }

        public void Cantar(string idAtributo, string idCarta)
        {

            var partida = juego.BuscarPartidaID(Context.ConnectionId);
            
            var jugada = partida.CompararCartas(Context.ConnectionId, idAtributo);



            if (jugada.ResultadoMano == 2 || jugada.ResultadoMano == 3)
            {
                Clients.Client(jugada.IdGanador).ganarManoPorTarjetaRoja();
                Clients.Client(jugada.IdPerdedor).perderManoPorTarjetaRoja();
            }
            else
            {
                if (jugada.ResultadoMano == 1)
                {
                    Clients.Client(jugada.IdGanador).ganarManoPorTarjetaAmarilla();
                    Clients.Client(jugada.IdPerdedor).perderMano();
                }
                else
                {
                    //Clients.Caller.ganarMano();
                    Clients.Client(jugada.IdGanador).ganarMano();
                    Clients.Client(jugada.IdPerdedor).perderMano();
                }
            }

            if (jugada.FinalizaPartida)
            {
                Clients.Client(jugada.IdGanador).ganar();
                Clients.Client(jugada.IdPerdedor).perder();
            }
        }

    }
    }