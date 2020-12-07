using Domain.Entities;
using System.Collections.Generic;

namespace Domain.IActions
{
    public interface ILuongThangAc : IGeneralAction<LuongThang>
    {
        void AutoAdd();
        List<LuongThang> Filter(string NhanVienId, string ThangChecked, int Thang, string NamChecked, int Nam, string optradio, string Tu, string Den);
    }
}
