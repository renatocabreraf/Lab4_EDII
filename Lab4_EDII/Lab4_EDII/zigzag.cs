using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_EDII
{
    public class zigzag
    {
        private char[] VerificacionCadena(IFormFile Archivo, int TamañoCarril)
        {
            char[] Texto = null;
            char[] Resultado = null;
            char[] Borrador = null;
            string[] Receptor = null;
            string Temp;
            double NumeroOla = ((TamañoCarril * 2) - 2);
            double Ola = 0;
            int tempNumero = 0;
            using (var Lectura = new StreamReader(Archivo.OpenReadStream()))
            {
                var TomaArchivo = new StringBuilder();
                while (Lectura.Peek() >= 0)
                {
                    TomaArchivo.AppendLine(Lectura.ReadLine());
                }
                Temp = TomaArchivo.ToString();
                Borrador = Temp.ToCharArray();
                Receptor = new string[Borrador.Length - 2];
                for (int i = 0; i < Borrador.Length - 2; i++)
                {
                    Receptor[i] = Borrador[i].ToString();
                }
                Temp = String.Concat(Receptor);

                if (Temp.Contains("\r\n"))
                {
                    Temp = Temp.Replace("\r\n", "\n");
                }
                Texto = Temp.ToCharArray();

            }
            Ola = Texto.Length / NumeroOla;
            if (Ola % 1 != 0)
            {
                double resulado1 = ((Ola % 1) - 1) * -1;
                Ola = Ola + resulado1;
                Resultado = new char[Convert.ToInt32(Ola * NumeroOla)];
                for (int i = 0; i < Texto.Length; i++)
                {
                    Resultado[i] = Texto[i];
                }
                tempNumero = ((Convert.ToInt32(Ola * NumeroOla)) - 1);
                for (int i = tempNumero - 1; i < Ola * NumeroOla; i++)
                {
                    Resultado[i] = '#';
                }
            }
            else
            {
                Resultado = Texto;
            }
            return Resultado;
        }

        public void CifradoZigZag(IFormFile Archivo, int TamañoCarril, string NombreArchivo, string path)
        {
            TamañoCarril = 3;
            char[] ArregloValores = VerificacionCadena(Archivo, TamañoCarril);
            string[] CadenaCifrada = new string[ArregloValores.Length];
            int contador = 0;
            if (TamañoCarril == 3)
            {
                for (int i = 1; i <= TamañoCarril; i++)
                {
                    for (int j = i - 1; j < ArregloValores.Length; j = j + (TamañoCarril + 1))
                    {
                        if (i <= TamañoCarril - 1 && i != (TamañoCarril - TamañoCarril + 1) && i != TamañoCarril)
                        {
                            for (int k = j; k < ArregloValores.Length; k = k + 2)
                            {
                                CadenaCifrada[contador] = ArregloValores[k].ToString();
                                contador++;
                            }
                            i++;
                            j = j - 3;
                        }
                        else
                        {
                            CadenaCifrada[contador] = ArregloValores[j].ToString();
                            contador++;
                        }
                    }
                }
            }
            EscrituraCifradoZigZag(CadenaCifrada, NombreArchivo, path);
        }
        private void EscrituraCifradoZigZag(string[] CadenaCifrada, string NombreArchivo, string pathArchivo)
        {
            var path = Path.Combine(pathArchivo, System.IO.Path.GetFileNameWithoutExtension(NombreArchivo) + ".txt");
            using (StreamWriter Escritura = new StreamWriter(path))
            {
                foreach (string item in CadenaCifrada)
                {
                    Escritura.Write(item);
                }
                Escritura.Close();
            }

        }

        public void DescifradoZigZag(IFormFile Archivo, int TamañoCarril, string NombreArchivo, string Path)
        {
            TamañoCarril = 3;
            string Temp = "";
            char[] Borrador = null;
            string[] receptor = null;
            char[] charResultado = null;
            double CantidadOla = 0;
            double CantidadElementos = 0;
            string[] CadenaInicio;
            string[] CadenaFinal;
            string[] CadenaMedio;

            using (var Lectura = new StreamReader(Archivo.OpenReadStream()))
            {
                var TomaArchivo = new StringBuilder();
                while (Lectura.Peek() >= 0)
                {
                    TomaArchivo.AppendLine(Lectura.ReadLine());
                }
                Temp = TomaArchivo.ToString();
                Borrador = Temp.ToCharArray();
                receptor = new string[Borrador.Length - 2];
                for (int i = 0; i < Borrador.Length - 2; i++)
                {
                    receptor[i] = Borrador[i].ToString();
                }
                Temp = String.Concat(receptor);

                Temp = Temp.Replace("\r\n", "\n");
                if (Temp.Contains("\r\n"))
                {
                    Temp.Replace("\r\n", "\n");
                }
                charResultado = Temp.ToCharArray();
                CantidadElementos = (TamañoCarril * 2) - 2;
                CantidadOla = charResultado.Length / CantidadElementos;
                CadenaInicio = new string[Convert.ToInt32(CantidadOla)];
                CadenaFinal = new string[Convert.ToInt32(CantidadOla)];
                CadenaMedio = new string[charResultado.Length - (Convert.ToInt32(CantidadOla) * 2)];
                int aux = 0;
                for (int i = 0; i < CantidadOla; i++)
                {
                    CadenaInicio[i] = charResultado[i].ToString();
                }

                for (int j = ((charResultado.Length) - Convert.ToInt32(CantidadOla)); j < charResultado.Length; j++)
                {
                    CadenaFinal[aux] = charResultado[j].ToString();
                    aux++;
                }
                aux = 0;
                for (int k = Convert.ToInt32(CantidadOla); k < (charResultado.Length - Convert.ToInt32(CantidadOla)); k++)
                {
                    CadenaMedio[aux] = charResultado[k].ToString();
                    aux++;
                }

                int ContadorInicio = 0;
                int ContadorMedio = 0;
                int ContadorFinal = 0;
                int ValorContador = 1;
                int TempContador = 0;
                string[] CadenaResultado = new string[charResultado.Length];
                int data = 0;  
                for (int n = 0; n < charResultado.Length; n = n)
                {

                    if (ValorContador == 1)
                    {
                        CadenaResultado[data] = CadenaInicio[ContadorInicio];
                        ValorContador++;
                        n++;
                        ContadorInicio++;
                        TempContador = 1;
                        data++;
                    }
                    if (ValorContador == 2)
                    {
                        CadenaResultado[data] = CadenaMedio[ContadorMedio];
                        ValorContador++;
                        if (TempContador == 3)
                        {
                            ValorContador = 1;
                        }
                        TempContador = 2;
                        n++;
                        ContadorMedio++;
                        data++;
                    }
                    if (ValorContador == 3)
                    {
                        CadenaResultado[data] = CadenaFinal[ContadorFinal];
                        TempContador = 3;
                        ValorContador--;
                        n++;
                        ContadorFinal++;
                        data++;
                    }
                }
                Lectura.Close();
                EscrituraDescifradoZigZag(CadenaResultado, NombreArchivo, Path);
            }

        }
        private void EscrituraDescifradoZigZag(string[] CadenaResultado, string NombreArchivo, string pathArchivo)
        {
            for (int i = 0; i < CadenaResultado.Length; i++)
            {
                if (CadenaResultado[i] == "#")
                {
                    CadenaResultado[i] = "";
                }
            }
            var path = Path.Combine(pathArchivo, System.IO.Path.GetFileNameWithoutExtension(NombreArchivo) + ".txt");
            using (StreamWriter Escritura = new StreamWriter(path))
            {
                foreach (string item in CadenaResultado)
                {
                    Escritura.Write(item);
                }
                Escritura.Close();
            }


        }
    }
}
