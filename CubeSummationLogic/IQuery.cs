using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSummationLogic
{
    interface IQuery
    {
        /// <summary>
        /// Firma del método para ejecutar un query de cualquier tipo para una matriz
        /// </summary>
        string executeQuery(int[][][] matrix);
    }
}
