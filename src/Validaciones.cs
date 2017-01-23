using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilaCalc
{
    class Validaciones
    {
        public bool ValidaCadena(string valorCadena)
        {
            string valores = "0 1 2 3 4 5 6 7 8 9 + - * / ( ) .";
            int cuentaLetras;
            string letra = "";
            int opSeguido = 0;
            int secuenciaValid = 0;
            int condicion = 0;
            cuentaLetras = valorCadena.Length - 1;
            for (int i = 0; i <= cuentaLetras; i++)
            {
                letra = valorCadena.Substring(i, 1);
                if (!valores.Contains(letra))
                {
                    condicion = 0;
                    break;
                }
                else
                {
                    if (secuenciaValid == 0)
                    {
                        if (letra == "+" || letra == "*" || letra == "/")
                        {
                            condicion = 0;
                            break;
                        }
                    }
                    if (secuenciaValid == cuentaLetras)
                    {
                        if (letra == "+" || letra == "-" || letra == "*" || letra == "/")
                        {
                            condicion = 0;
                            break;
                        }
                    }

                    if (letra == "+" || letra == "-" || letra == "*" || letra == "/")
                    {
                        opSeguido++;
                    }
                    else
                    {
                        opSeguido = 0;
                    }
                    if (opSeguido > 1)
                    {
                        /*if (letra == "-")
                        { */
                            if (opSeguido < 2)
                            {
                                opSeguido = 0;
                            }
                        /*}*/
                        else
                        {
                            condicion = 0;
                            break;
                        }
                    }
                    condicion = 1;
                    secuenciaValid++;
                }
            }
            if (condicion == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
