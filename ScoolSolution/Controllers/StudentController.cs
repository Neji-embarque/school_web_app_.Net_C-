using Microsoft.AspNetCore.Mvc;
using ScoolSolution.Models;
using ScoolSolution.Models.ViewModels;
using ScoolSolution.Repository;
using Microsoft.AspNetCore.Hosting;


namespace ScoolSolution.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IHostEnvironment  _environment;

        public StudentController(IStudentRepository studentRepository, 
                                 ICourseRepository courseRepository, IHostEnvironment environment)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _environment = environment;
        }

        //list of students
        [HttpGet]
        public ActionResult Index()
        {
            List<Student> studentLst = _studentRepository.GetAllStudents() ;
            return View(studentLst);
        }
        //render the creation view
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student, IFormFile StudentPhoto)
        {
                var wwRootPath = _environment.ContentRootPath + "/wwwroot/StudentPictures/";
                Guid guid = Guid.NewGuid();
                string fullPath= System.IO.Path.Combine(wwRootPath,guid+ StudentPhoto.FileName);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    StudentPhoto.CopyTo(fileStream);
                };

                student.PhotoName = guid + StudentPhoto.FileName;
                _studentRepository.Create(student);
                List<Student> studentLst = _studentRepository.GetAllStudents();
                return View("Index",studentLst);
        }
        public ViewResult Delete(int id)
        {
            if (id > 0)
            {
                _studentRepository.Delete(id);
            }
            List<Student> studentLst = _studentRepository.GetAllStudents();
            return View("Index",studentLst);
        }
        [HttpGet]
        public ActionResult Register()
        {

            StudentCourseVM data = new StudentCourseVM();
            data.Courses = _courseRepository.GetAllCourses();
            data.Students = _studentRepository.GetAllStudents();
            return View(data);
        }
        [HttpPost]
        public ActionResult Register (int studentid, int courseid)
        {
            TempData["test"] = 10;

            _studentRepository.Register(studentid, courseid);
            return RedirectToAction("Register");
        }
    }
}
