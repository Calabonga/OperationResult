namespace Calabonga.OperationResults.Tests
{
    /// <summary>
    /// Fixture for unit-testing OperationResultCore
    /// </summary>
    public class OperationResultCoreFixture
    {

        /// <summary>
        /// Factory method
        /// </summary>
        public OperationResult<T> Create<T>()
        {
            return new();
        }
    }
}