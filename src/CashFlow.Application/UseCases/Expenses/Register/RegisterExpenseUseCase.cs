using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase(IExpenseWritenOnlyRepository repository, IUnityOfWork unityOfWork, IMapper mapper) : IRegisterExpenseUseCase
{
    private readonly IExpenseWritenOnlyRepository _repository = repository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task<ResponseRegisterExpenseJson> Execute(RequestExpensesJson request)
    {
        Validate(request);
        var entity = _mapper.Map<Expense>(request);

        await _repository.Add(entity);

        await _unityOfWork.Commit();

        return _mapper.Map<ResponseRegisterExpenseJson>(entity);
    }

    private void Validate(RequestExpensesJson request)
    {
        var validator = new ExpenseValidator();
        var result = validator.Validate(request);
        if(!result.IsValid)
        {
            var erroMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ErrorOnValidationException(erroMessages);
        }
    }
}
