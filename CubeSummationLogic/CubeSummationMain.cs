using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSummationLogic
{
    public class CubeSummationMain : Constraints
    {
        private List<TestCase> testCases;
        private int testSize { get; set; }
        private string program { get; set; }

        public CubeSummationMain(string program)
        {
            this.program = program;
        }

        protected override bool checkConstraints()
        {
            return (TestCasesNumberConstraint());
        }

        private bool TestCasesNumberConstraint()
        {
            return (testSize >= 1 && testSize <= Constraints.T);
        }

        public string ExecuteCubeSummation()
        {
            string result = "result";

            return result;
        }
    }
}
