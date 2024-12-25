using ScoolSolution.Controllers;
using ScoolSolution.Models;

namespace ScoolSolution.Repository
{
    public interface ITeacherRepository
    {
        public List<Teacher> GetAllTeachers();
        public void Create(Teacher teacher);
        public void Delete(int id);
    }
}
