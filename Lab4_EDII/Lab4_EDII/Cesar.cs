using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_EDII
{
    public class Cesar
    {
        string palabraClave { get; set; }
        List<char> nuevoAlfabeto = new List<char>();
        List<char> alfabetoOriginal = new List<char>();
        bool flag;
        public Cesar(string word)
        {
            palabraClave = word;
        }
        public void buildAlphabet()
        {
            List<byte> modified = new List<byte>();
            List<byte> original = new List<byte>();

            byte[] keyWrdByt = Encoding.ASCII.GetBytes(palabraClave);
            modified.AddRange(keyWrdByt);

            for (int i = 97; i < 123; i++)
            {
                original.Add((byte)i);
                modified.Add((byte)i);
            }

            modified = modified.Distinct().ToList();

            for (int i = 0; i < original.Count; i++)
            {
                alfabetoOriginal.Add(Convert.ToChar(original[i]));
            }

            for (int i = 0; i < modified.Count; i++)
            {
                nuevoAlfabeto.Add(Convert.ToChar(modified[i]));
            }
        }
        private int searchInAlphabet(char character)
        {
            for (int i = 0; i < alfabetoOriginal.Count; i++)
            {
                if (character == alfabetoOriginal[i])
                {
                    flag = false;
                    return i;
                }
                else if (character == Char.ToUpper(alfabetoOriginal[i]))
                {
                    flag = true;
                    return i;
                }
            }
            return -1;
        }
        private int searchInnuevoAlfabeto(char character)
        {
            for (int i = 0; i < nuevoAlfabeto.Count; i++)
            {
                if (character == nuevoAlfabeto[i])
                {
                    flag = false;
                    return i;
                }
                else if (character == Char.ToUpper(nuevoAlfabeto[i]))
                {
                    flag = true;
                    return i;
                }
            }
            return -1;
        }
        public void cipher(StringBuilder input, string fileName)
        {
            string encryptedText = "";
            string text = input.ToString();
            text = input.ToString();
            text = text.Remove(text.Length - 1);
            text = text.Remove(text.Length - 1);
            for (int i = 0; i < text.Length; i++)
            {
                int aux = searchInAlphabet(text[i]);
                if (aux == -1)
                {
                    encryptedText += text[i];
                }
                else
                {
                    if (flag)
                        encryptedText += char.ToUpper(nuevoAlfabeto[aux]);
                    else
                        encryptedText += nuevoAlfabeto[aux];
                }
            }

            string folder = @"C:\";
            string fullPath = folder + fileName;
            DirectoryInfo directory = Directory.CreateDirectory(folder);
            using (StreamWriter file = new StreamWriter(fullPath))
            {
                file.WriteLine(encryptedText);
                file.Close();
            }
        }
        public void decipher(StringBuilder input, string fileName)
        {
            string decipherText = "";
            string text = input.ToString();
            text = input.ToString();
            text = text.Remove(text.Length - 1);
            text = text.Remove(text.Length - 1);
            for (int i = 0; i < text.Length; i++)
            {
                int aux = searchInnuevoAlfabeto(text[i]);
                if (aux == -1)
                {
                    decipherText += text[i];
                }
                else
                {
                    if (flag)
                        decipherText += char.ToUpper(alfabetoOriginal[aux]);
                    else
                        decipherText += alfabetoOriginal[aux];
                }
            }
            string folder = @"C:\";
            string fullPath = folder + fileName;
            DirectoryInfo directory = Directory.CreateDirectory(folder);
            using (StreamWriter file = new StreamWriter(fullPath))
            {
                file.WriteLine(decipherText);
                file.Close();
            }
        }
    }
}