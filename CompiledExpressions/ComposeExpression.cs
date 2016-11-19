namespace CompiledExpressions
{
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    #endregion

    /// <summary>
    ///     The compose expression.
    /// </summary>
    public class ComposeExpression : IComposeExpression
    {
        #region Fields

        /// <summary>
        ///     The expression store.
        /// </summary>
        [ImportMany]
        private IEnumerable<Lazy<IExpressionContainer, IExpressionContainerMetadata>> expressionStore = null;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ComposeExpression" /> class.
        /// </summary>
        public ComposeExpression()
        {
            var catalog = new AggregateCatalog(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        #endregion

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
        public Expression GetComposedExpression(string expressionIdentifier, string version)
        {
            var comparer = new CaseInvariantComparer();
            var composedExpression =
                this.expressionStore.FirstOrDefault(
                    expression =>
                        expression.Metadata.ExpressionCsv.Split(',').Contains(expressionIdentifier.Trim(), comparer)
                        && expression.Metadata.Version.Equals(version, StringComparison.OrdinalIgnoreCase));
            return composedExpression?.Value.CompiledExpression(expressionIdentifier.Trim());
        }

        #endregion
    }
}