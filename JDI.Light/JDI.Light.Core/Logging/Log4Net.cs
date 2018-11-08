﻿using System;
using System.Reflection;
using log4net;
using log4net.Core;

namespace JDI.Core.Logging
{
    public class Log4Net : ILogger
    {
        private ILog _log;
        private readonly object _locker = new object();
        public ILog Log
        {
            get
            {
                if (_log != null)
                    return _log;

                lock (_locker)
                {
                    if (_log == null)
                        _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                }
                return _log;
            }
        }

        public void Exception(Exception ex)
        {
            Log.Error(ex.Message, ex);
        }

        public void Trace(string message)
        {
            Log.Logger.Log(MethodBase.GetCurrentMethod().DeclaringType, Level.Trace, message, null);
        }

        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Info(string message)
        {
            Log.Info(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Step(string message)
        {
            throw new NotImplementedException();
        }

        public void TestDescription(string message)
        {
            throw new NotImplementedException();
        }

        public void TestSuit(string message)
        {
            throw new NotImplementedException();
        }
    }
}
