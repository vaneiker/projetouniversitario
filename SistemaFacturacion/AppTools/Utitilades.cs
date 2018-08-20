using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaFacturacion.AppTools
{
    public static class Util{

        public static void SoloNumeros(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)
                || char.IsSurrogate(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
    
}