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
        //public List<string> NombreAtributos { get; set; }

        public Juego()
        {
            this.Mazos = new List<Mazo>();
            this.Jugadores = new List<Jugador>();
            this.ObtenerMazos();
            this.Partidas = new List<Partida>();         
        }

        public void AgregarPartida(string nombrejugador, string mazo, string nombrepartida)
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
                if (item.Nombre == NombrePartida && item.Estado==EstadoPartida.Disponible) 
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
                partida.EmpezarJuego();
                return true;
            }
            else
                return false; //DISPARAR EVENTO O MENSAJE O LO QUE SEA
        }
        
        public void CrearJugador (string Nombre,string IDConexion)
        {
            var Jugador = new Jugador() { IDConexion = IDConexion, Nombre = Nombre, IDJugador = Jugadores.Count + 1 };
            Jugadores.Add(Jugador);
            
        }
       
        public List<string> ObtenerPartidas()
        {
            var Lista = Partidas.Where(x => x.Estado == EstadoPartida.Disponible).ToList();
            List<string> nombrespartidas = new List<string>();
            foreach (var item in Lista)
            {
                nombrespartidas.Add(item.Nombre);
            }
            return nombrespartidas;
        }
       
        public void ObtenerMazos()
        {                         
            var deckFolder = Directory.GetDirectories(@"E:\Programacion II\TrabajoPractico\TrabajoPractico.Web\Mazos"); //////PONER DIRECCION

            foreach (var deck in deckFolder)
            {
                var lines = File.ReadAllLines(deck + "\\informacion.txt"); /// Ver como es el txt y que adentro no tenga espacio
                int contador = 0;
                List<string> lista = new List<string>();
                Mazo mazo = new Mazo();

                foreach (var line in lines)
                {

                    var array = line.Split('|');

                    if (contador == 0)
                    {
                        mazo.IDMazo = Mazos.Count + 1;
                        mazo.Nombre = line;
                        contador = 1;
                    }
                    else
                    {
                        if (contador == 1)
                        {
                            var atributos = array;
                            contador = contador + 1;
                            var posicion = -1;

                            foreach (var item in atributos)
                            {
                                posicion += 1;
                                if (posicion > 1)
                                {
                                    lista.Add(item);
                                }
                            }
                            mazo.AtributosMazo = lista;
                        }
                        else
                        {
                            Carta carta = new Carta();
                            carta.Codigo = array[0];
                            carta.Nombre = array[1];
                            carta.Tipo = TipoCarta.Normal;

                            var valor = 2;

                            foreach (var item in lista)
                            {
                                Atributo atributo = new Atributo();
                                atributo.Nombre = item;
                                carta.Atributos.Add(atributo);
                            }

                            foreach (var item in carta.Atributos)
                            {
                                if (valor < array.Count())
                                {
                                    item.Valor = Convert.ToDecimal(array[valor]);
                                    valor = valor + 1;
                                }
                            }
        
                            mazo.Cartas.Add(carta);
                        }
                     }
                }
                Carta cartaamarilla = new Carta();
                cartaamarilla.Tipo = TipoCarta.Amarilla;
                cartaamarilla.Nombre = "Amarilla";
                Carta cartaroja = new Carta();
                cartaroja.Tipo = TipoCarta.Roja;
                cartaroja.Nombre = "Roja";
                mazo.Cartas.Add(cartaamarilla);
                mazo.Cartas.Add(cartaroja);

                this.Mazos.Add(mazo);
                }
              
               
                
        }

        public Partida BuscarPartidaID(string idConexion)
        {
            Partida partida=new Partida();
            foreach (var item in Partidas)
            {
                foreach (var item2 in item.JugadoresPartida)
                {
                    if (item2.IDConexion==idConexion)
                    {
                        partida = item;
                    }
                }
            }
            return partida;
        }

        public List<string> NombreMazos()
        {
            List<string> NombreMazos = new List<string>();

            foreach (var item in Mazos)
            {
                NombreMazos.Add(item.Nombre);
            }

            return NombreMazos;
        }


    }
}
