using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Categorically.Data
{
    public class Transaction
    {
        [Key]
        public virtual int TransactionId { get; set; }

        [Required]
        public virtual DateTime TransactionDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public virtual decimal Amount { get; set; }

        public virtual string? ChargedByName { get; set; }

        public virtual string? Description { get; set; }

        public virtual int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        [ForeignKey("User")]
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
