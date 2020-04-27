using Lab4_EDII.Modelos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_EDII.Controllers
{
    public class CifradoController
    {
        public static IWebHostEnvironment _environment;
        public CifradoController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpGet("cipher/ZigZag")]
        public string CifrarZigZag([FromForm]DataZigZag CifrarZigZag)
        {
            if (!Directory.Exists(_environment.WebRootPath + "\\ArchivosCifradosZigZag\\"))
            {
                Directory.CreateDirectory(_environment.WebRootPath + "\\ArchivosCifradosZigZag\\");
            }
            zigzag CifradoZigZag = new zigzag();
            CifradoZigZag.CifradoZigZag(CifrarZigZag.ArchivoCargado, CifrarZigZag.TamañoCarriles, CifrarZigZag.NuevoNombre, _environment.WebRootPath + "\\ArchivosCifradosZigZag\\");
            return ("ArchivosCifradosZigZag en la Carpeta 'wwwroot' dentro de la carpeta del Laboratorio");
        }

        [HttpGet("decipher/ZigZag")]
        public string DescifrarZigZag([FromForm]DataZigZag DescifrarZigZag)
        {
            if (!Directory.Exists(_environment.WebRootPath + "\\ArchivosDescifradosZigZag\\"))
            {
                Directory.CreateDirectory(_environment.WebRootPath + "\\ArchivosDescifradosZigZag\\");
            }
            zigzag DescifradoZigZag = new zigzag();
            DescifradoZigZag.DescifradoZigZag(DescifrarZigZag.ArchivoCargado, DescifrarZigZag.TamañoCarriles, DescifrarZigZag.NuevoNombre, _environment.WebRootPath + "\\ArchivosDescifradosZigZag\\");
            return ("ArchivosDecifradosZigZag en la Carpeta 'wwwroot' dentro de la carpeta del Laboratorio");
        }
        /*[HttpGet("DescifradoZigZag")]*/
        [HttpGet("CifradoCesar")]
        public void CifrarCesar([FromForm]DataCesar CifrarCesar)
        {
            if (!Directory.Exists(_environment.WebRootPath + "\\ArchivosCifradosCesar\\"))
            {
                Directory.CreateDirectory(_environment.WebRootPath + "\\ArchivosCifradosCesar\\");
            }
            Cesar CifradoCesar = new Cesar();
            CifradoCesar.CifradoCesar(CifrarCesar.ArchivoCargado, CifrarCesar.Llave, CifrarCesar.NuevoNombre, _environment.WebRootPath + "\\ArchivosCifradosCesar\\");
        }
        [HttpGet("DescifradoCesar")]
        public void DescifrarCesar([FromForm]DataCesar DescifrarCesar)
        {
            if (!Directory.Exists(_environment.WebRootPath + "\\ArchivosCifradosCesar\\"))
            {
                Directory.CreateDirectory(_environment.WebRootPath + "\\ArchivosCifradosCesar\\");
            }
            Cesar DescifradoCesar = new Cesar();
            DescifradoCesar.CifradoCesar(DescifrarCesar.ArchivoCargado, DescifrarCesar.Llave, DescifrarCesar.NuevoNombre, _environment.WebRootPath + "\\ArchivosDescifradosCesar\\");
        }
    }
}
