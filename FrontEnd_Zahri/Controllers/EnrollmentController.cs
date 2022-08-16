using FrontEnd_Zahri.Models;
using FrontEnd_Zahri.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd_Zahri.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollment _enrollment;

        public EnrollmentController(IEnrollment enrollment)
        {
            _enrollment = enrollment;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _enrollment.GetAll();
            ViewData["pesan"] = TempData["pesan"] ?? TempData["pesan"];
            return View(result);
        }
        public async Task<IActionResult> Details(int id)
        {
            var m = await _enrollment.GetById(id);
            return View(m);
        }

        public async Task<IActionResult> DetailsEnr(int id)
        {
            var m = await _enrollment.GetEnr(id);
            return View(m);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Enrollment enrollment)
        {
            try
            {
                var result = await _enrollment.Insert(enrollment);
                TempData["pesan"] =
                   $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> " +
                  $"Berhasil menambahkan data enrollment {result.EnrollmentID}</div>";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["pesan"] =

                    $"<div class='alert alert-warning alert-dismissible fade show'>" +
                  $"<button type='button' class='btn-close' data-bs-dismiss='alert'></button> " +
                  $"Gagal Menambahkan Data Enrollment</div>";
                return View();
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            var m = await _enrollment.GetById(id);
            return View(m);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Enrollment enrollment)
        {
            try
            {
                var result = await _enrollment.Update(enrollment);
                TempData["pesan"] =
                  $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> " +
                 $"Berhasil Update data Enrollment {result.EnrollmentID}</div>";

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                return View();

            } 
        }
        public async Task<IActionResult> Delete(int id)
        {
            var mdel = await _enrollment.GetById(id);
            return View(mdel);
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _enrollment.Delete(id);
                TempData["pesan"] =
                      $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> " +
                      $"Berhasil Hapus data enrollment {id}</div>";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }


        }
        
  

    }
}
