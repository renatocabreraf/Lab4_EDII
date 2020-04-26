using Lab4_EDII.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_EDII.Modelos
{
    public class DataRutaVertical : InterfaceDataRutaVertical<int>
    {
        public IFormFile ArchivoCargado { get; set; }
        public int m { get; set; }
        public int n { get; set; }
        public char[,] matriz { get; set; }
        public string NuevoNombre { get; set; }
    }
}