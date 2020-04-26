using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IO;
using Lab4_EDII;

namespace CifradoController.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CifradoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost("{name}/{fileName}/{param}")]
        public string Post([FromForm(Name = "file")] IFormFile file, string name, string fileName, string param)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(reader.ReadLine());
            }

            if (name.ToLower().Equals("zigzag"))
            {
                zigzag zigzagCipher = new zigzag();
                zigzagCipher.calculate(int.Parse(param), result, fileName);
                return "El texto ha sido encriptado por el método de ZigZag";
            }
            else if (name.ToLower().Equals("caesar"))
            {
                Cesar caesarCipher = new Cesar(param);
                caesarCipher.buildAlphabet();
                caesarCipher.cipher(result, fileName);
                return "El texto ha sido encriptado por el método Cesar";
            }
            else if (name.ToLower().Equals("ruta"))
            {
                string[] parameters = param.Split(',');
                string[] dimensiones = parameters[0].Split('x');
                int m = int.Parse(dimensiones[0]);
                int n = int.Parse(dimensiones[1]);
                RutaEspiral routeCipher = new RutaEspiral(m, n, result.ToString(), fileName);
                if (parameters[1].ToLower().Equals("vertical"))
                {
                    routeCipher.vertical();
                }
                else
                {
                    routeCipher.spiral();
                }

                return "El texto ha sido encriptado por el método de Ruta";
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