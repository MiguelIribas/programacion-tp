﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico.Clases
{
    public enum TipoCarta
    {
        Normal,Roja,Amarilla
    }

    public class Carta
    {
        public TipoCarta Tipo { get; set; }
        public List<Atributo> Atributos { get; set; }
    }
}
