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


    public class SubAccountRequest
    {
        public int Id { get; set; }
        public int IdMainAccount { get; set; }
        public int IdVanDe { get; set; }
        public required List<SubAccountModel> subAccountModels { get; set; }
    }
}
