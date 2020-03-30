using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_EDII
{
    public class Ruta
    {
        int x { get; set; }
        int y { get; set; }
        string texto { get; set; }
        string nombreArchivo { get; set; }

        char[,] matrix;

        public Ruta(int m, int n, string texto, string nombreArchivo)
        {
            this.x = x;
            this.y = y;
            this.nombreArchivo = nombreArchivo;
            matrix = new char[m, n];
            texto = texto.Remove(texto.Length - 1);
            texto = texto.Remove(texto.Length - 1);
            this.texto = texto;
        }

        public void vertical()
        {
            int cont = 0;
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (cont != texto.Length)
                        matrix[j, i] = texto[cont];
                    else
                        matrix[j, i] = '#';
                    cont++;
                }
            }
            string outPut = "";
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    outPut += matrix[i, j];
                }
            }
            string folder = @"C:\Cifrado\";
            string fullPath = folder + nombreArchivo;
            DirectoryInfo directory = Directory.CreateDirectory(folder);
            using (StreamWriter file = new StreamWriter(fullPath))
            {
                file.WriteLine(outPut);
                file.Close();
            }
        }
        public void decipherVertical()
        {
            int cont = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = texto[cont];
                    cont++;
                }
            }
            string outPut = "";
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    outPut += matrix[j, i];
                }
            }
            outPut = outPut.Replace('#', ' ');
            string folder = @"C:\Cifrado\";
            string fullPath = folder + nombreArchivo;
            DirectoryInfo directory = Directory.CreateDirectory(folder);
            using (StreamWriter file = new StreamWriter(fullPath))
            {
                file.WriteLine(outPut);
                file.Close();
            }
        }
        public void spiral()
        {
            int cont = 0;
            bool right = true, down = false, left = false, up = false;
            int a = 0, b = 0;
            for (int i = 0; i < x * y; i++)
            {
                if (right)
                {
                    if (b < y && matrix[a, b] == '\0')
                    {
                        matrix[a, b] = (cont < texto.Length) ? texto[cont] : '#';
                        cont++;
                        b++;
                    }
                    else
                    {
                        b--;
                        a++;
                        right = false;
                        down = true;
                        i--;
                    }
                }
                else if (down)
                {
                    if (a < x && matrix[a, b] == '\0')
                    {
                        matrix[a, b] = (cont < texto.Length) ? texto[cont] : '#';
                        cont++;
                        a++;
                    }
                    else
                    {
                        a--;
                        b--;
                        down = false;
                        left = true;
                        i--;
                    }
                }
                else if (left)
                {
                    if (b > -1 && matrix[a, b] == '\0')
                    {
                        matrix[a, b] = (cont < texto.Length) ? texto[cont] : '#';
                        cont++;
                        b--;
                    }
                    else
                    {
                        b++;
                        a--;
                        left = false;
                        up = true;
                        i--;
                    }
                }
                else if (up)
                {
                    if (a > -1 && matrix[a, b] == '\0')
                    {
                        matrix[a, b] = (cont < texto.Length) ? texto[cont] : '#';
                        cont++;
                        a--;
                    }
                    else
                    {
                        b++;
                        a++;
                        up = false;
                        right = true;
                        i--;
                    }
                }
            }
            string outPut = "";
            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    outPut += matrix[i, j];
                }
            } 
            string folder = @"C:\Cifrado\";
            string fullPath = folder + nombreArchivo;
            DirectoryInfo directory = Directory.CreateDirectory(folder);
            using (StreamWriter file = new StreamWriter(fullPath))
            {
                file.WriteLine(outPut);
                file.Close();
            }
        }
        public void decipherSpiral()
        {
            int cont = 0;
            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    matrix[i, j] = texto[cont];
                    cont++;
                }
            }
            string output = "";
            bool right = true, down = false, left = false, up = false;
            int a = 0, b = 0;
            for (int i = 0; i < x * y; i++)
            {
                if (right)
                {
                    if (b < y && matrix[a, b] != '\0')
                    {
                        output += matrix[a, b].ToString();
                        matrix[a, b] = '\0';
                        b++;
                    }
                    else
                    {
                        b--;
                        a++;
                        right = false;
                        down = true;
                        i--;
                    }
                }
                else if (down)
                {
                    if (a < x && matrix[a, b] != '\0')
                    {
                        output += matrix[a, b].ToString();
                        matrix[a, b] = '\0';
                        a++;
                    }
                    else
                    {
                        a--;
                        b--;
                        down = false;
                        left = true;
                        i--;
                    }
                }
                else if (left)
                {
                    if (b > -1 && matrix[a, b] != '\0')
                    {
                        output += matrix[a, b].ToString();
                        matrix[a, b] = '\0';
                        b--;
                    }
                    else
                    {
                        b++;
                        a--;
                        left = false;
                        up = true;
                        i--;
                    }
                }
                else if (up)
                {
                    if (a > -1 && matrix[a, b] != '\0')
                    {
                        output += matrix[a, b].ToString();
                        matrix[a, b] = '\0';
                        a--;
                    }
                    else
                    {
                        b++;
                        a++;
                        up = false;
                        right = true;
                        i--;
                    }
                }
            }
            string folder = @"C:\Decipher\";
            string fullPath = folder + nombreArchivo;
            DirectoryInfo directory = Directory.CreateDirectory(folder);
            using (StreamWriter file = new StreamWriter(fullPath))
            {
                file.WriteLine(output);
                file.Close();
            }
        }
    }
}
