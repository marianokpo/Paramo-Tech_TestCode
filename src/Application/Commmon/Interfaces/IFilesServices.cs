using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Commmon.Interfaces
{
    public interface IFilesServices
    {
        public Task<List<User>> GetUsersFromFile();

        public bool WriteUserToFile(User user);
    }
}