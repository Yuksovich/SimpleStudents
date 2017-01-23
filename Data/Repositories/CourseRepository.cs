using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using SimpleStudents.Domain;

namespace Data.Repositories
{
    public class CourseRepository:RepositoryBase<Course>
    {
        public CourseRepository(DbFactory dbFactory) : base(dbFactory) { }
    }
}
