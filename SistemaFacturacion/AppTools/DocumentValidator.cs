using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.AppTools
    {
   public class DocumentValidator
        {
      
            private int[] _multiplies;
            int _lengthRnc, _lengthCedula;

            public enum DocumentType : byte { Cedula, Rnc, Pasaporte, Licencia }

            public DocumentValidator()
                {
                _multiplies = new int[] { 7, 9, 8, 6, 5, 4, 3, 2 };
                _lengthRnc = 8;
                _lengthCedula = 10;
                }


            private int SumResult(int value)
                {
                int result;
                string number;

                number = value.ToString();
                result = 0;

                foreach (char item in number)
                    result += CharToInt(item);

                return
                    result;
                }

            private int Multiply(int value)
                {
                int result;

                result = IsPar(value) ? 2 : 1;

                return
                    result;
                }

            private bool IsPar(int value)
                {
                bool result;

                if (value == 0)
                    result = false;
                else if (value % 2 == 0)
                    result = false;
                else
                    result = true;

                return
                    result;
                }

            private int CharToInt(char value)
                {
                int result;
                double temp;

                temp = char.GetNumericValue(value);
                result = Convert.ToInt32(temp);

                return
                    result;
                }

            /// <summary>
            /// Validate if a rnc is a valid one.
            /// </summary>
            /// <param name="rnc">rnc with not special charaters.</param>
            /// <returns>bool</returns>
            public bool IsValidModulo11(string rnc)
                {
                bool result;
                int sum, modulo, digit, numericRnc;

                if (!string.IsNullOrWhiteSpace(rnc) && rnc.Length == _lengthRnc + 1 && int.TryParse(rnc, out numericRnc))
                    {

                    sum = 0;

                    for (int i = 0; i < _lengthRnc; i++)
                        sum += this.CharToInt(rnc[i]) * _multiplies[i];

                    modulo = sum % 11;
                    digit = 11 - modulo;

                    result = digit == this.CharToInt(rnc[_lengthRnc]);
                    }
                else
                    result = false;

                return
                    result;
                }

            /// <summary>
            /// Validate if a cedula is a valid one.
            /// </summary>
            /// <param name="cedula">cedula with not special charaters.</param>
            /// <returns>bool</returns>
            public bool IsValidModulo10(string cedula)
                {
                bool result;
                int sum, modulo, digit, tempDigit;
                double numericRnc;

                if (!string.IsNullOrWhiteSpace(cedula) && cedula.Length == _lengthCedula + 1 && double.TryParse(cedula, out numericRnc))
                    {
                    sum = 0;

                    for (int i = 0; i < _lengthCedula; i++)
                        sum += this.SumResult(this.CharToInt(cedula[i]) * this.Multiply(i));

                    modulo = sum % 10;
                    digit = 10 - modulo;
                    tempDigit = this.CharToInt(cedula[_lengthCedula]);

                    result = digit == tempDigit;

                    if (!result && digit == 10 && tempDigit == 0)
                        result = true;
                    }
                else
                    result = false;

                return
                    result;
                }
            }

        }
    

