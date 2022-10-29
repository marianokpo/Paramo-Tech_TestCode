using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Commmon.Interfaces
{
    public interface IUsersServices
    {
        public Task<User> NewUser(string Name, string Email, string Address, string Phone, string UserType, string Money);

        public Task<string> NormalizeEmail(string Email);

        public Task<bool> isDuplicate(User user, List<User> users);
    }
}