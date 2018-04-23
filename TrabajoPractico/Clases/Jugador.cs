﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Clases
{
    public class Jugador
    {
        public int IDJugador { get; set; }
        public int IDConexion { get; set; }
        public string Nombre { get; set; }
        public bool Turno { get; set; }
        public List<Carta> CartasJugador { get; set; }
        
 
    }
}
