namespace CompiledExpressions
{
    #region

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    ///     The case invariant comparer.
    /// </summary>
    public class CaseInvariantComparer : IEqualityComparer<string>
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The equals.
        /// </summary>
        /// <param name="x">
        ///     The first string.
        /// </param>
        /// <param name="y">
        ///     The second string.
        /// </param>
        /// <returns>
        ///     The System.Boolean.
        /// </returns>
        public bool Equals(string x, string y)
        {
            if (string.IsNullOrWhiteSpace(x) && string.IsNullOrWhiteSpace(y))
            {
                return true;
            }

            return (x != null) && x.Equals(y, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     The get hash code.
        /// </summary>
        /// <param name="obj">
        ///     The object.
        /// </param>
        /// <returns>
        ///     The hash code.
        /// </returns>
        public int GetHashCode(string obj)
        {
            if (obj == null)
            {
                return 0;
            }

            return obj.GetHashCode();
        }

        #endregion
    }
}