using Formular_one_api.Core;
namespace Formular_one_api;

public interface IUnitOfWork
{
    IDriverRepository Drivers { get; }
    Task CompleteAsync();

}