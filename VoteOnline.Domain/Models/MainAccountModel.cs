using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteOnline.Domain.Models
{
    public class MainAccountModel
    {
        public int ID { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string DienThoai { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string HoTen { get; set; } = null!;
    }
}
