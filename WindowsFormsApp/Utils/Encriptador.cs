using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Generators;

namespace WindowsFormsApp.Utils
{
    public class Encriptador
    {
        // Método para encriptar la contraseña usando bcrypt
    public static string EncriptarContraseña(string pwd)
    {
        // Generamos un "salt" y encriptamos la contraseña
        string pwdEncriptada = BCrypt.Net.BCrypt.HashPassword(pwd);
        return pwdEncriptada;
    }

    // Método para verificar si la contraseña ingresada coincide con la encriptada
    public static bool VerificarContraseña(string pwd, string pwdEncriptada)
    {
        // Verificamos si la contraseña coincide con la contraseña encriptada
        return BCrypt.Net.BCrypt.Verify(pwd, pwdEncriptada);
    }
    }
}
