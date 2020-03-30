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
        string texto;
        string nombreArchivo { get; set; }
        int rails { get; set; }
        public void calculate(int rails, StringBuilder input, string nombreArchivo)
        {
            this.nombreArchivo = nombreArchivo;
            this.rails = rails;
            texto = input.ToString();
            texto = texto.Remove(texto.Length - 1);
            texto = texto.Remove(texto.Length - 1);
            float charQty = 1 + 1 + (2 * (rails - 2));
            float unit = charQty / (charQty * charQty);
            float auxLength = texto.Length;
            float waves = auxLength / charQty;
            double rest = waves - Math.Truncate(waves);

            rest = 1 - rest;
            rest = rest / unit;

            for (int i = 0; i < rest; i++)
            {
                texto += "#";
            }

            fillMatrix(rails, texto);

        }
        public void fillMatrix(int rails, string texto)
        {
            string[,] matrix = new string[rails, texto.Length];
            int cont = 0;
            while (cont != texto.Length)
            {
                for (int j = 0; j < rails; j++)
                {
                    matrix[j, cont] = texto[cont].ToString();
                    cont++;
                }

                for (int i = rails - 2; i > 0; i--)
                {
                    matrix[i, cont] = texto[cont].ToString();
                    cont++;
                }
            }

            cipher(matrix);
        }

        public void cipher(string[,] matrix)
        {
            string encryptedtexto = "";

            for (int i = 0; i < rails; i++)
            {
                for (int j = 0; j < texto.Length; j++)
                {
                    if (matrix[i, j] != "")
                    {
                        encryptedtexto += matrix[i, j];
                    }
                }
            }
            string folder = @"C:\Cipher\";
            string fullPath = folder + nombreArchivo;
            DirectoryInfo directory = Directory.CreateDirectory(folder);
            using (StreamWriter file = new StreamWriter(fullPath))
            {
                file.WriteLine(encryptedtexto);
                file.Close();
            }
        }
        public void decipher(int rails, StringBuilder input, string nombreArchivo)
        {
            this.texto = input.ToString();
            this.rails = rails;
            texto = texto.Remove(texto.Length - 1);
            texto = texto.Remove(texto.Length - 1);

            int charQty = 2 + (2 * (rails - 2));
            int picos = texto.Length / charQty;
            string[,] matrix = new string[rails, (texto.Length - (2 * picos)) / (rails - 2)];
            fillMatrix(texto, picos, ref matrix);
            string result = "";
            int cont = 0;
            int colExt = 0;
            int colInt = 0;
            while (cont != texto.Length)
            {
                result += matrix[0, colExt];
                cont++;

                for (int i = 1; i < (rails - 1); i++)
                {
                    result += matrix[i, colInt];
                    cont++;
                }
                colInt++;

                result += matrix[rails - 1, colExt];
                cont++;
                colExt++;

                for (int i = rails - 2; i > 0; i--)
                {
                    result += matrix[i, colInt];
                    cont++;
                }
                colInt++;
            }

            bool deleteAllExtra = false;
            while (!deleteAllExtra)
            {
                if (result[result.Length - 1] == '#')
                {
                    result = result.Remove(result.Length - 1);
                }
                else
                {
                    deleteAllExtra = true;
                }
            }
            string folder = @"C:\Decipher\";
            string fullPath = folder + nombreArchivo;
            DirectoryInfo directory = Directory.CreateDirectory(folder);

            using (StreamWriter file = new StreamWriter(fullPath))
            {
                file.WriteLine(result);
                file.Close();
            }
        }
        private void fillMatrix(string texto, int picos, ref string[,] matrix)
        {
            for (int i = 0; i < picos; i++)
            {
                matrix[0, i] = texto[i].ToString(); 

                int pos = (texto.Length - picos) + i;
                matrix[rails - 1, i] = texto[pos].ToString();
            }

            int split = (texto.Length - (picos * 2)) / (rails - 2);
            int cont = picos;
            for (int i = 1; i < rails - 1; i++)
            {
                for (int j = 0; j < split; j++)
                {
                    matrix[i, j] = texto[cont].ToString();
                    cont++;
                }
            }
        }
    }
}
