using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSummationLogic
{
    class Update : Constraints, IQuery
    {
        private int x { get; set; }
        private int y { get; set; }
        private int z { get; set; }
        private int w { get; set; }
        private int dimension { get; set; }

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
            

        protected override bool checkConstraintsAndInitializeIfTrue()
        {
            return checkInterval(x, 'x') && checkInterval(y, 'y') && checkInterval(z,'z') && checkMinAndMaxValueofMatrixValue();
        }

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
