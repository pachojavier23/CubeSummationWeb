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
        /// Chequea las restricciones que tiene el algoritmo
        /// </summary>
        /// <returns>true, si se cumplen las restricciones del algoritmo</returns>
        protected abstract Boolean checkConstraints();
    }
}
