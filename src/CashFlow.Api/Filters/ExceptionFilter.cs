using CashFlow.Communication.Responses;
using CashFlow.Exception;
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
       
        var cashFlowException = context.Exception as CashFlowException;
        var erroResponse = new ResponseErrorJson(cashFlowException!.GetErros());
        context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
        context.Result = new ObjectResult(erroResponse);

    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        var erroResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(erroResponse);
    }
}
