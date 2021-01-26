using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Calabonga.OperationResults
{
    /// <summary>
    /// Any action result
    /// </summary>
    [Serializable]
    public abstract class OperationResult
    {
        private readonly IList<string> _logs = new List<string>();

        protected OperationResult()
        {
            ActivityId = Generate(11);
        }

        public string ActivityId { get; set; }

        /// <summary>
        /// Operation result metadata
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Exception that occurred during execution
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Collection of the messages
        /// </summary>
        public IEnumerable<string> Logs => _logs;

        /// <summary>
        /// Returns as factory method OperationResult with result and 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="result"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static OperationResult<TResult> CreateResult<TResult>(TResult result, Exception error)
        {
            var operation = new OperationResult<TResult>
            {
                Result = result
            };
            return operation;
        }

        /// <summary>
        /// Returns as factory method OperationResult with result
        /// </summary>
        /// <typeparam name="TResult">Result for operation</typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public static OperationResult<TResult> CreateResult<TResult>(TResult result)
        {
            return CreateResult(result, null);
        }

        /// <summary>
        /// Returns as factory method OperationResult
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static OperationResult<TResult> CreateResult<TResult>()
        {
            return CreateResult<TResult>(default(TResult), null);
        }

        /// <summary>
        /// Appends message to logger list
        /// </summary>
        /// <param name="messageLog"></param>
        public void AppendLog(string messageLog)
        {
            if (string.IsNullOrEmpty(messageLog))
            {
                return;
            }

            if (messageLog.Length > 500)
            {
                _logs.Add($"{messageLog.Substring(0, 500)}");
            }
            _logs.Add(messageLog);
        }

        /// <summary>
        /// Appends messages to logger list
        /// </summary>
        public void AppendLog(IEnumerable<string> messageLogs)
        {
            if (messageLogs == null) return;

            foreach (var messageLog in messageLogs)
            {
                AppendLog(messageLog);
            }
        }

        /// <summary>
        /// Returns string token
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private static string Generate(int size)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            var data = new byte[1];
            using (var crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[size];
                crypto.GetNonZeroBytes(data);
            }
            var result = new StringBuilder(size);
            foreach (var b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
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
        public T Result { get; set; }

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