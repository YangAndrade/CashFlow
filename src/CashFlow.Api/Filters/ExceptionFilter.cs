using CashFlow.communication.Responses;
using CashFlow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
       if(context.Exception is CashFlowException)
        {
            HandleProjectExeption(context);
        }else
        {
            ThrowUnknowError(context);
        }
    }

    private void HandleProjectExeption(ExceptionContext context)
    {
        if(context.Exception is ErrorOnValidationException)
        {
            // é a mesma coisa que context.Exception as ErrorOnValidationException
            var ex = (ErrorOnValidationException)context.Exception;

            var erroResponse = new ResponseErrorJson(ex.Erros);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(erroResponse);
        }
        else
        {
            var erroResponse = new ResponseErrorJson(context.Exception.Message);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(erroResponse);
        }
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        var erroResponse = new ResponseErrorJson("unknown error");
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(erroResponse);
    }
}
