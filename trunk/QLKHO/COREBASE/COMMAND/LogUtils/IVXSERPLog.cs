
namespace COREBASE.COMMAND.LogUtils
{
    public interface IVXSERPLog
    {

        bool IsDebugEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsErrorEnabled { get; }

        bool IsFatalEnabled { get; }
    }
}
