using Application.DTOs;
using Domain.IActions;

namespace Application.Interfaces
{
    public interface IAccountSv : IGeneralAction<AccountDTO>
    {
    }
}
