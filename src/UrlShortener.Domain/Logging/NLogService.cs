using NLog;
using System;

namespace UrlShortener.Domain.Logging
{
    public class NLogService : ILogService
    {

        private readonly string _defaultListenerName = "default";

        public NLogService()
        {
        }

        public void Debug(string message, params string[] listeners)
        {
            foreach (string listener in listeners)
            {
                try
                {
                    LogManager.GetLogger(listener).Debug(message);
                }
                catch { }
            }
        }

        public void Info(string message, params string[] listeners)
        {
            foreach (string listener in listeners)
            {
                try
                {
                    LogManager.GetLogger(listener).Info(message);
                }
                catch { }
            }
        }

        public void Warn(string message, params string[] listeners)
        {
            foreach (string listener in listeners)
            {
                try
                {
                    LogManager.GetLogger(listener).Warn(message);
                }
                catch { }
            }
        }

        public void Error(string message, params string[] listeners)
        {
            foreach (string listener in listeners)
            {
                try
                {
                    LogManager.GetLogger(listener).Error(message);
                }
                catch { }
            }
        }

        public void Fatal(string message, params string[] listeners)
        {
            foreach (string listener in listeners)
            {
                try
                {
                    LogManager.GetLogger(listener).Fatal(message);
                }
                catch { }
            }
        }

        public void Debug(string message, Exception ex, params string[] listeners)
        {
            foreach (string listener in listeners)
            {
                try
                {
                    LogManager.GetLogger(listener).Debug(ex, message);
                }
                catch { }
            }
        }

        public void Info(string message, Exception ex, params string[] listeners)
        {
            foreach (string listener in listeners)
            {
                try
                {
                    LogManager.GetLogger(listener).Info(ex, message);
                }
                catch { }
            }
        }

        public void Warn(string message, Exception ex, params string[] listeners)
        {
            foreach (string listener in listeners)
            {
                try
                {
                    LogManager.GetLogger(listener).Warn(ex, message);
                }
                catch { }
            }
        }

        public void Error(string message, Exception ex, params string[] listeners)
        {
            foreach (string listener in listeners)
            {
                try
                {
                    LogManager.GetLogger(listener).Error(ex, message);
                }
                catch { }
            }
        }

        public void Fatal(string message, Exception ex, params string[] listeners)
        {
            foreach (string listener in listeners)
            {
                try
                {
                    LogManager.GetLogger(listener).Fatal(ex, message);
                }
                catch { }
            }
        }

        public void Debug(string message)
        {
            try
            {
                Debug(message, _defaultListenerName);
            }
            catch { }
        }

        public void Info(string message)
        {
            try
            {
                Info(message, _defaultListenerName);
            }
            catch { }
        }

        public void Warn(string message)
        {
            try
            {
                Warn(message, _defaultListenerName);
            }
            catch { }
        }

        public void Error(string message)
        {
            try
            {
                Error(message, _defaultListenerName);
            }
            catch { }
        }

        public void Fatal(string message)
        {
            try
            {
                Fatal(message, _defaultListenerName);
            }
            catch { }
        }

        public void Debug(string message, Exception ex)
        {
            try
            {
                Debug(message, ex, _defaultListenerName);
            }
            catch { }
        }

        public void Info(string message, Exception ex)
        {
            try
            {
                Info(message, ex, _defaultListenerName);
            }
            catch { }
        }

        public void Warn(string message, Exception ex)
        {
            try
            {
                Warn(message, ex, _defaultListenerName);
            }
            catch { }
        }

        public void Error(string message, Exception ex)
        {
            try
            {
                Error(message, ex, _defaultListenerName);
            }
            catch { }
        }

        public void Fatal(string message, Exception ex)
        {
            try
            {
                Fatal(message, ex, _defaultListenerName);
            }
            catch { }
        }

    }
}