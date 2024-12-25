using ScoolSolution.Controllers;
using ScoolSolution.Models;

namespace ScoolSolution.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        public void Create(Student student);
        public void Delete(int id);
        public void Register(int studentid, int courseid);
        //public Student Update(Student student);
    }
}
