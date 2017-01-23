using System.ComponentModel.DataAnnotations;

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
