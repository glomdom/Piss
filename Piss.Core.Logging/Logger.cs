using Serilog;
using Serilog.Events;

namespace Logging;

public static class Logger {
    public static ILogger Instance => _logger.Value;
    
    private static Lazy<ILogger> _logger = new(BuildLogger);
    private static LogEventLevel _logLevel = LogEventLevel.Debug;

    public static void SetLogLevel(LogEventLevel logLevel) {
        _logLevel = logLevel;
        _logger = new Lazy<ILogger>(BuildLogger);
    }

    private static ILogger BuildLogger() => new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .WriteTo.File("logs/logs-.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

    public static void Information(string message, params object[] args) => Instance.Information(message, args);
    public static void Warning(string message, params object[] args) => Instance.Warning(message, args);
    public static void Error(string message, Exception exception, params object[] args) => Instance.Error(exception, message, args);
    public static void Debug(string message, params object[] args) => Instance.Debug(message, args);
}