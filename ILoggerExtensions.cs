using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace Utils.DotNetCore.ILogger.Extensions
{
    public static class ILoggerExtensions
    {
        /// <summary>
        /// Log message with class, method names and line number
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="memberName"></param>
        /// <param name="sourceFilePath"></param>
        /// <param name="sourceLineNumber"></param>
        public static void LogWithContext(this Microsoft.Extensions.Logging.ILogger logger, LogLevel logLevel, string? message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            var className = Path.GetFileNameWithoutExtension(sourceFilePath);
            logger.Log(logLevel, "{Message} (at {ClassName}.{MethodName}, line {LineNumber})", message, className, memberName, sourceLineNumber);
        }

        /// <summary>
        /// Log message about exception with class, method names and line number
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        /// <param name="memberName"></param>
        /// <param name="sourceFilePath"></param>
        /// <param name="sourceLineNumber"></param>
        public static void LogExceptionWithContext(this Microsoft.Extensions.Logging.ILogger logger, string? message, Exception? ex = null, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            var className = Path.GetFileNameWithoutExtension(sourceFilePath);
            logger.Log(LogLevel.Error, ex, "{Message} (at {ClassName}.{MethodName}, line {LineNumber})", message, className, memberName, sourceLineNumber);
        }
    }
}