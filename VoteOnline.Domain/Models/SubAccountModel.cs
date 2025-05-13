using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteOnline.Domain.Models
{
    public class SubAccountModel
    {
        public int Id { get; set; }
        public string? HoTen { get; set; }
        public string? DienThoai { get; set; }
        public string? CMND { get; set; }
        public string? KhoaBM { get; set; }
    }
}
