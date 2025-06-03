using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EjerciciosLogica
{
    public class MatrixString
    {
        private string MyArray;

        public MatrixString(string myMatrix)
        {
            this.MyArray = myMatrix;

            operation();
        }

        public bool operation() 
        {
            return retrurnString(MyArray);
        }

        public bool retrurnString(string obj)
        {
            try
            {
                //DataTable.Compute analiza el string y valida si es una exprecion algebraica, si lo es retorna true, de lo contrario
                //entra en el catch y devuelve false
                var result = new DataTable().Compute(obj, null);
                return true;
            }
            catch
            {
                //Si no es una expresión algebraica devuelve false
                return false;
            }
        }
    }
}
