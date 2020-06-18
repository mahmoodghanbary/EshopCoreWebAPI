using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EShopAPI.Models;
using EShopAPI.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace EShopAPI.Controllers
{
    [Route("api/[controller]")]
  // [Authorize]
    public class UsersController : ControllerBase
    {
    private IUserRepository _userRepository;
        
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<Users> GetUsers()
        {
            return _userRepository.GetAll().Result;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [ResponseCache(Duration =60)]

        public async Task<IActionResult> GetUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _userRepository.GetById(id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers([FromRoute] int id, [FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.ID)
            {
                return BadRequest();
            }

            await _userRepository.Update(users);

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUsers([FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
  
            await _userRepository.Add(users);

            return CreatedAtAction("GetUsers", new { id = users.ID }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _userRepository.GetById(id);
            if (users == null)
            {
                return NotFound();
            }

           
            await _userRepository.Remove(users);

            return Ok(users);
        }

        private async Task<bool> UsersExists(int id)
        {
            var result = await _userRepository.FirstOrDefault(i => i.ID == id);
            return true;
        }
    }
}