using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Data.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }
        [NotNull]
        public string Surename { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public string Email { get; set; }
        [NotNull]
        public string Password { get; set; }
    }
}