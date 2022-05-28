using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace LFC.DAL.Models
{
    public enum UserRole
    {
        Student,
        Teacher
    }

    public class User : IdentityUser
    {
        [Required]
        public UserRole UserRole { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        
        public virtual Student Student { get; set; }
        
        public virtual Teacher Teacher { get; set; }
    }
}