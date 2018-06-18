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


        public Partida()
        {
            this.JugadoresPartida = new List<Jugador>();
        }

        public Partida CrearPartida(Jugador Jugador1, string Nombre, Mazo Mazo, int IDPartida)
        {
            if (Nombre != "" && Jugador1 != null)
            {
                this.IDPartida = IDPartida;
                this.Nombre = Nombre;
                this.Estado = EstadoPartida.Disponible;
                this.Turno = Jugador1;
                this.JugadoresPartida.Add(Jugador1);
                this.Mazo = Mazo;

            }
            else
            {
                //throw Exception e;
            }
            return this;
        }

        public void MezclarMazo()
        {
            List<Carta> CartasOriginal = Mazo.Cartas;
            List<Carta> CartasMezcladas = new List<Carta>();

            Random randNum = new Random();

            while (CartasOriginal.Count > 0)
            {
                int val = randNum.Next(0, CartasOriginal.Count - 1);
                CartasMezcladas.Add(CartasOriginal[val]);
                CartasOriginal.RemoveAt(val);
            }
            Mazo.Cartas = CartasMezcladas;
           // return Mazo.Cartas;
        }

        public void RepartirMazo(Mazo mazo, Jugador jugador1, Jugador jugador2)
        {
            var elementos = mazo.Cartas.Count;
            int contador=0;
            foreach (var item in mazo.Cartas)
            {
                contador += 1;
                if (contador<=elementos/2)
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

        private void MoverCartas(Jugador jugadorG, Jugador jugadorP)
        {
            var Carta1 = jugadorG.CartasJugador.First();
            var CartaRobar = jugadorP.CartasJugador.First();

            if (Carta1.Tipo == TipoCarta.Roja || Carta1.Tipo == TipoCarta.Amarilla)
            {
                jugadorG.CartasJugador.RemoveAt(0);
                jugadorG.CartasJugador.Add(CartaRobar);
                jugadorP.CartasJugador.RemoveAt(0);

                if (Carta1.Tipo == TipoCarta.Roja)
                {
                    if (jugadorG.CartasJugador.Count > 1)
                    {
                        CartaRobar = jugadorP.CartasJugador.First();
                        jugadorG.CartasJugador.Add(CartaRobar);
                        jugadorP.CartasJugador.RemoveAt(0);
                    }
                    else
                    {
                        jugadorP.CartasJugador.AddRange(jugadorG.CartasJugador);

                        foreach (var item in jugadorG.CartasJugador)
                        {
                            jugadorG.CartasJugador.Remove(item);
                        }
                    }
                }

            }
            else
            {
                jugadorG.CartasJugador.Add(Carta1);
                jugadorG.CartasJugador.RemoveAt(0);
                jugadorG.CartasJugador.Add(CartaRobar);
                jugadorP.CartasJugador.RemoveAt(0);
            }
        }


        public Resultado CompararCartas(string IDConexion, string Atributo)
        {
            var jugadorGanador = this.JugadoresPartida.Where(x => x.IDConexion == IDConexion).Single();
            var jugadorPerdedor = this.JugadoresPartida.Where(x => x.IDConexion != IDConexion).Single();
            var Carta1 = jugadorGanador.CartasJugador.First();
            var Carta2 = jugadorPerdedor.CartasJugador.First();
         
            Resultado Res = new Resultado();
                       
            switch (Carta1.Tipo)
            {
                case TipoCarta.Roja:
                    switch (Carta2.Tipo)
                    {
                        case TipoCarta.Normal: //J1: Carta roja,J2: Carta normal --> El J1 le roba al J2 la carta que tiene y la primera del mazo, y elimina la carta roja.        

                            Res.IdGanador = jugadorGanador.IDConexion;
                            Res.ResultadoMano = 2;
                            Res.IdPerdedor = jugadorPerdedor.IDConexion;
                            this.MoverCartas(jugadorGanador, jugadorPerdedor);

                            break;

                        case TipoCarta.Amarilla: //J1: Carta roja, J2: Carta amarilla --> El J1 le roba al J2 la primera del mazo, y se eliminan las cartas roja y amarilla.

                            Res.IdGanador = jugadorGanador.IDConexion;
                            Res.ResultadoMano = 3;
                            Res.IdPerdedor = jugadorPerdedor.IDConexion;
                            this.MoverCartas(jugadorGanador, jugadorPerdedor);

                            break;
                    }
                    break;

                case TipoCarta.Amarilla:
                    switch (Carta2.Tipo)
                    {
                        case TipoCarta.Normal: // J1: Carta amarilla, J2: Carta Normal --> El J1 le roba al J2 la carta que tiene, y elimina la carta amarilla.

                            Res.IdGanador = jugadorPerdedor.IDConexion;
                            Res.IdPerdedor = jugadorGanador.IDConexion;
                            Res.ResultadoMano = 1;
                            this.MoverCartas(jugadorGanador, jugadorPerdedor);

                            break;

                        case TipoCarta.Roja: //J1: Carta amarilla, J2: Carta roja --> El J2 le roba al J1 la primera del mazo, y se eliminan las cartas rojas y amarilla.

                            Res.IdGanador = jugadorGanador.IDConexion;
                            Res.ResultadoMano = 3;
                            Res.IdPerdedor = jugadorPerdedor.IDConexion;
                            this.MoverCartas(jugadorGanador, jugadorPerdedor);

                            break;
                    }
                    break;


                case TipoCarta.Normal:
                    switch (Carta2.Tipo)
                    {
                        case TipoCarta.Normal:

                            decimal valorJGanador = 0;
                            decimal valorJPerdedor = 0;

                            foreach (var item in Carta1.Atributos)
                            {
                                    if (item.Nombre == Atributo)
                                    {
                                        valorJGanador = item.Valor;
                                    }
                                
                            }

                            foreach (var item in Carta2.Atributos)
                            {
                                if (item.Nombre == Atributo)
                                {
                                    valorJPerdedor = item.Valor;
                                }

                            }

                            if (valorJGanador >= valorJPerdedor)
                            {
                                Res.IdGanador = jugadorGanador.IDConexion;
                                Res.ResultadoMano = 0;
                                Res.IdPerdedor = jugadorPerdedor.IDConexion;
                                this.MoverCartas(jugadorGanador, jugadorPerdedor);
                            }
                            else
                            {
                                Res.IdGanador = jugadorPerdedor.IDConexion;
                                Res.ResultadoMano = 0;
                                Res.IdPerdedor = jugadorGanador.IDConexion;
                                this.MoverCartas(jugadorPerdedor, jugadorGanador);
                            }
                            break;

                        case TipoCarta.Roja: // J1: Carta normal, J2: Carta roja --> El J2 le roba al J1 la carta que tiene y la primera del mazo, y se elimina la carta roja.

                            Res.IdGanador = jugadorPerdedor.IDConexion;
                            Res.IdPerdedor = jugadorGanador.IDConexion;
                            Res.ResultadoMano = 2;
                            this.MoverCartas(jugadorGanador, jugadorPerdedor);

                            break;

                        case TipoCarta.Amarilla: //J1: Carta normal, J2: Carta amarilla --> El J2 le roba al J1 la carta que tiene, y se elimina la carta amarilla.

                            Res.IdGanador = jugadorPerdedor.IDConexion;
                            Res.IdPerdedor = jugadorPerdedor.IDConexion;
                            Res.ResultadoMano = 1;
                            this.MoverCartas(jugadorGanador, jugadorPerdedor);

                            break;
                    }
                    break;

            }

            if (jugadorGanador.CartasJugador.Count == 0 || jugadorPerdedor.CartasJugador.Count == 0)
            {
                Res.FinalizaPartida = true;
            }
            return Res;

        }

        public void CantarAtributo(string nombreAtributo, string idCarta)
        {
        }

        public void EmpezarJuego()
        {
            this.MezclarMazo();
            //partida.MezclarMazo();
            var jugador1 = this.JugadoresPartida.First();
            var jugador2 = this.JugadoresPartida.Last();
            this.RepartirMazo(this.Mazo, jugador1, jugador2);
            //var atributoElegido = "";
            //int primerJuego = 1;
            //var ganador = "";

            //while (this.Estado == EstadoPartida.Ocupada)
            //{
            //    if (jugador1.CartasJugador.Count == Mazo.Cartas.Count)
            //    {
            //        this.Estado = EstadoPartida.Finalizada;
            //    }
            //    else
            //    {
            //        if (primerJuego == 1)
            //        {
            //            //cantar atributo
            //            ganador = this.CompararCartas(jugador1.IDConexion, atributoElegido);
            //            primerJuego = 2;
            //        }
            //        else
            //        {
            //            //cantar atributo
            //            ganador = this.CompararCartas(ganador, atributoElegido);
            //        }
            //    }
            //}
            //mostrar cartas graficamente y atributos
        }

        public List<Carta> ObtenerCartas(string IdJugador)
        {
            List<Carta> NombreCartas = new List<Carta>();

            var cartasjugador = this.JugadoresPartida.Where(x => x.IDConexion == IdJugador).Single().CartasJugador;

            foreach (var item in cartasjugador)
            {
                NombreCartas.Add(item);
            }
            return NombreCartas;

        }

        

    }
}
