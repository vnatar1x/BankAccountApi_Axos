using BanAccountApi_Logging.Interfaces;

namespace BanAccountApi_Logging.Implementations
{
    public class LogWrapper : ILogWrapper
    {
        public void WriteLog(string message)
        {
            LogBase.WriteLog(message);
        }
    }
}
