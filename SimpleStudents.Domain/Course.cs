using System.Collections.Generic;

namespace SimpleStudents.Domain
{
    public class Course : EntityBase
    {
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public IList<Description> Descriptions { get; set; }
    }
}