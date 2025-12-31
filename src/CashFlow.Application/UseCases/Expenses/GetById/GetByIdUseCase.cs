using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetById;

public class GetByIdUseCase(IExpensesRepository repository, IMapper mapper) : IGetByIdUseCase
{
    private readonly IExpensesRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    public async Task<ResponseExpenseJson> Execute(long id)
    {
        var result = await _repository.GetExpenseById(id);

        return _mapper.Map<ResponseExpenseJson>(result);
    }
}
