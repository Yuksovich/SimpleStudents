using System.ComponentModel.DataAnnotations;

namespace SimpleStudents.Web.Models
{
    public abstract class UserModel
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string FirstName { get; set; }
        [Required, MaxLength(255)]
        public string LastName { get; set; }
    }
}