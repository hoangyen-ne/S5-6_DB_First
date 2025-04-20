using BT_DBFirst.Models.ViewModel;
using BT_DBFirst.Data;
using BT_DBFirst.Models;
using BT_DBFirst.Models.Domain;
using BT_DBFirst.Models.Repository;
using BT_DBFirst.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Example.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        //GET http://localhost:port//Student/GetAll
        public IActionResult GetAll(string? searchString, string? type)
        {
            var allStudent = _studentRepository.GetAll(searchString, type);
            return View(allStudent);
        }

        //GET http://localhost:port//Student/GetStudentById/id
        public IActionResult GetStudentById(int id)
        {
            var StudentById = _studentRepository.GetStudentsById(id);
            if (StudentById != null)
            {
                return View(StudentById);

            }
            else
                return View("NotFound");

        }
        [HttpGet]
        public IActionResult EditStudentById(int id)
        {
            var studentVM = _studentRepository.GetStudentsById(id);
            if (studentVM != null)
            {
                return View(studentVM);
            }
            else
            {
                return View("NotFound");

            }
        }
        [HttpPost]// POST http://localhost:port//Student/EditStudentbyId/id
        public IActionResult EditStudentById([FromRoute] int id, VMStudent student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var StudentById = _studentRepository.GetStudentsById(id);
                    if (StudentById != null)
                    {
                        _studentRepository.UpdateStudentById(id, student);
                        TempData["successMessage"] = "Successful";
                        return RedirectToAction("GetAll");
                    }
                    else
                    {
                        return View("NotFound");

                    }
                }
                else
                {
                    TempData["errorMessage"] = "Data is not valid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(VMStudent studentData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentRepository.AddStudent(studentData);
                    TempData["successMessage"] = "Successful";
                    return RedirectToAction("GetAll");
                }
                else
                {
                    TempData["errorMessage"] = "Data is not valid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        public IActionResult DelStudentById(int id)
        {
            var StudentById = _studentRepository.GetStudentsById(id);
            if (StudentById != null)
            {
                _studentRepository.DeleteStudentById(id);
                TempData["successMessage"] = "Deleted";
                return RedirectToAction("GetAll");
            }
            else
            {
                return View("NotFound");

            }
        }
    }
}