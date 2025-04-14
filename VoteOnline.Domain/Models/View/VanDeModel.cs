using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteOnline.Domain.Models.View
{
    public class VanDeModel
    {
        public int Id { get; set; }
        public string TenVD { get; set; } = "";
        public string? Mota { get; set; } = "";
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string? DinhDang { get; set; }
        public int IdDinhDang { get; set; }
        public string? MainAccount { get; set; }
        public int IdMainAccount { get; set; }
    }
}
