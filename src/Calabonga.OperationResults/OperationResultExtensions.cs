using System;
using System.Linq;
using System.Text;

namespace Calabonga.OperationResults
{
    /// <summary>
    /// OperationResult extension
    /// </summary>
    public static class OperationResultExtensions
    {
        /// <summary>
        /// Create or Replace special type of metadata
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        public static IHaveDataObject? AddInfo(this OperationResult source, string message)
        {
            source.Metadata = new Metadata(source, message);
            return source.Metadata;
        }

        /// <summary>
        /// Create or Replace special type of metadata
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        public static IHaveDataObject? AddSuccess(this OperationResult source, string message)
        {
            source.Metadata = new Metadata(source, message, MetadataType.Success);
            return source.Metadata;
        }

        /// <summary>
        /// Create or Replace special type of metadata
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        public static IHaveDataObject? AddWarning(this OperationResult source, string message)
        {
            source.Metadata = new Metadata(source, message, MetadataType.Warning);
            return source.Metadata;
        }

        /// <summary>
        /// Create or Replace special type of metadata
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        public static IHaveDataObject? AddError(this OperationResult source, string message)
        {
            source.Metadata = new Metadata(source, message, MetadataType.Error);
            return source.Metadata;
        }

        /// <summary>
        /// Create or Replace special type of metadata
        /// </summary>
        /// <param name="source"></param>
        /// <param name="exception"></param>
        public static IHaveDataObject? AddError(this OperationResult source, Exception exception)
        {
            source.Exception = exception;
            source.Metadata = new Metadata(source, exception?.Message, MetadataType.Error);
            if (exception != null)
            {
            }
            return source.Metadata;
        }

        /// <summary>
        /// Create or Replace special type of metadata
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static IHaveDataObject? AddError(this OperationResult source, string message, Exception exception)
        {
            source.Exception = exception;
            source.Metadata = new Metadata(source, message, MetadataType.Error);
            return source.Metadata;
        }

        /// <summary>
        /// Gather information from result metadata
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetMetadataMessages(this OperationResult source)
        {
            if (source == null) throw new ArgumentNullException();

            var sb = new StringBuilder();
            if (source.Metadata != null)
            {
                sb.AppendLine($"{source.Metadata.Message}");
            }
            return sb.ToString();

        }
    }
}