using Domain.Entities;

namespace Domain.IActions
{
    public interface ILuongThangAc : IGeneralAction<LuongThang>
    {
        void AutoAdd();
    }
}
