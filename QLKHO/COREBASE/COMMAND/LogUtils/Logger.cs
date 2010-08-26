using System;
using log4net;
using log4net.Config;
using System.Collections;
using System.Reflection;
using System.IO;

namespace COREBASE.COMMAND.LogUtils
{
    public class Logger
    {

        private static readonly ILog _logger = LogManager.GetLogger(MethodInfo.GetCurrentMethod().DeclaringType);
        private static readonly IAppLog _AppLog = new AppLogImpl();
        //private static readonly IWSAccessLog _WSAccessLog = new WSAccessLogImpl();

        //private static readonly IWSMessageLog _WSMessageLog = new WSMessageLogImpl();
        private static void SetEnvVars(IDictionary EnvVars)
        {
            if ((EnvVars != null))
            {
                foreach (object key in EnvVars.Keys)
                {
                    Environment.SetEnvironmentVariable(key.ToString(), EnvVars[key].ToString());
                }
            }
        }

        public static void Configure()
        {
            XmlConfigurator.Configure();
        }

        public static void Configure(IDictionary EnvVars)
        {
            SetEnvVars(EnvVars);
            Configure();
        }

        public static void Configure(FileInfo ConfigFile)
        {
            XmlConfigurator.Configure(ConfigFile);
        }

        public static void Configure(FileInfo ConfigFile, IDictionary EnvVars)
        {
            SetEnvVars(EnvVars);
            Configure(ConfigFile);
        }

        public static void Configure(string ConfigPath)
        {
            Configure(new FileInfo(ConfigPath));
        }

        public static void Configure(string ConfigPath, IDictionary EnvVars)
        {
            Configure(new FileInfo(ConfigPath), EnvVars);
        }

        public static IAppLog AppLog
        {
            get { return _AppLog; }
        }

        //public static IWSAccessLog WSAccessLog
        //{
        //    get { return _WSAccessLog; }
        //}

        //public static IWSMessageLog WSMessageLog
        //{
        //    get { return _WSMessageLog; }
        //}

        public static bool IsDebugEnabled
        {
            get { return _logger.IsDebugEnabled; }
        }

        public static bool IsErrorEnabled
        {
            get { return _logger.IsErrorEnabled; }
        }

        public static bool IsFatalEnabled
        {
            get { return _logger.IsFatalEnabled; }
        }

        public static bool IsInfoEnabled
        {
            get { return _logger.IsInfoEnabled; }
        }

        public static bool IsWarnEnabled
        {
            get { return _logger.IsWarnEnabled; }
        }

        private class CVXSERPLogImpl : IVXSERPLog
        {

            public bool IsDebugEnabled
            {
                get { return Logger._logger.IsDebugEnabled; }
            }

            public bool IsErrorEnabled
            {
                get { return Logger._logger.IsErrorEnabled; }
            }

            public bool IsFatalEnabled
            {
                get { return Logger._logger.IsFatalEnabled; }
            }

            public bool IsInfoEnabled
            {
                get { return Logger._logger.IsInfoEnabled; }
            }

            public bool IsWarnEnabled
            {
                get { return Logger._logger.IsWarnEnabled; }
            }
        }

        private class AppLogImpl : CVXSERPLogImpl, IAppLog
        {

            private string Format(object screenId, object userId, object msg)
            {
                return string.Format("{0} {1} {2}", screenId, userId, msg);
            }

            public void Debug(object screenId, object userId, object msg)
            {
                Logger._logger.Debug(string.Format("SCREENID = {0}  : USERID = {1}  : MSG = {2} ",Convert.Convert.CnvToString( screenId), userId, msg));
            }

            public void Debug(object screenId, object userId, object msg, System.Exception ex)
            {
                Logger._logger.Debug(string.Format("SCREENID = {0}  : USERID = {1}  : MSG = {2} ", Convert.Convert.CnvToString(screenId), userId, msg), ex);
            }

            public void Error(object screenId, object userId, object msg)
            {
                Logger._logger.Error(string.Format("SCREENID = {0}  : USERID = {1}  : MSG = {2} ",Convert.Convert.CnvToString( screenId), userId, msg));
            }

            public void Error(object screenId, object userId, object msg, System.Exception ex)
            {
                Logger._logger.Error(string.Format("SCREENID = {0}  : USERID = {1}  : MSG = {2} ",Convert.Convert.CnvToString( screenId), userId, msg), ex);
            }

            public void Fatal(object screenId, object userId, object msg)
            {
                Logger._logger.Fatal(string.Format("SCREENID = {0}  : USERID = {1}  : MSG = {2} ",Convert.Convert.CnvToString( screenId), userId, msg));
            }

            public void Fatal(object screenId, object userId, object msg, System.Exception ex)
            {
                Logger._logger.Fatal(string.Format("SCREENID = {0}  : USERID = {1}  : MSG = {2} ",Convert.Convert.CnvToString( screenId), userId, msg), ex);
            }

            public void Info(object screenId, object userId, object msg)
            {
                Logger._logger.Info(string.Format("SCREENID = {0}  : USERID = {1}  : MSG = {2} ",Convert.Convert.CnvToString( screenId), userId, msg));
            }

            public void Info(object screenId, object userId, object msg, System.Exception ex)
            {
                Logger._logger.Info(string.Format("SCREENID = {0}  : USERID = {1}  : MSG = {2} ",Convert.Convert.CnvToString( screenId), userId, msg), ex);
            }

