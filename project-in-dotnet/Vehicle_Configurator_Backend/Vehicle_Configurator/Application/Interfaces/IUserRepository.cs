using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle_Configurator.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Vehicle_Configurator.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<ActionResult<IEnumerable<User>>> GetAll();
        Task<ActionResult<User>> GetById(int id);
        Task<ActionResult<User>> GetByUsername(string username);
        Task Add(User user);
        Task Update(User user);
        Task Delete(int id);
    }
}
