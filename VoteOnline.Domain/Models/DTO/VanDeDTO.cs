using Azure.Core.Pipeline;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteOnline.Domain.Models.DTO
{
    public class VanDeDTO
    {
        public int Id { get; set; }
        public string TenVD { get; set; } = "";
        public string? Mota { get; set; } = "";
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public List<PhuongAnDTO> PhuongAns { get; set; }
        public string? MainAccount { get; set; }
        public int IdMainAccount { get; set; }
        public string Code { get; set; }
    }

    public class VanDeID
    {
        public List<int> ListID { get; set; }
        public string Code { get; set; }
    }
}
