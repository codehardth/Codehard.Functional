namespace Codehard.Functional.AspNetCore;

public static class LogExtensions
{
    public static Unit Log(this ILogger logger, HttpResultError error)
    {
        error.Inner.IfSome(err => 
                        err is HttpResultError hre
                            ? Log(logger, hre)
                            : Logger.LoggerExtensions.Log(logger, err));

        return
            error.Code is >= 500 and < 600
                ? error.Exception.Match(
                    Some: ex => logger.LogError(ex, "{Message}", error.Message),
                    None: () =>
                    {
                        if (string.IsNullOrWhiteSpace(error.Message))
                        {
                            logger.LogError("{Code}", error.Code);
                        }
                        else
                        {
                            logger.LogError("{Code} : {Message}", error.Code, error.Message);
                        }
                    })
                : error.Exception.Match(
                    Some: ex => logger.LogWarning(ex, "{Message}", error.Message),
                    None: () =>
                    {
                        if (string.IsNullOrWhiteSpace(error.Message))
                        {
                            logger.LogInformation("{Code}", error.Code);
                        }
                        else
                        {
                            logger.LogInformation("{Code} : {Message}", error.Code, error.Message);
                        }
                    });
    }
}