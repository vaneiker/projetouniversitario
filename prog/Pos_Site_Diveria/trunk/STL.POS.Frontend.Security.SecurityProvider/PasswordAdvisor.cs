using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace STL.POS.Frontend.Security.SecurityProvider
{
    public enum PasswordScore
    {
        Blank = 0,
        VeryWeak = 1,
        Weak = 2,
        Medium = 3,
        Strong = 4,
        VeryStrong = 5
    }

    public class PasswordAdvisor
    {

        public static string GetStrenghtAdvise(PasswordScore score)
        {
            var error = string.Empty;
            switch(score)
            {
                case (PasswordScore.Blank):
                    {
                        error="La contraseña es obligatoria.";
                        break;
                    }
                case (PasswordScore.VeryWeak):
                    {
                        error="La contraseña es muy débil. Debe contener al menos 4 caracteres, entre letras y números.";
                        break;
                    }
                case (PasswordScore.Weak):
                    {
                        error = "La contraseña es débil. Debe contener más de 8 caracteres, entre letras y números.";
                        break;
                    }
                case (PasswordScore.Medium):
                    {
                        error="La contraseña es buena. Agregue más letras mayúsculas y minúsculas y dígitos para hacerla más fuerte (más de 8 caracteres de longitud).";
                        break;
                    }
                case (PasswordScore.Strong):
                    {
                        error="La contraseña es fuerte. Agregue más letras mayúsculas y minúsculas, dígitos y caracteres especiales para hacerla más fuerte (más de 8 caracteres de longitud).";
                        break;
                    }
                case (PasswordScore.VeryStrong):
                    {
                        error="La contraseña generada es muy fuerte.";
                        break;
                    }
            }

            return error;
        }

        public static PasswordScore CheckStrength(string password)
        {
            int score = 1;

            if (password.Length < 1)
                return PasswordScore.Blank;
            if (password.Length < 4)
                return PasswordScore.VeryWeak;

            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.Match(password, @"\d+").Success)
                score++;
            if (Regex.Match(password, @"[a-z]").Success &&
              Regex.Match(password, @"[A-Z]").Success)
                score++;
            if (Regex.Match(password, @".[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]").Success)
                score++;

            return (PasswordScore)score;
        }
    }
}
