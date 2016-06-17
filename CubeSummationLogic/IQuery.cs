using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSummationLogic
{
    interface IQuery
    {
        string executeQuery(int[][][] matrix);
    }
}
