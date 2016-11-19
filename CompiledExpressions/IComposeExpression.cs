namespace CompiledExpressions
{
    #region

    using System.Linq.Expressions;

    #endregion

    /// <summary>
    ///     The ComposeExpression interface.
    /// </summary>
    public interface IComposeExpression
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The get composed expression.
        /// </summary>
        /// <param name="expressionIdentifier">
        ///     The expression identifier.
        /// </param>
        /// <param name="version">
        ///     The version.
        /// </param>
        /// <returns>
        ///     The <see cref="Expression" />.
        /// </returns>
        Expression GetComposedExpression(string expressionIdentifier, string version);

        #endregion
    }
}