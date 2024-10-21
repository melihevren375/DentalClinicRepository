namespace Services.Contracts;

public interface ILoggerService
{
    void LogError(string message);
    void LogDebug(string message);
    void LogInfo(string message);
    void LogWarn(string message);
}
