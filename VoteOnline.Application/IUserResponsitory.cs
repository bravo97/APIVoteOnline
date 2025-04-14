using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteOnline.Domain.Models;
using VoteOnline.Domain.Models.DTO;

namespace VoteOnline.Application
{
    public interface IUserResponsitory
    {
        Task<TokenApiDTO> AuthenticateAsync(UserModel user);
        Task<MainAccountModel> Register(MainAccountModel user);
        Task<bool> CheckEmailExists(string email);
        Task<TokenApiDTO> LoginAsync(UserModel user);
    }
}
