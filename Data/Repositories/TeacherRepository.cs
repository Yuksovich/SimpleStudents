﻿using System.Data.Entity;
using System.Linq;
using Data.Infrastructure;
using SimpleStudents.Domain;

namespace Data.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
    }

    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        private readonly UniversityContext _context;

        public TeacherRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            _context = Context as UniversityContext;
        }

        public override IQueryable<Teacher> GetAll()
        {
            return
                _context?.Teachers.Include(c => c.TeacherCourses);
        }
    }
}