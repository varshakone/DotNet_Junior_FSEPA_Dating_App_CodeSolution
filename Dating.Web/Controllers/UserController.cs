using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dating.BusinessLayer.Interface;
using Dating.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Dating.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;

        }


        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        public IActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Login(String UserName, String Password)
        {
            try
            {
                var result =await _userService.VerifyUser(UserName, Password);
                if(result !=null)
                {
                    return View("Index");
                }
                return View();
            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
            
        }
        public IActionResult CreateNewUser()
        {
            try
            {
                return View();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewUser(User user)
        {
            //Business logic goes here
            try
            {
                var result =await _userService.CreateNewUser(user);
                if (result != null)
                {
                    return RedirectToAction("Login");
                }
                return View();
            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
          
        }



        public IActionResult AddProfile()
        {
            try
            {
                return View();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        public async Task<IActionResult> AllMembers()
        {
            try
            {
                var result = await _userService.ListOfMembers();
                return View(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        
        
        public IActionResult UserProfile(Profile profile)
        {
            try
            {
               return View(profile);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
   

        [HttpPost]
        public async Task<IActionResult> AddProfile(Profile profile)
        {
            try
            {
                var result = await _userService.AddProfile(profile);
                if (result != null)
                {
                    return RedirectToAction("UserProfile","User",profile);
                }
                return View();
            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
            
        }
    }
}
