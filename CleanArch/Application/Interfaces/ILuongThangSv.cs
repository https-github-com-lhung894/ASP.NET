using Application.DTOs;
using Domain.IActions;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ILuongThangSv : IGeneralAction<LuongThangDTO>
    {
        public List<LuongThangDTO> ToList(string NhanVienId);
        public List<LuongThangDTO> ToListById(string NhanVienId);
        void AutoAdd();
        List<LuongThangDTO> Filter(string NhanVienId, string ThangChecked, int Thang, string NamChecked, int Nam, 
            string optradio, string Tu, string Den, string NhanVienIdToKen);
    }
}
