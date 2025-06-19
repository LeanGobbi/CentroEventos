using System.Security.Cryptography;
using System.Text;

namespace CentroEventos.Aplicacion.Interfaces;

public static class SHA_256
{
    public static string ObtenerSHA256(string texto)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] bytesTexto = Encoding.UTF8.GetBytes(texto);
        byte[] hashBytes = sha256.ComputeHash(bytesTexto);

        // Convertimos el array de bytes a string hexadecimal
        StringBuilder resultado = new StringBuilder();
        foreach (byte b in hashBytes)
        {
            resultado.Append(b.ToString("x2")); // hexadecimal en minúscula
        }

        return resultado.ToString();
    }
}