﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteOnline.Domain.Models.DTO
{
    public class TokenUserApiDTO
    {
        public string AccessToken { get; set; } = string.Empty;
        public string Room { get; set; } = string.Empty;
    }
}
