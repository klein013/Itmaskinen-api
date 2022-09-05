using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itmaskinen_api.Models;
using Itmaskinen_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Itmaskinen_api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly DatabaseContext _dbContext;
        private readonly IEmailService _emailService;

        public UserController(DatabaseContext dbContext, IEmailService emailService)
        {
            _dbContext = dbContext;
            _emailService = emailService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _dbContext._userEntities.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<User> GetAsync(int id)
        {
            return await _dbContext._userEntities.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        // POST api/values
        [HttpPost]
        public async Task PostAsync(User data)
        {
            _dbContext._userEntities.Add(data);
            await _dbContext.SaveChangesAsync();
            _emailService.SendAccountCreatedEmail(data.Email);
        }

        // POST api/values
        [Route("[action]")]
        [HttpPost]
        public async Task<bool> Login(string email, string password)
        {
            if(await _dbContext._userEntities.Where(x => x.Email == email && x.Password == password).CountAsync() > 0)
            {
                return true;
            }
            return false;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            _dbContext.Remove(_dbContext._userEntities.Where(x => x.Id == id).First());
            await _dbContext.SaveChangesAsync();
        }

        [HttpPut]
        public async Task Update(User data)
        {
            _dbContext.Update(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
