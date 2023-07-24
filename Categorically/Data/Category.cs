using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Categorically.Data;

public class Category
{
    [Key]
    public virtual int CategoryId { get; set; }
    public virtual string CategoryName { get; set; }

    [ForeignKey("User")]
    public virtual int UserId { get; set; }
    public virtual User User { get; set; }
}
