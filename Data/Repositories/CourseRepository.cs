using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Infrastructure;
using SimpleStudents;
using SimpleStudents.Domain;

namespace Data.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
       
    }

    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public override IEnumerable<Course> GetAll()
        {
            var context = Context as UniversityContext;
            context.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));


            return context?.Courses.Include(c => c.TeacherCourse).Include(i=>i.TeacherCourse.Select(s=>s.Teacher)).ToList();
        }
    }
}
