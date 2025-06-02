using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosLogica
{
    public class MatrixInt
    {
        //Se crea el objeto
        private object MyMatrix;

        //Se crea el construtor de la clase
        public  MatrixInt(object matrix)
        {
            this.MyMatrix = matrix;

           // dimension();
            straight(MyMatrix);
        }

        #region Metodos

        //Metodo que nos devuelve la dimensión
        public int dimension()
        {
           return getDimension(MyMatrix);
        }

        //En este método hayamos la dimensión de la matriz, donde nos retornará el resultado en entero.
        private int getDimension(object obj)
        {
            if (obj is IList list && list.Count > 0)
            {
                return 1 + getDimension(list[0]);
            }
            return 0;
        }


        public bool straight(object obj)
        {
            return getStraiht(MyMatrix);
        }

        public bool getStraiht(object obj)
        {
            try
            {
                //Valida que el objeto sea una lista
                if (obj is IList list)
                {
                    //Valida si el objeto está vacío, si lo está es valido y devuelve true
                    if (list.Count == 0)
                        return true;


                    //Se genera una variable local para validar que los datos son númericos, le asignamos true
                    bool valorNumerico = true;

                    //Iteramos elementos de la lista
                    foreach (var item in list)
                    {
                        //Si el item seleccionado corresponde a una lista entonces el valor numerico le asignamos false, ya que a pesar de ser una lista con valores enteros, estamos validando es dato a dato
                        if (item is IList)
                        {
                            valorNumerico = false;
                            break;
                        }
                    }

                    //Validamos que todos los elementos son numericos y devolvemos true
                    if (valorNumerico)
                        return true;

                    //Decimos que todos los elementos deben ser sublistas
                    //Definimos una variable para almacenar el tamaño esperado de las sublistas
                    int? tamanio = null;

                    //Iteramos el objeto para validar la estructura de las sublistas
                    foreach (var item in list)
                    {
                        
                        if (item is IList sublist)
                        {
                            //Si es el tamaño es nullo entonces le asignamos el valor de la sublista (primera), y si es diferente entonces retornamos false
                            if (tamanio == null)
                                tamanio = sublist.Count;
                            else if (sublist.Count != tamanio) //Si el tamaño es diferente devolvemos false
                                return false;

                            //Si el return es negativo, retornamos negativo
                            if (!getStraiht(sublist))
                                return false;
                        }
                        else
                        {
                            return false; //Si el item no corresponde a una lista, devolvemos false
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al parsear la matriz completa.");
                Console.WriteLine(ex.Message);

                return false;
            }
        }
    

        public int compute()
        {
            return 0;
        }

        #endregion
    }



}
