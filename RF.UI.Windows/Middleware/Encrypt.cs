using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RF.UI.Windows.Middleware
{
    public class Encrypt
    {
        public static string GetSHA256(string str)
        {
            // Crear una instancia del algoritmo SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convertir la cadena a un arreglo de bytes
                byte[] bytes = Encoding.ASCII.GetBytes(str);

                // Obtener el hash de los bytes
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Convertir el arreglo de bytes a una cadena hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.AppendFormat("{0:x2}", b);
                }

                return sb.ToString();
            }
        }
    }
}
