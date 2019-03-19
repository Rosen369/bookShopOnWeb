using BookShop.Application.Abstraction;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Infrastructure
{
    internal class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILog _logger;

        public LoggerAdapter()
        {
            _logger = LogManager.GetLogger(Initializer.LogRepoName, typeof(T));
        }

        public void Debug(object message)
        {
            _logger.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            _logger.Debug(message, exception);
        }

        public void DebugFormat(string format, object arg0)
        {
            _logger.DebugFormat(format, arg0);
        }

        public void DebugFormat(string format, params object[] args)
        {
            _logger.DebugFormat(format, args);
        }

        public void Error(object message)
        {
            _logger.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            _logger.Error(message, exception);
        }

        public void ErrorFormat(string format, object arg0)
        {
            _logger.ErrorFormat(format, arg0);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            _logger.ErrorFormat(format, args);
        }

        public void ErrorFormat(string format, Exception exception, object arg0)
        {
            _logger.ErrorFormat(format, exception, arg0);
        }

        public void ErrorFormat(string format, Exception exception, params object[] args)
        {
            _logger.ErrorFormat(format, exception, args);
        }

        public void Fatal(object message)
        {
            _logger.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            _logger.Fatal(message, exception);
        }

        public void FatalFormat(string format, object arg0)
        {
            _logger.FatalFormat(format, arg0);
        }

        public void FatalFormat(string format, params object[] args)
        {
            _logger.FatalFormat(format, args);
        }

        public void FatalFormat(string format, Exception exception, object arg0)
        {
            _logger.FatalFormat(format, exception, arg0);
        }

        public void FatalFormat(string format, Exception exception, params object[] args)
        {
            _logger.FatalFormat(format, exception, args);
        }

        public void Info(object message)
        {
            _logger.Info(message);
        }

        public void Info(object message, Exception exception)
        {
            _logger.Info(message, exception);
        }

        public void InfoFormat(string format, object arg0)
        {
            _logger.InfoFormat(format, arg0);
        }

        public void InfoFormat(string format, params object[] args)
        {
            _logger.InfoFormat(format, args);
        }

        public void Warn(object message)
        {
            _logger.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            _logger.Warn(message, exception);
        }

        public void WarnFormat(string format, object arg0)
        {
            _logger.WarnFormat(format, arg0);
        }

        public void WarnFormat(string format, params object[] args)
        {
            _logger.WarnFormat(format, args);
        }

        public void WarnFormat(string format, Exception exception, object arg0)
        {
            _logger.WarnFormat(format, exception, arg0);
        }

        public void WarnFormat(string format, Exception exception, params object[] args)
        {
            _logger.WarnFormat(format, exception, args);
        }
    }
}
