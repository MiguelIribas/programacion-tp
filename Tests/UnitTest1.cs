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

        ////[TestMethod]
        ////public void NoUnirseAPartidaConMasJugadores()
        ////{
        ////    Partida partida = new Partida();
        ////    {
        ////        partida.JugadoresPartida = new List<Jugador>
        ////        {
        ////            new Jugador
        ////            {
        ////                Nombre = "1"
        ////            },

        ////            new Jugador
        ////            {
        ////                Nombre = "2"
        ////            }
        ////        };
        ////    };

        ////    Juego juego = new Juego();
        ////    partida.Nombre = "azul";
        ////    juego.Jugadores.AddRange(partida.JugadoresPartida);

        ////    Jugador jugador = new Jugador() { Nombre = "sas" };
        ////    juego.Jugadores.Add(jugador);
        ////    juego.UnirPartida("sas", "sadasd", "azul");

        ////    Assert.IsTrue(juego.ValidarPartida(partida));

        ////}

        [TestMethod]
        public void DeberiaCrearMazos()
        {
            Juego juego = new Juego();
            Assert.IsNotNull(juego);

        }

        [TestMethod]
        public void NoDeberiaCrearPartidaSinNombre()
        {
            Partida partida = new Partida() { IDPartida = 1 };
            Mazo mazo = new Mazo();
            Jugador jugador = new Jugador() { Nombre = "sss", IDJugador = 1 };

            Assert.IsNotNull(partida.CrearPartida(jugador, "", mazo, 1));

        }

        [TestMethod]
        public void NoDeberiaCrearPartidaSinJugador()
        {

            Partida partida = new Partida() { IDPartida = 1 };
            Mazo mazo = new Mazo();
            //Jugador jugador = new Jugador() { Nombre = "sss", IDJugador = 1 };

            Assert.IsNotNull(partida.CrearPartida(null, "", mazo, 1));
        }

        //[TestMethod]
        //public void NoDeberiaCrearJugadorSinNombre()
        //{
        //    Juego juego = new Juego();
        //    string id = "aasdsad";

        //    Assert.IsNotNull(juego.CrearJugador("", id));

        //}

        [TestMethod]
        public void DeberiaCompararCartas()
        {
            List<Carta> Cartas = new List<Carta>
            {
                    new Carta
                    {
                        Codigo="1",
                        Tipo=TipoCarta.Normal,
                        Atributos = new List<Atributo>() { new Atributo { Nombre = "ss", Valor = 4} }
                    },
                    new Carta
                    {
                        Codigo="2",
                        Tipo=TipoCarta.Normal,

                    },
                    new Carta
                    {
                        Codigo="3",
                        Tipo=TipoCarta.Normal
                    },
            };

            List<Carta> Cartas2 = new List<Carta>
            {
                    new Carta
                    {
                        Codigo="1",
                        Tipo=TipoCarta.Normal,
                        Atributos = new List<Atributo>() { new Atributo { Nombre = "ss", Valor = 8} }
                    },
                    new Carta
                    {
                        Codigo="2",
                        Tipo=TipoCarta.Normal,

                    },
                    new Carta
                    {
                        Codigo="3",
                        Tipo=TipoCarta.Normal
                    },
            };

            Jugador jugador1 = new Jugador() { CartasJugador = Cartas, IDConexion = "q" };
            Jugador jugador2 = new Jugador() { CartasJugador = Cartas2, IDConexion = "qz" };

            Partida partida = new Partida();
            partida.JugadoresPartida.Add(jugador1);
            partida.JugadoresPartida.Add(jugador2);

            Assert.IsNotNull(partida.CompararCartas("q", "ss"));
        }

        [TestMethod]
        public void DeberiaCompararCartasRoja()
        {
            List<Carta> Cartas = new List<Carta>
            {
                    new Carta
                    {
                        Codigo="1",
                        Tipo=TipoCarta.Roja,

                    },
                    new Carta
                    {
                        Codigo="2",
                        Tipo=TipoCarta.Normal,

                    },
                    new Carta
                    {
                        Codigo="3",
                        Tipo=TipoCarta.Normal
                    },
            };

            List<Carta> Cartas2 = new List<Carta>
            {
                    new Carta
                    {
                        Codigo="1",
                        Tipo=TipoCarta.Normal,
                        Atributos = new List<Atributo>() { new Atributo { Nombre = "ss", Valor = 8} }
                    },
                    new Carta
                    {
                        Codigo="2",
                        Tipo=TipoCarta.Normal,

                    },
                    new Carta
                    {
                        Codigo="3",
                        Tipo=TipoCarta.Normal
                    },
            };

            Jugador jugador1 = new Jugador() { CartasJugador = Cartas, IDConexion = "q" };
            Jugador jugador2 = new Jugador() { CartasJugador = Cartas2, IDConexion = "qz" };

            Partida partida = new Partida();
            partida.JugadoresPartida.Add(jugador1);
            partida.JugadoresPartida.Add(jugador2);

            Assert.IsNotNull(partida.CompararCartas("q", "ss"));
        }

        [TestMethod]
        public void DeberiaCompararCartasAmarilla()
        {
            List<Carta> Cartas = new List<Carta>
            {
                    new Carta
                    {
                        Codigo="1",
                        Tipo=TipoCarta.Normal,
                        Atributos = new List<Atributo>() { new Atributo { Nombre = "ss", Valor = 8} }

                    },
                    new Carta
                    {
                        Codigo="2",
                        Tipo=TipoCarta.Normal,

                    },
                    new Carta
                    {
                        Codigo="3",
                        Tipo=TipoCarta.Normal
                    },
            };

            List<Carta> Cartas2 = new List<Carta>
            {
                    new Carta
                    {
                        Codigo="1",
                        Tipo=TipoCarta.Amarilla

                    },
                    new Carta
                    {
                        Codigo="2",
                        Tipo=TipoCarta.Normal,

                    },
                    new Carta
                    {
                        Codigo="3",
                        Tipo=TipoCarta.Normal
                    },
            };

            Jugador jugador1 = new Jugador() { CartasJugador = Cartas, IDConexion = "q" };
            Jugador jugador2 = new Jugador() { CartasJugador = Cartas2, IDConexion = "qz" };

            Partida partida = new Partida();
            partida.JugadoresPartida.Add(jugador1);
            partida.JugadoresPartida.Add(jugador2);

            Assert.IsNotNull(partida.CompararCartas("q", "ss"));
        }
    }

}
}
