using FrontEnd_Zahri.Models;
using FrontEnd_Zahri.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace FrontEnd_Zahri.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollment _enrollment;
        private readonly IStudent _student;
        private readonly ICourse _course;

        public int? TotalPages { get; private set; }

        public EnrollmentController(IEnrollment enrollment, IStudent student, ICourse course)
        {
            _enrollment = enrollment;
            _student = student;
            _course = course;
        }
        public async Task<IActionResult> Index()
        {
            string mytoken = string.Empty;

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("token")))
            {
                mytoken = HttpContext.Session.GetString("token");
            }

            var result = await _enrollment.GetAll(mytoken);
            ViewData["pesan"] = TempData["pesan"] ?? TempData["pesan"];
            return View(result);
        }
        public async Task<IActionResult> Details(int id)
        {
            var m = await _enrollment.GetById(id);
            return View(m);
        }

        public async Task<IActionResult> CreateAsync()
        {
           // ViewData["CourseID"] = new SelectList(await _course.GetAll(), "CourseID", "Title");
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]

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
            //ViewData["CourseID"] = new SelectList(await _course.GetAll(), "CourseID", "Title", enrollment.CourseID);
            //return View(enrollment);

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
