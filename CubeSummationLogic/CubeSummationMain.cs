using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CubeSummationLogic
{
    public class CubeSummationMain : Constraints
    {
        private List<TestCase> testCases;
        private int testSize { get; set; }
        private string program { get; set; }
        private const string CHAR_ITERATOR = "|";
        private string[] mainProgram;

        public CubeSummationMain(string program)
        {
            this.program = program.Replace(System.Environment.NewLine, CHAR_ITERATOR);
            this.mainProgram = this.program.Split(Convert.ToChar(CHAR_ITERATOR));
            violatedConstraintMessage = "";
            testCases = new List<TestCase>();
        }

        protected override bool checkConstraintsAndInitializeIfTrue()
        {
            return (firstLineConstraint() && programLengthConstraint() && TestCasesNumberConstraint());
        }

        private bool firstLineConstraint()
        {
            bool resp = Regex.Match(mainProgram[0],Constraints.T_REGEX).Success;
            if (!resp)
            {
                string message = "La primera línea debe ser numérica";
                violatedConstraintMessage += "- " + (String.IsNullOrEmpty(violatedConstraintMessage) ? message + System.Environment.NewLine : message + System.Environment.NewLine);
            }
            else
                testSize = Convert.ToInt32(mainProgram[0]);
            return resp;
        }

        private bool programLengthConstraint()
        {
            bool resp = mainProgram.Length >= 3;
            if (!resp)
            {
                string message = "El programa debe contener al menos 3 líneas";
                violatedConstraintMessage += "- " + (String.IsNullOrEmpty(violatedConstraintMessage) ? message + System.Environment.NewLine : message + System.Environment.NewLine);
            }
            return resp;
        }

        private bool TestCasesNumberConstraint()
        {
            bool resp = (testSize >= 1 && testSize <= Constraints.T);
            if (!resp)
            {
                string message = "La cantidad de test cases a ejecutar debe ser mayor a 0 y menor a " + Constraints.T.ToString();
                violatedConstraintMessage += "- " + (String.IsNullOrEmpty(violatedConstraintMessage) ? message + System.Environment.NewLine : message + System.Environment.NewLine);
            }
            return resp;
        }

        public string ExecuteCubeSummation()
        {
            string result = "";
            if (!checkConstraintsAndInitializeIfTrue())
                result = violatedConstraintMessage;
            else
            {
                int line = 1, i = 1;
                bool keepExecuting = true;
                while (keepExecuting && i <= testSize)
                {
                    TestCase tc = new TestCase(mainProgram[line]);
                    bool tcError = !String.IsNullOrEmpty(tc.violatedConstraintMessage);
                    bool outOfLines = mainProgram.Length < line + tc.querySize + 1;

                    if (tcError || outOfLines)
                    { 
                        throwErrorNotEnoughQueries();
                        result = tcError ? tc.violatedConstraintMessage:violatedConstraintMessage;
                        keepExecuting = false;
                    }
                    int j = 1;
                    while(keepExecuting && j <= tc.querySize)
                    {
                        if(!tc.addQueryToTestCase(mainProgram[line + j]))
                        {
                            result = tc.violatedConstraintMessage;
                            keepExecuting = false;
                        }
                        j++;
                    }
                    testCases.Add(tc);
                    line += tc.querySize + 1;
                    i++;
                }
                if (keepExecuting)
                    foreach (TestCase tc in testCases)
                        result += tc.execTest();
            }
            return result;
        }

        private void throwErrorNotEnoughQueries()
        {
            string message = "La cantidad de queries a ejecutar es mayor a los queries restantes en el programa";
            violatedConstraintMessage += "- " + (String.IsNullOrEmpty(violatedConstraintMessage) ? message + System.Environment.NewLine : message + System.Environment.NewLine);
        }
    }
}
