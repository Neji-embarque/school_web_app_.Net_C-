using ScoolSolution.Contest;
using ScoolSolution.Models;

namespace ScoolSolution.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyDbContext _myDbConnection;
        public StudentRepository(MyDbContext myDbConnection)
        {
            _myDbConnection = myDbConnection;
        }
        public List<Student> GetAllStudents()
        {
            try
            {
                List<Student> students = (from StudentsObj in _myDbConnection.Students
                                          select StudentsObj).ToList();
                return students;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void Create(Student student)
        {

            /* ...... methode 1......................*/
            /* ......................................../
                 Student std = new Student();
                 std.IsActive = true;  
                 std.StudentName = 'neji';
                _myDbConnection.Students.Add(std);
            /.......................................*/

            /*..........methede 2 ..................*/
            _myDbConnection.Students.Add(student);
            /*......................................*/

            _myDbConnection.SaveChanges();
        }
        public void Delete(int id)
        {
            Student student = (from StudentObj in _myDbConnection.Students
                               where StudentObj.StudentId == id
                               select StudentObj).FirstOrDefault();
            //var student = _myDbConnection.Students.Select(s => s.StudentId == id).FirstOrDefault();
            //_myDbConnection.Students.Remove(student);
            //_myDbConnection.SaveChanges();

        }
        public void Register(int studentid, int courseid)
        {
            /* ...... methode 1......................*/
            /*......................................./
            StudentCourse obj = new StudentCourse();
            obj.StudentId = studentid;  
            obj.CourseId = courseid;
            _myDbConnection.StudentCourses.Add(obj);
            /.......................................*/

            /*..........methede 2 ..................*/
            _myDbConnection.StudentCourses.Add(new StudentCourse
            {
                CourseId = courseid,
                StudentId = studentid
            });
            /*......................................*/

            _myDbConnection.SaveChanges();

        }
    }
}
