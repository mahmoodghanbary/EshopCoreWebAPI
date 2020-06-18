using Microsoft.AspNetCore.Mvc;
using WebClient.Services;
using WebClient.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebClient.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UserRepository _userRepository;
        public UserController()
        {
            _userRepository = new UserRepository();
        }
        public IActionResult Index()
        {
            string token = User.FindFirst("AccessToken").Value;
            return View(_userRepository.GetAll(token));
        }
  
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Users users )
        {
            _userRepository.Create(users);
            return View();
        }
         public IActionResult GetUser(int id )
           {
            return View(_userRepository.GetbyId(id));
           }



}
}