using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetAll;

public class GetAllExpensesUseCase(IExpensesRepository repository, IMapper mapper) : IGetAllExpensesUseCase
{
    private readonly IExpensesRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    public async Task<ResponseExpenseJson> Execute()
    {
        var result = await _repository.GetAllAsync();

        return new ResponseExpenseJson
        {
            Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(result)
        };


    }
}
