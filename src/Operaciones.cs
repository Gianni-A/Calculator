using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilaCalc
{
    class Operaciones
    {

        public string Calculadora(string valorCadena)
        {
            string cadena, siguiente;
            string valor1 = "";
            string valor2 = "";
            string valor3 = "";
            string operando = "";
            string operando2 = "";
            int primernumero = 0;
            int cuentaLetras;
            int entroParentesis = 0;
            int cerroParentesis = 0;
            int sigue = 0;
            cadena = valorCadena;
            cuentaLetras = cadena.Length - 1;

            for (int i = 0; i <= cuentaLetras; i++)
            {
                siguiente = cadena.Substring(i, 1);

                if (valor2 != "" && (siguiente == "+" || siguiente == "-" || siguiente == "*" || siguiente == "/" || siguiente == ")") && sigue == 0)
                {
                    if (entroParentesis == 1)
                    {
                        if (valor3 != "" && operando2 != "")
                        {
                            valor2 = CalNums(valor2, valor3, operando2);
                            valor3 = "";
                            operando2 = "";
                            i--;
                            entroParentesis = 0;
                            continue;
                        }
                        else
                        {
                            if (valor1 != "" && valor2 != "" && operando != "")
                            {
                                if (cerroParentesis == 1)
                                {
                                    valor1 = CalNums(valor1, valor2, operando);
                                    valor2 = "";
                                    operando = "";
                                    if (i < cuentaLetras)
                                    {
                                        i--;
                                    }
                                    if (entroParentesis == 1)
                                    {
                                        entroParentesis = 0;
                                    }
                                    continue;
                                }
                            }
                            i--;
                            sigue = 1;
                            continue;
                        }
                    }
                    else
                    {
                        //para calcular con valor1 y valor2
                        valor1 = CalNums(valor1, valor2, operando);
                        operando = "";
                        valor2 = "";
                        if (i != cuentaLetras)
                        {
                            i--;
                        }
                        continue;
                    }
                }
                else
                {
                    while (siguiente == "(")
                    {
                        i++;
                        siguiente = cadena.Substring(i, 1);
                        entroParentesis = 1;
                    }
                    if (siguiente == ")")
                    {
                        sigue = 0;
                        cerroParentesis = 1;
                        i--;
                        continue;
                    }
                    if (siguiente != "+" && siguiente != "-" && siguiente != "*" && siguiente != "/")
                    {
                        if (operando != "")
                        {
                            if (operando2 != "")
                            {
                                if (siguiente == ")")
                                {
                                    sigue = 0;
                                    i--;
                                    continue;
                                }
                                else
                                {
                                    valor3 += siguiente;
                                    continue;
                                }
                            }
                            else
                            {
                                valor2 += siguiente;
                                continue;
                            }

                        }
                        else
                        {
                            if (primernumero == 0)
                            {
                                valor1 += siguiente;
                                continue;
                            }
                        }
                    }
                    else
                    {
                        if (operando == "")
                        {
                            operando = siguiente;
                            primernumero++;
                            continue;
                        }
                        else
                        {
                            if (operando2 == "")
                            {
                                operando2 = siguiente;
                                continue;
                            }
                            else
                            {
                                sigue = 0;
                                i--;
                                continue;
                            }
                        }
                    }

                }
            }
            if (valor1 != "" && valor2 != "" && operando != "")
            {
                valor1 = CalNums(valor1, valor2, operando);
            }
            return valor1;
        }

        public string CalNums(string v1, string v2, string op)
        {
            double opera, n1, n2;
            switch (op)
            {
                case "+":
                    n1 = double.Parse(v1);
                    n2 = double.Parse(v2);
                    opera = n1 + n2;
                    v1 = opera.ToString();
                    break;

                case "-":
                    n1 = double.Parse(v1);
                    n2 = double.Parse(v2);
                    opera = n1 - n2;
                    v1 = opera.ToString();
                    break;

                case "*":
                    n1 = double.Parse(v1);
                    n2 = double.Parse(v2);
                    opera = n1 * n2;
                    v1 = opera.ToString();
                    break;

                case "/":
                    n1 = double.Parse(v1);
                    n2 = double.Parse(v2);
                    opera = n1 / n2;
                    v1 = opera.ToString();
                    break;
            }
            return v1;
        }
    }
}

