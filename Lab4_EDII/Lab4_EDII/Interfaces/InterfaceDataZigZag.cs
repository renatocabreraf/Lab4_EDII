﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_EDII.Interfaces
{
    public interface InterfaceDataZigZag<T>
    {
        IFormFile ArchivoCargado { get; set; }
        T TamañoCarriles { get; set; }
        string NuevoNombre { get; set; }

    }
}