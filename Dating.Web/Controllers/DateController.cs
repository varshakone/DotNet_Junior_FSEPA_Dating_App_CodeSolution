using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dating.BusinessLayer.Interface;
using Dating.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Dating.Web.Controllers
{
    public class DateController : Controller
    {
        private readonly IDateService _dateService;
        public DateController(IDateService dateService)
        {
            _dateService = dateService;

        }
        public IActionResult SendRequest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendRequest(DateDetails dateDetails)
        {
          var result = await _dateService.SendRequest(dateDetails);
            if(result !=null)
            {
                ViewBag.message = result;
            }
            return View();
        }
    }
}