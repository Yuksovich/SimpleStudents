﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using SimpleStudents.Domain;

namespace Data.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
    }

    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(DbContext dbContext) : base(dbContext) { }
    }
}
