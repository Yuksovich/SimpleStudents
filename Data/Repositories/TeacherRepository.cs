using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using SimpleStudents.Domain;

namespace Data.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {

    }

    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(DbContext dbContext) : base(dbContext) { }
    }
}
