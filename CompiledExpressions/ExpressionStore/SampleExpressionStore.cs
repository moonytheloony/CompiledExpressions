namespace CompiledExpressions.ExpressionStore
{
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Linq.Expressions;

    #endregion

    /// <summary>
    ///     The sample expression store.
    /// </summary>
    [Export(typeof(IExpressionContainer))]
    [ExportMetadata("ExpressionCsv", "TestExpression1,TestExpression2")]
    [ExportMetadata("Version", "1.0.0.0")]
    internal class SampleExpressionStore : IExpressionContainer
    {
        #region Fields

        /// <summary>
        ///     The expression list.
        /// </summary>
        private readonly List<KeyValuePair<string, Expression>> expressionList;

        /// <summary>
        ///     The test expression 1.
        /// </summary>
        private readonly Expression<Func<List<KeyValuePair<string, dynamic>>, dynamic>> testExpression1 =
            paramList => SampleFunction1(paramList);

        /// <summary>
        ///     The test expression 2.
        /// </summary>
        private readonly Expression<Func<List<KeyValuePair<string, dynamic>>, dynamic>> testExpression2 =
            paramList => SampleFunction2(paramList);

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SampleExpressionStore" /> class.
        /// </summary>
        public SampleExpressionStore()
        {
            this.expressionList = new List<KeyValuePair<string, Expression>>
                {
                    new KeyValuePair<string, Expression>("TestExpression1", this.testExpression1),
                    new KeyValuePair<string, Expression>("TestExpression2", this.testExpression2)
                };
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the expression list.
        /// </summary>
        public IList<KeyValuePair<string, Expression>> ExpressionList
        {
            get
            {
                return this.expressionList;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The compiled expression.
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <returns>
        ///     The <see cref="Expression" />.
        /// </returns>
        public Expression CompiledExpression(string id)
        {
            var compiledExpression =
                this.expressionList.FirstOrDefault(
                    expression => expression.Key.Equals(id, StringComparison.OrdinalIgnoreCase));
            return compiledExpression.Equals(default(KeyValuePair<string, Expression>))
                ? null
                : compiledExpression.Value;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     The sample function 1.
        /// </summary>
        /// <param name="paramList">
        ///     The parameter list.
        /// </param>
        /// <returns>
        ///     The <see cref="dynamic" />.
        /// </returns>
        private static dynamic SampleFunction1(IEnumerable<KeyValuePair<string, dynamic>> paramList)
        {
            Console.WriteLine("SampleFunction1 invoked");
            foreach (var argument in paramList)
            {
                Console.WriteLine("Received Argument: Key= " + argument.Key + " Value= " + argument.Value.ToString());
            }

            return "SomeValue From SampleFunction1";
        }

        /// <summary>
        ///     The sample function 2.
        /// </summary>
        /// <param name="paramList">
        ///     The parameter list.
        /// </param>
        /// <returns>
        ///     The <see cref="dynamic" />.
        /// </returns>
        private static dynamic SampleFunction2(IEnumerable<KeyValuePair<string, dynamic>> paramList)
        {
            Console.WriteLine("SampleFunction2 invoked");
            foreach (var argument in paramList)
            {
                Console.WriteLine("Received Argument: Key= " + argument.Key + " Value= " + argument.Value.ToString());
            }

            return "SomeValue From SampleFunction2";
        }

        #endregion
    }
}