using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class AccountDTO
    {
        [Required]
        [StringLength(45)]
        public string AccountId { get; set; }
        [StringLength(45)]
        public string TaiKhoan { get; set; }
        [StringLength(45)]
        public string MatKhau { get; set; }
        [StringLength(45)]
        public int? Quyen { get; set; }
    }
}