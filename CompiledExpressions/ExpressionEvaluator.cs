namespace CompiledExpressions
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    #endregion

    /// <summary>
    ///     Expression evaluator helper.
    /// </summary>
    public class ExpressionEvaluator
    {
        #region Fields

        /// <summary>
        ///     The expression composer.
        /// </summary>
        private IComposeExpression expressionComposer;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionEvaluator" /> class.
        /// </summary>
        public ExpressionEvaluator()
        {
            this.expressionComposer = new ComposeExpression();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The compute expression.
        /// </summary>
        /// <param name="expressionName">
        ///     The expression name.
        /// </param>
        /// <param name="version">
        ///     The version.
        /// </param>
        /// <param name="parameters">
        ///     The parameters.
        /// </param>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public dynamic ComputeExpression(
            string expressionName,
            string version,
            List<KeyValuePair<string, dynamic>> parameters)
        {
            var expression =
                this.expressionComposer.GetComposedExpression(expressionName, version) as
                    Expression<Func<List<KeyValuePair<string, dynamic>>, dynamic>>;
            if (expression != null)
            {
                var computedExpression = expression.Compile();
                return computedExpression(parameters);
            }

            return null;
        }

        #endregion
    }
}