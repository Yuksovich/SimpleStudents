using System.Collections.Generic;

namespace SimpleStudents.Models
{
    public abstract class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<int> CourseId { get; set; }
        public IDictionary<CourseModel, int> CoursesWithMarks { get; set; }
    }
}