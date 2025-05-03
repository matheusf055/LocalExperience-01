using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.Domain.Users.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(Guid id);
        Task<User> GetByIdWithDetails(Guid id);
        Task<User> GetByEmail(string email);
        Task Create(User user);
        Task Update(User user);
        Task Delete(Guid id);
    }
}
