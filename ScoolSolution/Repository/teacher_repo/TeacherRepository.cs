using ScoolSolution.Contest;
using ScoolSolution.Models;

namespace ScoolSolution.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MyDbContext _myDbConnection;
        public TeacherRepository(MyDbContext myDbConnection)
        {
            _myDbConnection = myDbConnection;
        }
        public List<Teacher> GetAllTeachers()
        {
            try
            {
                List<Teacher> teachers = (from TeachersObj in _myDbConnection.Teachers
                                          select TeachersObj).ToList();
                return teachers;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public void Create(Teacher teacher)
        {

            /* ...... methode 1......................*/
            /* ......................................../
                 Student std = new Student();
                 std.IsActive = true;  
                 std.StudentName = 'neji';
                _myDbConnection.Students.Add(std);
            /.......................................*/

            /*..........methede 2 ..................*/
            _myDbConnection.Teachers.Add(teacher);
            /*......................................*/

            _myDbConnection.SaveChanges();
        }
        public void Delete(int id)
        {
            Teacher teacher = (from TeacherObj in _myDbConnection.Teachers
                               where TeacherObj.TeacherId == id
                               select TeacherObj).FirstOrDefault();
            _myDbConnection.Teachers.Remove(teacher);
            _myDbConnection.SaveChanges();

        }
    }
}
