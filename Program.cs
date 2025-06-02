using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EjerciciosLogica
{
    internal class Program
    {
        public MatrixInt matrixInt;
        //public string obj = "[[[1, 2,3]], [[5, 6, 7],[5, 4, 3]], [[3, 5, 6], [4, 8, 3], [2, 3]]]";
        //public string obj = " [[[1, 2, 3], [2, 3, 4]], [[5, 6, 7], [5, 4, 3]], [[3,5, 6], [4, 8, 3]]]";
        //public string obj = "  [1,2]";


        //public string obj = "[1, 2]";
        //public string obj = "[[1, 2], [2, 4]]";
        //public string obj = "[[1, 2],[2, 4],[2, 4]]";
        //public string obj ="[[[3, 4],[6, 5]]]" ;
        //public string obj ="[[[1, 2, 3]], [[5, 6, 7], [5, 4, 3]], [[3, 5, 6], [4, 8, 3], [2, 3]]] ";
        public string obj = "[[[1, 2, 3], [2, 3, 4]], [[5, 6, 7], [5, 4, 3]], [[3, 5, 6], [4, 8, 3]]]";

        static void Main(string[] args)
        {
            Program p = new Program();

           // p.ObtenerDimension();

            //p.ValidarCantidadMatrix();

            p.SumaMatrix();
        }

        public void ObtenerDimension()
        {
            // Esta línea valida que todas las matrices estén bien formadas, asegurando que por cada '[' haya un ']' correspondiente.
            // asi extrae únicamente las partes válidas del texto para procesarlas correctamente.
            var matches = Regex.Matches(obj, @"\[\s*(?:\[(?:\[(?:[^\[\]]|(?<open>\[)|(?<-open>\]))*\]|[^\[\]]*)\]\s*,?\s*)+\](?(open)(?!))");

            try
            {
                // Intentar parsear directamente el string completo
                var jsonFormateado = JsonConvert.DeserializeObject<object>(obj);

                //Pasamos el objeto al constructor de la clase MatrixInt
                matrixInt = new MatrixInt(jsonFormateado);

                //Asignamos el resultado a una variable local para obtener la dimensión
                int dim = matrixInt.dimension();

                //Imprimimos el resultado.
                Console.WriteLine($"Dimensión: {dim}");
            }
            catch (Exception ex)
            {
                //Si llega a salir un error nos mostrará este mensaje con el error.
                Console.WriteLine("Error al parsear la matriz completa.");
                Console.WriteLine(ex.Message);
            }
        }

        public void ValidarCantidadMatrix()
        {
            var matches = Regex.Matches(obj, @"\[\s*(?:\[(?:\[(?:[^\[\]]|(?<open>\[)|(?<-open>\]))*\]|[^\[\]]*)\]\s*,?\s*)+\](?(open)(?!))");

            try
            {
                var jsonFormateado = JsonConvert.DeserializeObject<object>(obj);

                //Pasamos el objeto al constructor de la clase MatrixInt
                matrixInt = new MatrixInt(jsonFormateado);

                //Asignamos el resultado a una variable local para obtener el resultado del tamaño
                bool tamanio = matrixInt.straight(jsonFormateado);

                //Imprimimos el resultado.
                Console.WriteLine($"Tamaño: {tamanio}");
            }
            catch (Exception ex)
            {
                //Si llega a salir un error nos mostrará este mensaje con el error.
                Console.WriteLine("Error al parsear la matriz completa.");
                Console.WriteLine(ex.Message);
            }
        }


        public void SumaMatrix()
        {
            // Esta línea valida que todas las matrices estén bien formadas, asegurando que por cada '[' haya un ']' correspondiente.
            // asi extrae únicamente las partes válidas del texto para procesarlas correctamente.
            var matches = Regex.Matches(obj, @"\[\s*(?:\[(?:\[(?:[^\[\]]|(?<open>\[)|(?<-open>\]))*\]|[^\[\]]*)\]\s*,?\s*)+\](?(open)(?!))");

            try
            {
                // Intentar parsear directamente el string completo
                var jsonFormateado = JsonConvert.DeserializeObject<object>(obj);

                matrixInt = new MatrixInt(jsonFormateado);

                int sumaMatrix = matrixInt.compute();

                Console.WriteLine($"La suma de los elementos de la matriz es: " + sumaMatrix );

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al parsear la matriz completa.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
