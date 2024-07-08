using Microsoft.AspNetCore.Mvc;
using Student_Project.Engine.Contact;
using Student_Project.Models;
using System.Diagnostics;

namespace Student_Project.Controllers
{
    public class HomeController : Controller
    {

        private readonly IStudentServices _services;


        public HomeController(IStudentServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {

            return View(_services.GetAll());
        }


        [HttpPost]
        public IActionResult Save(Student contact)
        {

            _services.SaveContact(contact);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            _services.DeleteContact(id);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Form(int Id)
        {
            var contact = new Student();
            if (Id != 0)
            {
                ViewBag.buttonName = "Edit";
                contact = _services.GetStudent(Id);
            }
            else
            {

                ViewBag.buttonName = "Add";
            }
            return View(contact);
        }


        public IActionResult Search(string searching)
        {
            var searchResults = new List<Student>();

            if (searching != null)
            {
                searchResults = _services.GetSearch(searching).ToList();

                return View("Index", searchResults);
            }
            return RedirectToAction("Index", searchResults);

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
