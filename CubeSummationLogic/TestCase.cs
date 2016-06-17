using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CubeSummationLogic
{
    class TestCase : Constraints
    {
        private List<IQuery> queries;
        public int dimension { get; set; }
        public int querySize { get; set; }
        private string dimPlusNumQuery { get; set; }
        private int[][][] matrix;

        protected override bool checkConstraintsAndInitializeIfTrue()
        {
            return (validateRegex() && dimensionConstraint() && sizeConstraint());
        }

        private bool validateRegex()
        {
            bool resp = Regex.Match(dimPlusNumQuery, Constraints.TC_REGEX).Success;
            if (!resp)
            {
                string message = "Las características de la matriz deben tener el formato N M";
                violatedConstraintMessage += "- " + (String.IsNullOrEmpty(violatedConstraintMessage) ? message + System.Environment.NewLine : message + System.Environment.NewLine);
            }
            else
            {
                string[] dimPlusNumQuerySplitted = dimPlusNumQuery.Split(' ');
                dimension = Convert.ToInt32(dimPlusNumQuerySplitted[0]);
                querySize = Convert.ToInt32(dimPlusNumQuerySplitted[1]);
            }
            return resp;
        }

        private bool dimensionConstraint()
        {
            bool resp = (dimension >= 1 && dimension <= Constraints.N);
            if (!resp)
            {
                string message = "El tamaño de la matriz 3D debe ser mayor a 1 y menor a " + Constraints.N.ToString();
                violatedConstraintMessage += "- " + (String.IsNullOrEmpty(violatedConstraintMessage) ? message + System.Environment.NewLine : message + System.Environment.NewLine);
            }
            return resp;
        }

        private bool sizeConstraint()
        {
            bool resp = (querySize >= 1 && querySize <= Constraints.M);
            if (!resp)
            {
                string message = "La cantidad de queries a ejecutar debe ser mayor a 1 y menor a " + Constraints.M.ToString();
                violatedConstraintMessage += "- " + (String.IsNullOrEmpty(violatedConstraintMessage) ? message + System.Environment.NewLine : message + System.Environment.NewLine);
            }
            return resp;
        }

        public TestCase(string dimPlusNumQuery)
        {
            this.dimPlusNumQuery = dimPlusNumQuery;
            checkConstraintsAndInitializeIfTrue();
            queries = new List<IQuery>();
            matrix = new int[dimension][][];
            for (int i = 0; i < dimension; i++)
            {
                matrix[i] = new int[dimension][];
                for (int j = 0; j < dimension; j++)
                {
                    matrix[i][j] = new int[dimension];
                }
            }
        }

        public string execTest()
        {
            string resp = "";
            foreach (IQuery query in queries)
                resp += query.executeQuery(ref matrix) + System.Environment.NewLine;
            return resp;
        }

        public bool addQueryToTestCase(string query)
        {
            bool isUpdate = Regex.Match(query, Constraints.UPDATE_REGEX).Success;
            bool isQuery = Regex.Match(query, Constraints.QUERY_REGEX).Success;
            bool resp = isUpdate || isQuery;
            if (!resp)
            {
                string message = "El query a ejecutar no corresponde con el formato establecido: UPDATE x y z W, QUERY x1 y1 z1 x2 y2 z2";
                violatedConstraintMessage += "- " + (String.IsNullOrEmpty(violatedConstraintMessage) ? message : System.Environment.NewLine + message);
            }
            else
            {
                IQuery q = null;
                if (isQuery)
                    q = new Query(query, dimension);
                else
                    q = new Update();
                queries.Add(q);
            }
            return resp;


        }
    }
}
