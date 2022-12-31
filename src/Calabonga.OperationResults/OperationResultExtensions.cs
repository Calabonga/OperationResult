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
        public static IHaveDataObject? AddInfo(this OperationResult? source, string message)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            source.Metadata = new Metadata(source, message);
            return source.Metadata;
        }

        /// <summary>
        /// Create or Replace special type of metadata
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        public static IHaveDataObject? AddSuccess(this OperationResult? source, string message)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            source.Metadata = new Metadata(source, message, MetadataType.Success);
            return source.Metadata;
        }

        /// <summary>
        /// Create or Replace special type of metadata
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        public static IHaveDataObject? AddWarning(this OperationResult? source, string message)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            source.Metadata = new Metadata(source, message, MetadataType.Warning);
            return source.Metadata;
        }

        /// <summary>
        /// Create or Replace special type of metadata
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        public static IHaveDataObject? AddError(this OperationResult? source, string message)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            source.Metadata = new Metadata(source, message, MetadataType.Error);
            return source.Metadata;
        }

        /// <summary>
        /// Create or Replace special type of metadata
        /// </summary>
        /// <param name="source"></param>
        /// <param name="exception"></param>
        public static IHaveDataObject? AddError(this OperationResult? source, Exception? exception)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (exception != null)
            {
                source.Exception = exception;
            }

            source.Metadata = new Metadata(source, exception?.Message ?? "Something went wrong", MetadataType.Error);
            return source.Metadata;
        }

        /// <summary>
        /// Create or Replace special type of metadata
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static IHaveDataObject? AddError(this OperationResult? source, string message, Exception exception)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

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
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            var sb = new StringBuilder();
            if (source.Metadata != null)
            {
                sb.AppendLine($"{source.Metadata.Message}");
            }
            return sb.ToString();

        }
    }
}