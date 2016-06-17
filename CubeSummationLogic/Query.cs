using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSummationLogic
{
    class Query : Constraints, IQuery
    {
        int x1 { get; set; }
        int x2 { get; set; }
        int y1 { get; set; }
        int y2 { get; set; }
        int z1 { get; set; }
        int z2 { get; set; }
        int dimension { get; set; }

        public string executeQuery(int[][][] matrix)
        {
            string resp = "";
            if (checkConstraintsAndInitializeIfTrue())
            {
                int sum = 0;
                for (int i = x1 - 1; i < x2; i++)
                    for (int j = y1 - 1; j < y2; j++)
                        for (int k = z1 - 1; k < z2; k++)
                            sum += matrix[i][j][k];
                resp = sum.ToString();
            }
            else
                resp = violatedConstraintMessage;
            return resp;

        }

        public Query(string query, int dimension)
        {
            string[] querysplitted = query.Split(' ');
            x1 = Convert.ToInt32(querysplitted[1]);
            y1 = Convert.ToInt32(querysplitted[2]);
            z1 = Convert.ToInt32(querysplitted[3]);
            x2 = Convert.ToInt32(querysplitted[4]);
            y2 = Convert.ToInt32(querysplitted[5]);
            z2 = Convert.ToInt32(querysplitted[6]);
            this.dimension = dimension;
        }

        protected override bool checkConstraintsAndInitializeIfTrue()
        {
            return checkInterval(x1,x2, 'x') && checkInterval(y1, y2, 'y') && checkInterval(z1, z2, 'z');
        }

        private bool checkInterval(int first, int last, char coordinate)
        {
            bool resp = 1 <= first && first <= last && last <= dimension;
            if (!resp)
            {
                string message = "La posición inicial de comparación en la coordenada " + coordinate + " es mayor a la final. La posición inicial del primer cubo es (1,1,1)";
                violatedConstraintMessage += "- " + (String.IsNullOrEmpty(violatedConstraintMessage) ? message + System.Environment.NewLine : message + System.Environment.NewLine);
            }
            return resp;
        }
    }
}
