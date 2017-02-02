using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleStudents.Data.Repositories;
using SimpleStudents.Domain;

namespace SimpleStuedents.Services
{
    public interface ITeachersCourseServices
    {
        void Update(int teacherId, IEnumerable<int> coursesIds);
    }
    public class TeacherCourseServices : ITeachersCourseServices
    {
        private ITeacherCourseRepository TeacherCourse { get; }

        public TeacherCourseServices(ITeacherCourseRepository teacherCourse)
        {
            TeacherCourse = teacherCourse;
        }

        public void Update(int teacherId, IEnumerable<int> coursesIds)
        {
            TeacherCourse.Delete(x => x.TeacherId == teacherId);
            foreach (var courseId in coursesIds)
            {
                TeacherCourse.Add(new TeacherCourse
                {
                    TeacherId = teacherId,
                    CourseId = courseId
                });
            }
        }
    }


}
