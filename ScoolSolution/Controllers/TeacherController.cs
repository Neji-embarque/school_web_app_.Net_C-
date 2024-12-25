using Microsoft.AspNetCore.Mvc;
using ScoolSolution.Models;
using ScoolSolution.Repository;

namespace ScoolSolution.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        //list of Teachers
        [HttpGet]
        public ActionResult Index()
        {
            List<Teacher> teacherLst = _teacherRepository.GetAllTeachers();
            return View(teacherLst);
        }
        //render the creation view
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            if (teacher != null)
            {
                _teacherRepository.Create(teacher);
            }
            List<Teacher> teacherLst = _teacherRepository.GetAllTeachers();
            return View("Index", teacherLst);
        }
        public ViewResult Delete(int id)
        {
            if (id > 0)
            {
                _teacherRepository.Delete(id);
            }
            List<Teacher> teacherLst = _teacherRepository.GetAllTeachers();
            return View("Index", teacherLst);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
    }
}
