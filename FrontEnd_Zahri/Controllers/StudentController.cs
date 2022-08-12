using FrontEnd_Zahri.Models;
using FrontEnd_Zahri.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd_Zahri.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _student;

        public StudentController(IStudent student)
        {
            _student = student;
        }
        public async Task<IActionResult> Index(string? name)
        {
            var result = await _student.GetAll();
            IEnumerable<Student> mdel;
            if (name == null)
            {
                mdel = await _student.GetAll();
            }
            else
            {
                mdel = await _student.GetByName(name);
            }
            return View(mdel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var m = await _student.GetById(id);
            return View(m);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
