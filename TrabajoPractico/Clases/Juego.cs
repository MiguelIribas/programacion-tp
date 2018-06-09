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

        public Juego()
        {
            this.Jugadores = new List<Jugador>();
<<<<<<< HEAD
            this.Mazos = ObtenerMazos();
=======
            this.Mazos = this.ObtenerMazos();
>>>>>>> be7b05c0194fa70a40d64223badd20e86c0daf7d
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
       
        public List<Partida> ObtenerPartidas()
        {
            return Partidas.Where(x => x.Estado == EstadoPartida.Disponible).ToList();
        }
       
        public List<Mazo> ObtenerMazos()
        {
<<<<<<< HEAD
            var mazos = new List<Mazo>();

            var carpetasMazos = Directory.GetDirectories(@"C:");

            foreach (var mazo in carpetasMazos)
            {
                var lines = File.ReadAllLines(mazo + "/instrucciones.txt");
=======
            var deckFolder = Directory.GetDirectories(@"E:\Mis documentos\agos\Mazos"); //////PONER DIRECCION
            
            foreach (var deck in deckFolder)
            {
                var lines = File.ReadAllLines(deck + "\\informacion.txt"); /// Ver como es el txt y que adentro no tenga espacio
                int contador = 0;
                List<Atributo> lista = new List<Atributo>();
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

                            foreach (var item in atributos)
                            {
                                Atributo nuevo = new Atributo();
                                nuevo.Nombre = item;

                                lista.Add(nuevo);

                            }

                        }
                        else
                        {
                            Carta carta = new Carta();
                            carta.Codigo = array[0];
                            carta.Nombre = array[1];
                            carta.Tipo = TipoCarta.Normal;
                            carta.Atributos = lista;
                            var valor = 2;

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

                Mazos.Add(mazo);
                
            }

            return Mazos;
        }

        
>>>>>>> be7b05c0194fa70a40d64223badd20e86c0daf7d

                foreach (var line in lines)
                {
                    // Lógica acá
                }
            }
            /*var lines = File.ReadAllLines(@"D:\prueba.txt");

      foreach (var line in lines)
     {
         // Lógica acá
     } */

            return Mazos;
        }

    }
}
