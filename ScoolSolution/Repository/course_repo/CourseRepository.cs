using ScoolSolution.Contest;
using ScoolSolution.Models;

namespace ScoolSolution.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly MyDbContext _myDbConnection;
        public CourseRepository(MyDbContext myDbConnection)
        {
            _myDbConnection = myDbConnection;
        }
        public List<Course> GetAllCourses()
        {
            try
            {
                List<Course> courses = (from CoursesObj in _myDbConnection.Courses
                                        select CoursesObj).ToList();
                return courses;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public void Create(Course course)
        {
            _myDbConnection.Courses.Add(course);
            _myDbConnection.SaveChanges();
        }
        public void Delete(int id)
        {
            Course course = (from CourseObj in _myDbConnection.Courses
                             where CourseObj.CourseId == id
                         select CourseObj).FirstOrDefault();
            _myDbConnection.Courses.Remove(course);
            _myDbConnection.SaveChanges();

        }
    }
}

