using Admin.Common.Configuration;
using log4net;
using log4net.Config;

namespace Admin.Common.Logging
{
    public class Log4NetAdapter : ILogger
    {
        private readonly ILog _log;

        //public Log4NetAdapter()
        //{
        //    XmlConfigurator.Configure();
        //    _log = LogManager
        //     .GetLogger(ApplicationSettingsFactory.GetApplicationSettings().LoggerName);

        //}
        public Log4NetAdapter()
        {
            var config = new WebConfigApplicationSettings();
            XmlConfigurator.Configure();
            this._log = LogManager.GetLogger(config.LoggerName);
        }

        public void Log(string message)
        {
            this._log.Info(message);
        }
    }
}