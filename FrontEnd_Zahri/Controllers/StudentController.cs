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
            ViewData["pesan"] = TempData["pesan"] ?? TempData["pesan"];

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

        public async Task<IActionResult> StudentC()
        {
            var m = await _student.GetStudent();
            return View(m);
        }
       

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            try
            {
                var result = await _student.Insert(student);
                TempData["pesan"] =
                   $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> " +
                  $"Berhasil menambahkan data Student {result.FirstName}</div>";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["pesan"] =

                    $"<div class='alert alert-warning alert-dismissible fade show'>" +
                  $"<button type='button' class='btn-close' data-bs-dismiss='alert'></button> " +
                  $"Gagal Menambahkan Data Student</div>";
                return View();
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            var m = await _student.GetById(id);
            return View(m);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Student student)
        {
            try
            {
                var result = await _student.Update(student);
                TempData["pesan"] =
                  $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> " +
                 $"Berhasil Update data Student {result.FirstName}</div>";

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                return View();

            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var mdel = await _student.GetById(id);
            return View(mdel);
        }
        [ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _student.Delete(id);
                TempData["pesan"] =
                      $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> " +
                      $"Berhasil Hapus data Student {id}</div>";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }


        }
    }
}
