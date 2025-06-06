using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace EjerciciosLogica
{
    internal class Program
    {
        public MatrixInt matrixInt;
        public MatrixString matrixString;
        //public string obj = "[[[1, 2,3]], [[5, 6, 7],[5, 4, 3]], [[3, 5, 6], [4, 8, 3], [2, 3]]]";
        //public string obj = " [[[1, 2, 3], [2, 3, 4]], [[5, 6, 7], [5, 4, 3]], [[3,5, 6], [4, 8, 3]]]";
        //public string obj = "  [1,2]";


        public string obj = "[1, 2]";
        //public string obj = "[[1, 2], [2, 4]]";
        //public string obj = "[[1, 2],[2, 4],[2, 4]]";
        //public string obj ="[[[3, 4],[6, 5]]]" ;
        //public string obj ="[[[1, 2, 3]], [[5, 6, 7], [5, 4, 3]], [[3, 5, 6], [4, 8, 3], [2, 3]]] ";
        // public string obj = "[[[1, 2, 3], [2, 3, 4]], [[5, 6, 7], [5, 4, 3]], [[3, 5, 6], [4, 8, 3]]]";


        //public string obj = "Hello world";
        //public string obj = "2 + 10 / 2 - 20";
        //public string obj = "(2 + 10) / 2 - 20";
        //public string obj = "(2 + 10 / 2 - 20"; 


        // Lista para almacenar matrices procesadas
        private List<MatrixInt> matrices = new List<MatrixInt>();

        // Lista de objetos en formato string
        private List<string> objetos = new List<string>
    {
        "[1, 2]",
        "[[1, 2], [2, 4]]",
        "[[1, 2],[2, 4],[2, 4]]",
        "[[[3, 4],[6, 5]]]",
        "[[[1, 2, 3]], [[5, 6, 7], [5, 4, 3]], [[3, 5, 6], [4, 8, 3], [2, 3]]]",
        "[[[1, 2, 3], [2, 3, 4]], [[5, 6, 7], [5, 4, 3]], [[3, 5, 6], [4, 8, 3]]]"
    };



        static void Main(string[] args)
        {
            Program p = new Program();

            //p.ObtenerDimension();


            //p.ValidarCantidadMatrix();

            //p.SumaMatrix();
            

            p.ObtenerDimenciones();
            p.ValidarMatrices();
            p.SumaMatrix();
            p.RetornarString();

        }


        public void ObtenerDimenciones()
        {

            foreach (var obj in objetos)
            {
                ObtenerDimension(obj);
                Thread.Sleep(1500);
            }
        }

        public void ValidarMatrices()
        {
            foreach (var matrixInt in matrices)
            {
                ValidarCantidadMatrix();  
                Thread.Sleep(1500);
            }
        }

        public void SumaMatrices()
        {
            foreach (var matrix in matrices)
            {
                SumaMatrix();
                Thread.Sleep(1500);
            }
        }


        public void ObtenerDimension(string obj)
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

                //Console.ReadKey();
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


        public void RetornarString()
        {
            matrixString = new MatrixString(obj);

            bool stringReturn = matrixString.retrurnString(obj);

            Console.WriteLine(stringReturn);

        }


    }
}
