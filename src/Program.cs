using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilaCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            string cadena, resultado;
            Console.Write("Letra l = para limpiar; Letra e = para salir\n");
            while (true) {
                cadena = "";
                resultado = "";
                Console.Write("Ingresa un numero a calcular: ");
                cadena = Console.ReadLine();
                cadena = cadena.Replace(" ", "");
                //Para salir de la aplicacion
                if (cadena.ToLower() == "e")
                {
                    break;
                }
                //Limpiar la consola
                if (cadena.ToLower() == "l")
                {
                    Console.Clear();
                    Console.Write("Letra l = para limpiar; Letra e = para salir\n");
                    continue;
                }
                Operaciones calcula = new Operaciones();
                Validaciones valida = new Validaciones();
                if (valida.ValidaCadena(cadena) == false)
                {
                    Console.WriteLine("La cadena ingresada es incorrecta");
                    Console.ReadLine();
                    continue;
                }  

                resultado = calcula.Calculadora(cadena);

                Console.Write("El resultado es: " + resultado);
                Console.ReadLine();
            }
        }
    }
}
