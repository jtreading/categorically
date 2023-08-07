using System.ComponentModel.DataAnnotations;

namespace Categorically.Services.Models;

public class User
{
    [Key]
    public virtual int UserId { get; set; }
    public virtual string UserName { get; set; }
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string Email { get; set; }
}