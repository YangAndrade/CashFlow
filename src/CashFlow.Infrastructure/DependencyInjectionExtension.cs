using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure( this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddDbContexts(services, configuration);
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IExpenseWritenOnlyRepository, ExpensesRepository>();
        services.AddScoped<IExpensesReadOnlyRepository, ExpensesRepository>();
        services.AddScoped<IExpenseUpdateOnlyRepository, ExpensesRepository>();
        services.AddScoped<IUnityOfWork, UnityOfWork>();

    }
    private static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("connection"); ;
        var serverVersion = new MySqlServerVersion(new Version(9, 5, 0));
        services.AddDbContext<CashFlowDbContext>(config => config.UseMySql(connectionString,serverVersion));
    }
}
