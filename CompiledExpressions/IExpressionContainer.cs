using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiledExpressions
{
    #region

    using System.Collections.Generic;
    using System.Linq.Expressions;

    #endregion

    /// <summary>
    ///     The ExpressionContainer interface.
    /// </summary>
    public interface IExpressionContainer
    {
        #region Public Properties

        /// <summary>
        ///     Gets the expression list.
        /// </summary>
        IList<KeyValuePair<string, Expression>> ExpressionList { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The compiled expression.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        Expression CompiledExpression(string id);

        #endregion
    }
}
