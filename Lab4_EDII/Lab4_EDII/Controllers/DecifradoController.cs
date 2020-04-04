using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_EDII.Controllers.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DecipherController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost("{name}/{fileName}/{param}")]
        public string Post([FromForm(Name = "file")] IFormFile file, string name, string fileName, string param)
        {
            //lectura del archivo
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(reader.ReadLine());
            }

            if (name.ToLower().Equals("zigzag"))
            {
                zigzag zigzagCipher = new zigzag();
                zigzagCipher.decipher(int.Parse(param), result, fileName);
                return "Texto desencriptado por el método de ZigZag";
            }
            else if (name.ToLower().Equals("caesar"))
            {
                Cesar caesarCipher = new Cesar(param);
                caesarCipher.buildAlphabet();
                caesarCipher.decipher(result, fileName);
                return "Texto desencriptado por el método Cesar";
            }
            else if (name.ToLower().Equals("ruta"))
            {
                string[] parameters = param.Split(','); 
                string[] dimensiones = parameters[0].Split('x');
                int m = int.Parse(dimensiones[0]);
                int n = int.Parse(dimensiones[1]);
                Ruta routeCipher = new Ruta(m, n, result.ToString(), fileName);
                if (parameters[1].ToLower().Equals("vertical"))
                {
                    routeCipher.decipherVertical();
                }
                else
                {
                    routeCipher.decipherSpiral();
                }
                return "Texto desencriptado por el método de Ruta";
            }
            else
            {
                return "El metodo es incorrecto";
            }

        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}