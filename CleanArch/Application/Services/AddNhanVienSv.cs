using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.IActions;

namespace Application.Services
{
    public class AddNhanVienSv : IAddNhanVienSv
    {
        private readonly IAccountAc accountAc;
        private readonly INhanVienAc nhanVienAc;
        private readonly IChiTietNhanVienAc chiTietNhanVienAc;
        public AddNhanVienSv(IAccountAc accountAc, INhanVienAc nhanVienAc, IChiTietNhanVienAc chiTietNhanVienAc)
        {
            this.accountAc = accountAc;
            this.nhanVienAc = nhanVienAc;
            this.chiTietNhanVienAc = chiTietNhanVienAc;
        }
        public string AddNhanVien(AddNhanVien addNhanVien)
        {
            string errorMessage;
            (Account account, NhanVien nhanVien, ChiTietNhanVien chiTietNhanVien) objs = addNhanVien.ToObjs();
            errorMessage = nhanVienAc.CheckRelationship(objs.nhanVien);
            if(errorMessage == null)
            {
                accountAc.Add(objs.account);
                nhanVienAc.Add(objs.nhanVien);
                chiTietNhanVienAc.Add(objs.chiTietNhanVien);
            }
            return errorMessage;
        }
    }
}
