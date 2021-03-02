using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class Users : BaseApiController
    {
        private readonly DataContext _dbContext;

        public Users(DataContext DbContext)
        {
            _dbContext = DbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }
    }
}