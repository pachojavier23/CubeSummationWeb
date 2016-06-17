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
        /// <summary>
        /// Lista de queries a ejecutar en la prueba
        /// </summary>
        private List<IQuery> queries;
        /// <summary>
        /// Tamaño de la matriz
        /// </summary>
        public int dimension { get; set; }
        /// <summary>
        /// Cantidad de queries a ejecutar
        /// </summary>
        public int querySize { get; set; }
        /// <summary>
        /// instrucción de encabezado de testcase. tiene el formato N M, donde N es la dimensión de la matriz y M la cantidad de queries a ejecutar
        /// </summary>
        private string dimPlusNumQuery { get; set; }
        /// <summary>
        /// Matriz de cubos
        /// </summary>
        private int[][][] matrix;

        /// <summary>
        /// Chequea que el formato del encabezado del testcase sea N M, que la dimensión se encuentre entre 1 y 100 y que c
        /// </summary>
        protected override bool checkConstraintsAndInitializeIfTrue()
        {
            return (validateRegex() && dimensionConstraint() && sizeConstraint());
        }
        /// <summary>
        /// el formato del encabezado del testcase sea N M
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// la dimensión se encuentre entre 1 y 100
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// la dimensión se encuentre entre 1 y 100
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Ejecuta uno a uno los queries, devolviendo la respuesta de cada uno
        /// </summary>
        /// <returns></returns>
        public string execTest()
        {
            string resp = "";
            foreach (IQuery query in queries)
                resp += query.executeQuery(matrix) + (query is Update ? "" : System.Environment.NewLine);
            return resp;
        }
        /// <summary>
        /// Agrega un query a la lista
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
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
                    q = new Update(query, dimension);
                queries.Add(q);
            }
            return resp;


        }
    }
}
