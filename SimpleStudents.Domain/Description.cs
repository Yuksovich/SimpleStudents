using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStudents.Domain
{
    public class Description : EntityBase
    {
        public int Mark { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}