            public void Warn(object screenId, object userId, object msg)
            {
                Logger._logger.Warn(string.Format("SCREENID = {0}  : USERID = {1}  : MSG = {2} ",Convert.Convert.CnvToString( screenId), userId, msg));
            }

            public void Warn(object screenId, object userId, object msg, System.Exception ex)
            {
                Logger._logger.Warn(string.Format("SCREENID = {0}  : USERID = {1}  : MSG = {2} ",Convert.Convert.CnvToString( screenId), userId, msg), ex);
            }
        }

        //private class WSAccessLogImpl : CR4SLogImpl, IWSAccessLog
        //{

        //    public string Format(object screenId, object userId, object wsName, object wsMethod)
        //    {
        //        return string.Format("{0} {1} {2} {3}", screenId, userId, wsName, wsMethod);
        //    }

        //    public void Debug(object screenId, object userId, object wsName, object wsMethod)
        //    {
        //        Logger._logger.Debug(Strings.Format(screenId, userId, wsName, wsMethod));
        //    }

        //    public void Debug(object screenId, object userId, object wsName, object wsMethod, System.Exception ex)
        //    {
        //        Logger._logger.Debug(Strings.Format(screenId, userId, wsName, wsMethod), ex);
        //    }

        //    public void Error(object screenId, object userId, object wsName, object wsMethod)
        //    {
        //        Logger._logger.Error(Strings.Format(screenId, userId, wsName, wsMethod));
        //    }

        //    public void Error(object screenId, object userId, object wsName, object wsMethod, System.Exception ex)
        //    {
        //        Logger._logger.Error(Strings.Format(screenId, userId, wsName, wsMethod), ex);
        //    }

        //    public void Fatal(object screenId, object userId, object wsName, object wsMethod)
        //    {
        //        Logger._logger.Fatal(Strings.Format(screenId, userId, wsName, wsMethod));
        //    }

        //    public void Fatal(object screenId, object userId, object wsName, object wsMethod, System.Exception ex)
        //    {
        //        Logger._logger.Fatal(Strings.Format(screenId, userId, wsName, wsMethod), ex);
        //    }

        //    public void Info(object screenId, object userId, object wsName, object wsMethod)
        //    {
        //        Logger._logger.Info(Strings.Format(screenId, userId, wsName, wsMethod));
        //    }

        //    public void Info(object screenId, object userId, object wsName, object wsMethod, System.Exception ex)
        //    {
        //        Logger._logger.Info(Strings.Format(screenId, userId, wsName, wsMethod), ex);
        //    }

        //    public void Warn(object screenId, object userId, object wsName, object wsMethod)
        //    {
        //        Logger._logger.Warn(Strings.Format(screenId, userId, wsName, wsMethod));
        //    }

        //    public void Warn(object screenId, object userId, object wsName, object wsMethod, System.Exception ex)
        //    {
        //        Logger._logger.Warn(Strings.Format(screenId, userId, wsName, wsMethod), ex);
        //    }
        //}

        //private class WSMessageLogImpl : CR4SLogImpl, IWSMessageLog
        //{

        //    public string Format(object screenId, object userId, object wsName, object wsMethod, object msg)
        //    {
        //        return string.Format("{0} {1} {2} {3} {4}", screenId, userId, wsName, wsMethod, msg);
        //    }

        //    public void Debug(object screenId, object userId, object wsName, object wsMethod, object msg)
        //    {
        //        Logger._logger.Debug(Strings.Format(screenId, userId, wsName, wsMethod, msg));
        //    }

        //    public void Debug(object screenId, object userId, object wsName, object wsMethod, object msg, System.Exception ex)
        //    {
        //        Logger._logger.Debug(Strings.Format(screenId, userId, wsName, wsMethod, msg), ex);
        //    }

        //    public void Error(object screenId, object userId, object wsName, object wsMethod, object msg)
        //    {
        //        Logger._logger.Error(Strings.Format(screenId, userId, wsName, wsMethod, msg));
        //    }

        //    public void Error(object screenId, object userId, object wsName, object wsMethod, object msg, System.Exception ex)
        //    {
        //        Logger._logger.Error(Strings.Format(screenId, userId, wsName, wsMethod, msg), ex);
        //    }

        //    public void Fatal(object screenId, object userId, object wsName, object wsMethod, object msg)
        //    {
        //        Logger._logger.Fatal(Strings.Format(screenId, userId, wsName, wsMethod, msg));
        //    }

        //    public void Fatal(object screenId, object userId, object wsName, object wsMethod, object msg, System.Exception ex)
        //    {
        //        Logger._logger.Fatal(Strings.Format(screenId, userId, wsName, wsMethod, msg), ex);
        //    }

        //    public void Info(object screenId, object userId, object wsName, object wsMethod, object msg)
        //    {
        //        Logger._logger.Info(Strings.Format(screenId, userId, wsName, wsMethod, msg));
        //    }

        //    public void Info(object screenId, object userId, object wsName, object wsMethod, object msg, System.Exception ex)
        //    {
        //        Logger._logger.Info(Strings.Format(screenId, userId, wsName, wsMethod, msg), ex);
        //    }

        //    public void Warn(object screenId, object userId, object wsName, object wsMethod, object msg)
        //    {
        //        Logger._logger.Warn(Strings.Format(screenId, userId, wsName, wsMethod, msg));
        //    }

        //    public void Warn(object screenId, object userId, object wsName, object wsMethod, object msg, System.Exception ex)
        //    {
        //        Logger._logger.Warn(Strings.Format(screenId, userId, wsName, wsMethod, msg), ex);
        //    }
        //}
    }
}