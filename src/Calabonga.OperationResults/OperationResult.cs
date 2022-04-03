using System;

namespace Calabonga.OperationResults
{
    /// <summary>
    /// Any action result
    /// </summary>
    [Serializable]
    public abstract class OperationResult
    {
        /// <summary>
        /// Operation result metadata
        /// </summary>
        public Metadata? Metadata { get; set; }

        /// <summary>
        /// Exception that occurred during execution
        /// </summary>
        public Exception? Exception { get; set; }

        /// <summary>
        /// Returns as factory method OperationResult with result and 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="result"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static OperationResult<TResult> CreateResult<TResult>(TResult result, Exception? exception = null)
        {
            var operation = new OperationResult<TResult>
            {
                Result = result,
                Exception = exception
            };
            return operation;
        }

        /// <summary>
        /// Returns as factory method OperationResult
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static OperationResult<TResult> CreateResult<TResult>()
        {
            return CreateResult(default(TResult)!);
        }
    }

    /// <summary>
    /// Generic operation result for any requests for Web API service and some MVC actions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class OperationResult<T> : OperationResult
    {
        /// <summary>
        /// Result for server operation
        /// </summary>
        public T? Result { get; set; }

        /// <summary>
        /// Returns True when Exception == null and Result != null when Metadata property == null.
        /// Otherwise, when Metadata != null then validation works as 
        /// Exception equals NULL and Result not equals NULL and Metadata type not equals MetadataError and MetadataWarning.
        /// </summary>
        public bool Ok
        {
            get
            {
                if (Metadata == null)
                {
                    return Exception == null && Result != null;
                }
                return Exception == null
                       && Result != null
                       && Metadata?.Type != MetadataType.Error;
            }
        }
    }
}