using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiledExpressions
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running Test For: Compiled Expression");
            TestCompiledExpressionFunction();
            Console.ReadKey();
        }

        private static void TestCompiledExpressionFunction()
        {
            var expressionEvaluator = new ExpressionEvaluator();
            var testExpression1ReturnValue = expressionEvaluator.ComputeExpression(
                "TestExpression1",
                "1.0.0.0",
                new List<KeyValuePair<string, dynamic>>
                    {
                        new KeyValuePair<string, dynamic>("PARAM1", "PARAM1Value"),
                        new KeyValuePair<string, dynamic>("PARAM2", "PARAM2Value")
                    });
            Console.WriteLine("TestExpression1 returned: " + testExpression1ReturnValue);
            var testExpression2ReturnValue = expressionEvaluator.ComputeExpression(
                "TestExpression2",
                "1.0.0.0",
                new List<KeyValuePair<string, dynamic>>
                    {
                        new KeyValuePair<string, dynamic>("PARAM1", "PARAM1Value"),
                        new KeyValuePair<string, dynamic>("PARAM2", "PARAM2Value")
                    });
            Console.WriteLine("TestExpression2 returned: " + testExpression2ReturnValue);
        }
    }
}
