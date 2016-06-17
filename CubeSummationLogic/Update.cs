using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSummationLogic
{
    class Update : Constraints, IQuery
    {
        /// <summary>
        /// Valor en x
        /// </summary>
        private int x { get; set; }
        /// <summary>
        /// Valor en y
        /// </summary>
        private int y { get; set; }
        /// <summary>
        /// Valor en z
        /// </summary>
        private int z { get; set; }
        /// <summary>
        /// Valor a actualizar en la matriz para la posición x, y, z
        /// </summary>
        private int w { get; set; }
        /// <summary>
        /// Tamaño de la matriz
        /// </summary>
        private int dimension { get; set; }


        /// <summary>
        /// Método que ejecuta el query tipo update
        /// </summary>
        public string executeQuery(int[][][] matrix)
        {
            string resp = "";
            if (checkConstraintsAndInitializeIfTrue())
            {
                matrix[x-1][y-1][z-1] = w;
            }
            else
                resp = violatedConstraintMessage;
            return resp;
        }

        public Update(string query, int dimension)
        {
            string[] querySplitted = query.Split(' ');
            x = Convert.ToInt32(querySplitted[1]);
            y = Convert.ToInt32(querySplitted[2]);
            z = Convert.ToInt32(querySplitted[3]);
            w = Convert.ToInt32(querySplitted[4]);
            this.dimension = dimension;

        }


        /// <summary>
        /// Chequea las restricciones a la instrucción tipo query. X, Y y Z al tamaño de la dimensión. W debe estár entre -1000000000 y 1000000000
        /// </summary>
        protected override bool checkConstraintsAndInitializeIfTrue()
        {
            return checkInterval(x, 'x') && checkInterval(y, 'y') && checkInterval(z,'z') && checkMinAndMaxValueofMatrixValue();
        }
        /// <summary>
        /// W debe estár entre -1000000000 y 1000000000
        /// </summary>
        /// <returns></returns>
        private bool checkMinAndMaxValueofMatrixValue()
        {
            bool resp = Constraints.W_MIN <= w && w <= Constraints.W_MAX;
            if (!resp)
            {
                string message = "El valor del valor a actualizar debe encontrarse entre " + Constraints.W_MIN + "y " + Constraints.W_MAX;
                violatedConstraintMessage += "- " + (String.IsNullOrEmpty(violatedConstraintMessage) ? message + System.Environment.NewLine : message + System.Environment.NewLine);
            }
            return resp;
        }

        /// <summary>
        /// X, Y y Z al tamaño de la dimensión.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        private bool checkInterval(int first, char coordinate)
        {
            bool resp = 1 <= first && first <= dimension;
            if (!resp)
            {
                string message = "La posición inicial de comparación en la coordenada " + coordinate + " es mayor a la final. La posición inicial del primer cubo es (1,1,1)";
                violatedConstraintMessage += "- " + (String.IsNullOrEmpty(violatedConstraintMessage) ? message + System.Environment.NewLine : message + System.Environment.NewLine);
            }
            return resp;
        }
    }
}
