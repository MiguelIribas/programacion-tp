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
        

        public void EmpezarJuego(Partida partida)
        {
            partida.MezclarMazo(partida.Mazo.Cartas);
            var jugador1 = partida.JugadoresPartida.First();
            var jugador2 = partida.JugadoresPartida.Last();
            partida.RepartirMazo(partida.Mazo, jugador1, jugador2);
            //mostrar cartas graficamente y atributos
        }
        
        //agregar mazo y obtener mazo
        //obtener partida

        public Jugador CrearJugador (string Nombre,int IDConexion)
        {
            var Jugador = new Jugador() { IDConexion = IDConexion, Nombre = Nombre, IDJugador = Jugadores.Count + 1 };
            Jugadores.Add(Jugador);
            return Jugador;
        }

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
                if (item.Nombre==NombrePartida)
                {
                    item.JugadoresPartida.Add(Jugador2);
                    this.EmpezarJuego(item);
                }
            }
        }

        public Jugador CompararCartas(int IDConexion, string Atributo)
        {

            
            //parametris : idatributo, idcarta
            //conexionid = buscar el jugador que canto
            Jugador JugadorGanador = new Jugador(); //En esta variable se va a guardar al jugador que gana en cada caso, no deja retornar antes del break.

            //recorrer lista partidas con el id conexion y buscar jugadores y cartas.
            /* 

             var Carta1 = new Carta();
             var Carta2 = new Carta();
             var jugador1 = new Jugador();
             var jugador2 = new Jugador();
             var partida = new Partida();

             switch (Carta1.Tipo)
             {
                 case TipoCarta.Roja:
                     switch (Carta2.Tipo)
                     {
                         case TipoCarta.Normal: //J1: Carta roja,J2: Carta normal --> El J1 le roba al J2 la carta que tiene y la primera del mazo, y elimina la carta roja.        
                             jugador1.CartasJugador.RemoveAt(0);     
                             jugador1.CartasJugador.Add(jugador2.CartasJugador[0]);
                             jugador1.CartasJugador.Add(jugador2.CartasJugador[1]);
                             jugador2.CartasJugador.RemoveAt(0);
                             jugador2.CartasJugador.RemoveAt(1);
                             JugadorGanador = jugador1;
                             break;

                         case TipoCarta.Amarilla: //J1: Carta roja, J2: Carta amarilla --> El J1 le roba al J2 la primera del mazo, y se eliminan las cartas roja y amarilla.
                             jugador1.CartasJugador.RemoveAt(0);
                             jugador1.CartasJugador.Add(jugador2.CartasJugador[1]);
                             jugador2.CartasJugador.RemoveAt(0);
                             JugadorGanador = jugador1;
                             break;

                         case TipoCarta.Especial:
                             break;

                     }
                     break;

                 case TipoCarta.Amarilla:
                     switch (Carta2.Tipo)
                     {
                         case TipoCarta.Normal: // J1: Carta amarilla, J2: Carta Normal --> El J1 le roba al J2 la carta que tiene, y elimina la carta amarilla.
                             jugador1.CartasJugador.RemoveAt(0);
                             jugador1.CartasJugador.Add(jugador2.CartasJugador[0]);
                             jugador2.CartasJugador.RemoveAt(0);
                             JugadorGanador = jugador1;
                             break;

                         case TipoCarta.Roja: //J1: Carta amarilla, J2: Carta roja --> El J2 le roba al J1 la primera del mazo, y se eliminan las cartas rojas y amarilla.
                             jugador2.CartasJugador.RemoveAt(0);
                             jugador2.CartasJugador.Add(jugador1.CartasJugador[1]);
                             jugador1.CartasJugador.RemoveAt(0);
                             JugadorGanador = jugador2;
                             break;

                         case TipoCarta.Especial:
                             break;
                     }
                     break;


                 case TipoCarta.Normal:
                     switch (Carta2.Tipo)
                     {
                         case TipoCarta.Normal: //Aca deberia dejar elegir los atributos, hacer un metodo aparte.


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

                         case TipoCarta.Roja: // J1: Carta normal, J2: Carta roja --> El J2 le roba al J1 la carta que tiene y la primera del mazo, y se elimina la carta roja.
                             jugador2.CartasJugador.RemoveAt(0);
                             jugador2.CartasJugador.Add(jugador1.CartasJugador[0]);
                             jugador2.CartasJugador.Add(jugador1.CartasJugador[1]);
                             jugador1.CartasJugador.RemoveAt(0);
                             jugador1.CartasJugador.RemoveAt(1);
                             JugadorGanador = jugador2;
                             break;

                         case TipoCarta.Amarilla: //J1: Carta normal, J2: Carta amarilla --> El J2 le roba al J1 la carta que tiene, y se elimina la carta amarilla.
                             jugador2.CartasJugador.RemoveAt(0);
                             jugador2.CartasJugador.Add(jugador1.CartasJugador[0]);
                             jugador1.CartasJugador.RemoveAt(0);
                             JugadorGanador = jugador2;
                             break;

                         case TipoCarta.Especial:
                             //
                             break;
                     }
                     break;

                 case TipoCarta.Especial:
                     switch (Carta2.Tipo)
                     {
                         case TipoCarta.Normal:
                             break;
                         case TipoCarta.Roja:
                             break;
                         case TipoCarta.Amarilla:
                             break;
                     }
                     break;
             }
             */
            return JugadorGanador;

        }

        /*var lines = File.ReadAllLines(@"D:\prueba.txt");

       foreach (var line in lines)
       {
           // Lógica acá
       } */



    }
}
