using Lab4_EDII.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_EDII.Modelos
{
    public class DataCesar : InterfaceDataCesar<int>
    {
        public IFormFile ArchivoCargado { get; set; }
        public int Llave { get; set; }
        public string NuevoNombre { get; set; }
    }
}