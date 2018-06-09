using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrabajoPractico.Clases;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DeberiaMezclarMazo()
        {
            Mazo Mazo = new Mazo()
            {
                Nombre = "Jugadores",
                IDMazo = 1,
                Cartas = new List<Carta>
                {
                    new Carta
                    {
                        Codigo="1",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="2",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="3",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="4",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="5",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="6",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="7",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="8",
                        Tipo=TipoCarta.Normal
                    }
                }
            };

            Mazo Mazo1 = new Mazo()
            {
                Nombre = "Jugadores",
                IDMazo = 1,
                Cartas = new List<Carta>
                  {
                    new Carta
                    {
                        Codigo="1",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="2",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="3",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="4",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="5",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="6",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="7",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="8",
                        Tipo=TipoCarta.Normal
                    }
                }
            };

            Partida partida = new Partida();
            {
                partida.Mazo = Mazo;
            };

            partida.MezclarMazo();

            Assert.AreNotEqual(Mazo1, partida.Mazo);
        }

        [TestMethod]
        public void DeberiaRepartirMazo()
        {
            Mazo Mazo = new Mazo()
            {
                Nombre = "Jugadores",
                IDMazo = 1,
                Cartas = new List<Carta>
                  {
                    new Carta
                    {
                        Codigo="1",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="2",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="3",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="4",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="5",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="6",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="7",
                        Tipo=TipoCarta.Normal
                    },
                    new Carta
                    {
                        Codigo="8",
                        Tipo=TipoCarta.Normal
                    }
                }
            };


            Partida partida = new Partida();
            {
                partida.Mazo = Mazo;
                partida.JugadoresPartida = new List<Jugador>
                {
                    new Jugador
                    {
                        IDJugador = 1
                    },
                    new Jugador
                    {
                        IDJugador = 2
                    }
                };
            };

            partida.RepartirMazo(Mazo,partida.JugadoresPartida[0],partida.JugadoresPartida[1]);

            Assert.AreEqual(partida.JugadoresPartida[0].CartasJugador.Count, partida.JugadoresPartida[1].CartasJugador.Count);
            Assert.AreNotEqual(partida.JugadoresPartida[0].CartasJugador, partida.JugadoresPartida[1].CartasJugador);
            
        }

        [TestMethod]
        public void NoEmpezarJuegoSinJugadores()
        {
            Partida partida = new Partida();
            {                
                partida.JugadoresPartida = new List<Jugador>
                {
                    new Jugador
                    {
                        IDJugador = 1
                    }                    
                };
            };

            Juego juego = new Juego();

            Assert.IsFalse(juego.ValidarPartida(partida));

        }
        
    }
}
