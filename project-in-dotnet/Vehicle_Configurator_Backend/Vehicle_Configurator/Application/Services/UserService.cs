using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle_Configurator.Application.Interfaces;
using Vehicle_Configurator.Domain.Entities;
using Vehicle_Configurator.Infrastructure.Repositories;

namespace Vehicle_Configurator.Application.Services
{
    public class UserService : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
                return new NotFoundResult();

            return user;
        }

        public async Task<ActionResult<User>> GetByUsername(string username)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
                return new NotFoundResult();

            return user;
        }

        public async Task Add(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.User.FindAsync(id);
            if (entity != null)
            {
                _context.User.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
