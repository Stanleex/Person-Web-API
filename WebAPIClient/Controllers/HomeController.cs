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

        public async Task<ActionResult> GetPersonById(int id)
        {
            var WebAPIResult = await _WebAPI.GetPersonById(id);
            return View("SinglePersonView", WebAPIResult);
        }

        public async Task<ActionResult> CreateNewPerson(int id, string firstName, string lastName)
        {
            await _WebAPI.CrateNewPerson(id, firstName, lastName);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> UpdatePerson(int id, string firstName, string lastName)
        {
            await _WebAPI.UpdatePersonData(id, firstName, lastName);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> DeletePerson(int id)
        {
            await _WebAPI.DeletePerson(id);
            return RedirectToAction("Index");
        }

    }
}