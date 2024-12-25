using Microsoft.AspNetCore.Mvc;
using ScoolSolution.Models;
using ScoolSolution.Repository;

namespace ScoolSolution.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;
        public CourseController(ICourseRepository courseRepository, ITeacherRepository teacherRepository)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Course> courseLst = _courseRepository.GetAllCourses();
            return View(courseLst);
        }
        [HttpGet]
        public ViewResult Create()
        {
            List<Teacher> teacherLst = _teacherRepository.GetAllTeachers();
            return View(teacherLst);
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (course != null)
            {
                _courseRepository.Create(course);
            }
            List<Course> courseLst = _courseRepository.GetAllCourses();
            return View("index", courseLst);
        }
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                _courseRepository.Delete(id);
            }
            List<Course> courseLst = _courseRepository.GetAllCourses();
            return View("index", courseLst);
        }
    }
}

