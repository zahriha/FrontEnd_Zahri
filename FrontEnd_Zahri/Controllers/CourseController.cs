using FrontEnd.Models;
using FrontEnd_Zahri.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd_Zahri.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourse _course;

        public CourseController(ICourse course)
        {
            _course = course;
        }
        public async Task<IActionResult> Index(string? name)
        {
            var result = await _course.GetAll();
            ViewData["pesan"] = TempData["pesan"] ?? TempData["pesan"];
            IEnumerable<Course> mdel;
            if (name == null)
            {
                mdel = await _course.GetAll();
            }
            else
            {
                mdel = await _course.GetByName(name);
            }
            return View(mdel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var m = await _course.GetById(id);
            return View(m);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            try
            {
                var result = await _course.Insert(course);
                TempData["pesan"] =
                   $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> " +
                  $"Berhasil menambahkan data Course {result.Title}</div>";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["pesan"] =

                    $"<div class='alert alert-warning alert-dismissible fade show'>" +
                  $"<button type='button' class='btn-close' data-bs-dismiss='alert'></button> " +
                  $"Gagal Menambahkan Data Course</div>";
                return View();
            }


        }
        public async Task<IActionResult> Update(int id)
        {
            var m = await _course.GetById(id);
            return View(m);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Course course)
        {
            try
            {
                var result = await _course.Update(course);
                TempData["pesan"] =
                  $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> " +
                 $"Berhasil Update data Course {result.Title}</div>";

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                return View();

            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var mdel = await _course.GetById(id);
            return View(mdel);
        }
        [ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _course.Delete(id);
                TempData["pesan"] =
                      $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> " +
                      $"Berhasil Hapus data course {id}</div>";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }


        }
    }
}
