using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIClient.Models;
using WebAPIClient.WebAPIMethods;

namespace WebAPIClient.Controllers
{
    public class HomeController : Controller
    {
        private List<Person> _persons;
        private WebAPIConnection _WebAPI;

        public HomeController()
        {
            _WebAPI = new WebAPIConnection($"http://localhost:3753/api/Person");
        }

        public async Task<ActionResult> Index()
        {
            var WebAPIResult = await _WebAPI.Get();
            return View(WebAPIResult);
        }

        public async Task<ActionResult> CreateNewPerson()
        {
            await _WebAPI.CrateNewPerson();
            return RedirectToAction("Index");
        }
    }
}