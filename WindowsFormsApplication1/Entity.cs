using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStudents.Domain
{
    public interface IEntity
    {
       int Id { get; set; }
    }

    public class EntityBase : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
