using Domain.Entities;
using System.Collections.Generic;

namespace Domain.IActions
{
    public interface IDuAnAc : IGeneralAction<DuAn>
    {
        List<DuAn> ProjectInProgress();
    }
}
