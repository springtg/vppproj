using System;

namespace COREBASE.COMMAND.LogUtils
{
    public interface IAppLog: IVXSERPLog
    {
        void Debug(object screenId, object userId, object msg);
        void Debug(object screenId, object userId, object msg, Exception ex);
        void Info(object screenId, object userId, object msg);
        void Info(object screenId, object userId, object msg, Exception ex);
        void Warn(object screenId, object userId, object msg);
        void Warn(object screenId, object userId, object msg, Exception ex);
        void Error(object screenId, object userId, object msg);
        void Error(object screenId, object userId, object msg, Exception ex);
        void Fatal(object screenId, object userId, object msg);
        void Fatal(object screenId, object userId, object msg, Exception ex);

    }
}
