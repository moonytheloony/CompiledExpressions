namespace CompiledExpressions
{
    /// <summary>
    ///     The ICompose expression metadata.
    /// </summary>
    public interface IExpressionContainerMetadata
    {
        #region Public Properties

        /// <summary>
        ///     Gets the expression CSV.
        /// </summary>
        string ExpressionCsv { get; }

        /// <summary>
        ///     Gets the version.
        /// </summary>
        string Version { get; }

        #endregion
    }
}