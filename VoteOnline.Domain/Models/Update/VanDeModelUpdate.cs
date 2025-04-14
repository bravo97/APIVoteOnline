using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteOnline.Domain.Models.Update
{
    public class VanDeModelUpdate
    {
        public int Id { get; set; }
        public string TenVD { get; set; } = "";
        public string? Mota { get; set; } = "";
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int DinhDang { get; set; }
        public int MainAccount { get; set; }
    }
}
