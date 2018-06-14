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
            this.IDPartida = IDPartida;
            this.Nombre = Nombre;
            this.Estado = EstadoPartida.Disponible;
            this.Turno = Jugador1;
            this.JugadoresPartida.Add(Jugador1);
            this.Mazo = Mazo;

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
        
        private void MoverCartas(string idJugadorGanador, int resultadoMano)
        {
            var jugadorGanador = this.JugadoresPartida.Where(x => x.IDConexion == idJugadorGanador).Single();
            var jugadorPerdedor = this.JugadoresPartida.Where(x => x.IDConexion != idJugadorGanador).Single();

            switch (resultadoMano)
            {
                case 0:
                    jugadorGanador.CartasJugador.Add(jugadorGanador.CartasJugador[0]);
                    jugadorGanador.CartasJugador.RemoveAt(0);
                    jugadorGanador.CartasJugador.Add(jugadorPerdedor.CartasJugador[0]);
                    jugadorPerdedor.CartasJugador.RemoveAt(0);
                    break;
                case 1:
                    jugadorGanador.CartasJugador.RemoveAt(0);
                    jugadorGanador.CartasJugador.Add(jugadorPerdedor.CartasJugador[0]);
                    jugadorPerdedor.CartasJugador.RemoveAt(0);
                    break;
                case 2:
                    jugadorGanador.CartasJugador.RemoveAt(0);
                    jugadorGanador.CartasJugador.Add(jugadorPerdedor.CartasJugador[0]);
                    jugadorGanador.CartasJugador.Add(jugadorPerdedor.CartasJugador[1]);
                    jugadorPerdedor.CartasJugador.RemoveAt(0);
                    jugadorPerdedor.CartasJugador.RemoveAt(1);
                    break;
                case 3:
                    jugadorGanador.CartasJugador.RemoveAt(0);
                    jugadorGanador.CartasJugador.Add(jugadorPerdedor.CartasJugador[1]);
                    jugadorPerdedor.CartasJugador.RemoveAt(0);
                    break;
               
                default:
                    break;
            }

        }

        public Resultado CompararCartas(string IDConexion, string Atributo)
        {
            var jugador1 = this.JugadoresPartida.Where(x => x.IDConexion == IDConexion).Single();
            var jugador2 = this.JugadoresPartida.Where(x => x.IDConexion != IDConexion).Single();
            var Carta1 = jugador1.CartasJugador.First();
            var Carta2 = jugador2.CartasJugador.First();
            Resultado Res = new Resultado();

            int resultado = 0;
            string JugadorGanador = ""; //En esta variable se va a guardar al jugador que gana en cada caso, no deja retornar antes del break.

            switch (Carta1.Tipo)
            {
                case TipoCarta.Roja:
                    switch (Carta2.Tipo)
                    {
                        case TipoCarta.Normal: //J1: Carta roja,J2: Carta normal --> El J1 le roba al J2 la carta que tiene y la primera del mazo, y elimina la carta roja.        
                        //    jugador1.CartasJugador.RemoveAt(0);
                        //    jugador1.CartasJugador.Add(jugador2.CartasJugador[0]);
                        //    jugador1.CartasJugador.Add(jugador2.CartasJugador[1]);
                        //    jugador2.CartasJugador.RemoveAt(0);
                        //    jugador2.CartasJugador.RemoveAt(1);
                            JugadorGanador = jugador1.IDConexion;
                            resultado = 2;
                            this.MoverCartas(JugadorGanador,resultado);
                            
                            Res.IdGanador = JugadorGanador;
                            Res.ResultadoMano = resultado;
                            Res.IdPerdedor = jugador2.IDConexion;
                            break;

                        case TipoCarta.Amarilla: //J1: Carta roja, J2: Carta amarilla --> El J1 le roba al J2 la primera del mazo, y se eliminan las cartas roja y amarilla.
                            //jugador1.CartasJugador.RemoveAt(0);
                            //jugador1.CartasJugador.Add(jugador2.CartasJugador[1]);
                            //jugador2.CartasJugador.RemoveAt(0);
                            resultado = 3;
                            JugadorGanador = jugador1.IDConexion;
                            this.MoverCartas(JugadorGanador, resultado);
                            break;

                      
                    }
                    break;

                case TipoCarta.Amarilla:
                    switch (Carta2.Tipo)
                    {
                        case TipoCarta.Normal: // J1: Carta amarilla, J2: Carta Normal --> El J1 le roba al J2 la carta que tiene, y elimina la carta amarilla.
                            //jugador1.CartasJugador.RemoveAt(0);
                            //jugador1.CartasJugador.Add(jugador2.CartasJugador[0]);
                            //jugador2.CartasJugador.RemoveAt(0);
                            resultado = 1;
                            JugadorGanador = jugador1.IDConexion;
                            this.MoverCartas(JugadorGanador, resultado);
                            break;

                        case TipoCarta.Roja: //J1: Carta amarilla, J2: Carta roja --> El J2 le roba al J1 la primera del mazo, y se eliminan las cartas rojas y amarilla.
                            //jugador2.CartasJugador.RemoveAt(0);
                            //jugador2.CartasJugador.Add(jugador1.CartasJugador[1]);
                            //jugador1.CartasJugador.RemoveAt(0);
                            resultado = 3;
                            JugadorGanador = jugador1.IDConexion;
                            this.MoverCartas(JugadorGanador, resultado);
                            break;

                       
                    }
                    break;


                case TipoCarta.Normal:
                    switch (Carta2.Tipo)
                    {
                        case TipoCarta.Normal: //Aca deberia dejar elegir los atributos, hacer un metodo aparte.

                            decimal atributo1 = 0;
                            decimal atributo2 = 0;
                            resultado = 0;

                            foreach (var item in Carta1.Atributos) //valor carta 1
                            {
                                if (item.Nombre == Atributo)
                                {
                                    atributo1 = item.Valor;
                                }
                            }

                            foreach (var item in Carta2.Atributos) //valor carta 2
                            {
                                if (item.Nombre == Atributo)
                                {
                                    atributo2 = item.Valor;
                                }
                            }

                            if (atributo1 >= atributo2)
                            {
                                //jugador1.CartasJugador.Add(jugador1.CartasJugador[0]);
                                //jugador1.CartasJugador.RemoveAt(0);
                                //jugador1.CartasJugador.Add(jugador2.CartasJugador[0]);
                                //jugador2.CartasJugador.RemoveAt(0);
                                JugadorGanador = jugador1.IDConexion;
                                this.MoverCartas(JugadorGanador, resultado);

                                Res.IdGanador = JugadorGanador;
                                Res.ResultadoMano = resultado;
                                Res.IdPerdedor = jugador2.IDConexion;
                            }
                            else
                            {
                                //jugador2.CartasJugador.Add(jugador2.CartasJugador[0]);
                                //jugador2.CartasJugador.RemoveAt(0);
                                //jugador2.CartasJugador.Add(jugador1.CartasJugador[0]);
                                //jugador1.CartasJugador.RemoveAt(0);
                                JugadorGanador = jugador2.IDConexion;
                                this.MoverCartas(JugadorGanador, resultado);

                                Res.IdGanador = JugadorGanador;
                                Res.ResultadoMano = resultado;
                                Res.IdPerdedor = jugador1.IDConexion;
                            }

                            break;

                        case TipoCarta.Roja: // J1: Carta normal, J2: Carta roja --> El J2 le roba al J1 la carta que tiene y la primera del mazo, y se elimina la carta roja.
                            //jugador2.CartasJugador.RemoveAt(0);
                            //jugador2.CartasJugador.Add(jugador1.CartasJugador[0]);
                            //jugador2.CartasJugador.Add(jugador1.CartasJugador[1]);
                            //jugador1.CartasJugador.RemoveAt(0);
                            //jugador1.CartasJugador.RemoveAt(1);
                            resultado = 2;
                            JugadorGanador = jugador2.IDConexion;
                            this.MoverCartas(JugadorGanador, resultado);
                            break;

                        case TipoCarta.Amarilla: //J1: Carta normal, J2: Carta amarilla --> El J2 le roba al J1 la carta que tiene, y se elimina la carta amarilla.
                            ////jugador2.CartasJugador.RemoveAt(0);
                            ////jugador2.CartasJugador.Add(jugador1.CartasJugador[0]);
                            ////jugador1.CartasJugador.RemoveAt(0);
                            resultado = 1;
                            JugadorGanador = jugador2.IDConexion;
                            this.MoverCartas(JugadorGanador, resultado);
                            break;

                    }
                    break;

              
            }

            if (jugador1.CartasJugador.Count==0 || jugador2.CartasJugador.Count==0)
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
