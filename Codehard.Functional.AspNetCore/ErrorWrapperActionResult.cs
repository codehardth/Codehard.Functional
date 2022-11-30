using System.Dynamic;

namespace Codehard.Functional.AspNetCore;

public class ErrorWrapperActionResult : IActionResult
{
    private readonly HttpResultError error;

    public HttpResultError Error => error;

    public ErrorWrapperActionResult(HttpResultError error)
    {
        this.error = error ?? throw new ArgumentNullException(nameof(error));
    }

    public async Task ExecuteResultAsync(ActionContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }
        
        error.ErrorCode.IfSome(errCode =>
            context.HttpContext.Response.Headers.Add("x-error-code", errCode));

        if (error.Data.IsNone)
        {
            await new ObjectResult(error.Message)
            {
                StatusCode = error.Code
            }
            .ExecuteResultAsync(context);
        }

        await error.Data.Map(
                data =>
                    data switch
                    {
                        ObjectResult objectResult => AddErrorInfo(objectResult),
                        IActionResult ar => ar,
                        _ => AddErrorInfo(new ObjectResult(data)
                        {
                            StatusCode = error.Code
                        })
                    })
            .IfSomeAsync(ar => ar.ExecuteResultAsync(context));

        ObjectResult AddErrorInfo(ObjectResult objectResult)
        {
            IDictionary<string, object?> expando = new ExpandoObject();

            if (objectResult.Value != null)
            {
                foreach (var propertyInfo in objectResult.Value!.GetType().GetProperties())
                {
                    var currentValue = propertyInfo.GetValue(objectResult.Value);
                    expando.Add(propertyInfo.Name, currentValue);
                }
            }

            expando["errorInfo"] =
                new
                {
                    ErrorCode = error.ErrorCode.IfNoneUnsafe(default(string)),
                    ErrorMessage = error.Message,
                };

            return new ObjectResult(expando)
            {
                StatusCode = error.Code
            };
        }
    }
}