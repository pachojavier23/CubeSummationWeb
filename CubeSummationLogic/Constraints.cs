using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSummationLogic
{
    public abstract class Constraints
    {
        /// <summary>
        /// Cantidad máxima de test cases permitidas
        /// </summary>
        protected const int T = 50;

        /// <summary>
        /// Tamaño máximo del cubo
        /// </summary>
        protected const int N = 100;

        /// <summary>
        /// Cantidad máxima de queries permitidos
        /// </summary>
        protected const int M = 1000;

        /// <summary>
        /// Mínimo valor de una coordenada
        /// </summary>
        protected const int W_MIN = -1000000000;

        /// <summary>
        /// Máximo valor de una coordenada
        /// </summary>
        protected const int W_MAX = 1000000000;

        /// <summary>
        /// Corresponde al mensaje cuando no se cumple una restricción del algoritmo
        /// </summary>
        public string violatedConstraintMessage;

        protected const string QUERY_REGEX = @"^QUERY\s[0-9]*\s[0-9]*\s[0-9]*\s[0-9]*\s[0-9]*\s[0-9]*$";

        protected const string T_REGEX = @"^[0-9]*$";

        protected const string TC_REGEX = @"^[0-9]*\s[0-9]*$";

        protected const string UPDATE_REGEX = @"^UPDATE\s[0-9]*\s[0-9]*\s[0-9]*\s[0-9]*$";

        /// <summary>4
        /// Chequea las restricciones que tiene el algoritmo
        /// </summary>
        /// <returns>true, si se cumplen las restricciones del algoritmo</returns>
        protected abstract Boolean checkConstraintsAndInitializeIfTrue();


    }
}
