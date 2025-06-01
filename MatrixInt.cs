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

            dimension();
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


        public bool straight()
        {
            return false;
        }

        public int compute()
        {
            return 0;
        }

        #endregion
    }



}
