using System.ComponentModel.DataAnnotations;

namespace SimpleStudents.Web.Models
{
    public abstract class UserModel
    {
        public int Id { get; set; }

        [Required, MaxLength(255), Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required, MaxLength(255), Display(Name = "Last name")]
        public string LastName { get; set; }
    }
}