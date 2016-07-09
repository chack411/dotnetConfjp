using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class CharacterController : Controller
    {
        public async Task<IActionResult> Index()
        {
            PeopleResult people = null;

            using (var client = new HttpClient()) {
                var response = await client.GetAsync("http://swapi.co/api/people");
                var json = await response.Content.ReadAsStringAsync();
                people = JsonConvert.DeserializeObject<PeopleResult>(json);
            }

            return View(people.results);
        }
    }
}