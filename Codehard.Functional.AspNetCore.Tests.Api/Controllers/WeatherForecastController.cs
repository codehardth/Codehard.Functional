using System.Net;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using static LanguageExt.Prelude;

namespace Codehard.Functional.AspNetCore.Tests.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpGet(template: "GetSuccessEff")]
    public IActionResult GetSuccessEff()
    {
        var eff = SuccessEff(Get());

        return eff.RunToResult();
    }
    
    [HttpGet(template: "Get500FailWithMsgEff")]
    public IActionResult Get500FailWithMsgEff()
    {
        var eff = FailEff<IEnumerable<WeatherForecast>>(
            HttpResultError.New(
                HttpStatusCode.InternalServerError,
                "Error Msg"));

        return eff.RunToResult();
    }
    
    [HttpGet(template: "Get500FailWithMsgAndErrCodeEff")]
    public IActionResult Get500FailWithMsgAndErrCodeEff()
    {
        var eff = FailEff<IEnumerable<WeatherForecast>>(HttpResultError.New(
            HttpStatusCode.InternalServerError,
            "Error Msg",
            errorCode: "Err001"));

        return eff.RunToResult();
    }
    
    [HttpGet(template: "Get500FailWithMsgErrCodeAndDataEff")]
    public IActionResult Get500FailWithMsgErrCodeAndDataEff()
    {
        var eff = FailEff<IEnumerable<WeatherForecast>>(HttpResultError.New(
            HttpStatusCode.InternalServerError,
            "Error Msg",
            errorCode: "Err001",
            data: new
            {
                TraceId = Guid.NewGuid(),
                CorrelationId = Guid.NewGuid(),
            }));

        return eff.RunToResult();
    }
    
    [HttpGet(template: "Get400FailWithMsgErrCodeAndDataEff")]
    public IActionResult Get400FailWithMsgErrCodeAndDataEff()
    {
        var eff = FailEff<IEnumerable<WeatherForecast>>(HttpResultError.New(
            HttpStatusCode.BadRequest,
            "Error Msg",
            errorCode: "Err001",
            data: this.BadRequest()));

        return eff.RunToResult();
    }
}