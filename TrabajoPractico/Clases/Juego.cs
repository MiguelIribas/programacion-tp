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
        

        public void EmpezarJuego(Partida partida)
        {
            partida.MezclarMazo(partida.Mazo.Cartas);
            var jugador1 = partida.JugadoresPartida.First();
            var jugador2 = partida.JugadoresPartida.Last();
            partida.RepartirMazo(partida.Mazo, jugador1, jugador2);
            this.MostrarCarta(partida,jugador1,jugador2);
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

        public void MostrarCarta(Partida partida,Jugador jugador1, Jugador jugador2)
        {
            var Carta1 = partida.MostrarCarta(jugador1);
            var Carta2 = partida.MostrarCarta(jugador2);
            this.CompararCartas(Carta1, Carta2, jugador1, jugador2,partida);
        }

        public Jugador CompararCartas(Carta Carta1, Carta Carta2, Jugador jugador1, Jugador jugador2, Partida partida)
        {
            switch (Carta1.Tipo)
            {
                case TipoCarta.Roja:
                    if (Carta2.Tipo==TipoCarta.Amarilla)
                    {
                        //le roba 1
                    }
                    else
                    {
                        jugador1.CartasJugador.Add(Carta1);
                        jugador1.CartasJugador.RemoveAt(0);
                        jugador1.CartasJugador.Add(jugador2.CartasJugador[0]);
                        jugador1.CartasJugador.Add(jugador2.CartasJugador[1]);
                        jugador2.CartasJugador.RemoveAt(0);
                        jugador2.CartasJugador.RemoveAt(1);
                        return jugador1;                        
                    }
                    break;

                case TipoCarta.Amarilla:
                    if (Carta2.Tipo == TipoCarta.Roja)
                    {
                        //le saca 1
                    }
                    else
                    {
                        //le roba 1
                    }
                    break;

                case TipoCarta.Normal:
                    switch (Carta2.Tipo)
                    {
                        case TipoCarta.Normal:

                            Atributo Atributo = new Atributo();//despues vemos
                            var Turno = partida.DevolverTurno();

                            if (Turno==jugador1)
                            {
                                foreach (var item in Carta2.Atributos)
                                {
                                    if (item.Nombre == Atributo.Nombre)
                                    {
                                        if (Atributo.Valor>=item.Valor)
                                        {
                                            jugador1.CartasJugador.Add(Carta1);
                                            jugador1.CartasJugador.RemoveAt(0);
                                            jugador1.CartasJugador.Add(jugador2.CartasJugador[0]);
                                            jugador2.CartasJugador.RemoveAt(0);
                                            return jugador1;
                                        }
                                        else
                                        {
                                            jugador2.CartasJugador.Add(Carta2);
                                            jugador2.CartasJugador.RemoveAt(0);
                                            jugador2.CartasJugador.Add(jugador1.CartasJugador[0]);
                                            jugador1.CartasJugador.RemoveAt(0);
                                            return jugador2;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (var item in Carta1.Atributos)
                                {
                                    if (item.Nombre == Atributo.Nombre)
                                    {

                                    }
                                }
                            }
                            

                            break;
                        case TipoCarta.Roja:
                            //le saca 2
                            break;
                        case TipoCarta.Amarilla:
                            //le saca 1
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
        }

    
    }
}
