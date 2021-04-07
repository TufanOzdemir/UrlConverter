using System;

namespace UrlShortener.Domain.Logging
{
    public interface ILogService
    {
        void Debug(string message, params string[] listeners);
        void Info(string message, params string[] listeners);
        void Warn(string message, params string[] listeners);
        void Error(string message, params string[] listeners);
        void Fatal(string message, params string[] listeners);

        void Debug(string message, Exception ex, params string[] listeners);
        void Info(string message, Exception ex, params string[] listeners);
        void Warn(string message, Exception ex, params string[] listeners);
        void Error(string message, Exception ex, params string[] listeners);
        void Fatal(string message, Exception ex, params string[] listeners);

        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Fatal(string message);

        void Debug(string message, Exception ex);
        void Info(string message, Exception ex);
        void Warn(string message, Exception ex);
        void Error(string message, Exception ex);
        void Fatal(string message, Exception ex);
    }
}