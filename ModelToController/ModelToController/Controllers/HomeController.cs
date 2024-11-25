using Microsoft.AspNetCore.Mvc;
using ModelToController.Models;
using ModelToController.Repository;

namespace ModelToController.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentRepository _studentRepository;

        public HomeController()
        {
            _studentRepository = new StudentRepository();
        }

        public IActionResult Index()
        {

            //var students = new List<StudentModel>
            //{
            //    new StudentModel {RollNo = 1,Name = "Rohit Kucheria", Gender = "Male",Standard = 11},
            //    new StudentModel {RollNo = 2,Name = "Manish Kucheria", Gender = "Male",Standard = 12},
            //    new StudentModel {RollNo = 3,Name = "Rajesh", Gender = "Male",Standard = 10}
            //};

            ViewData["myStudents"] = _studentRepository.getAllStudents();
            return View();
        }
    }
}
