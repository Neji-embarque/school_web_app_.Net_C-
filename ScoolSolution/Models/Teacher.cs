﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoolSolution.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        [Required]
        public string TeacherName { get; set; }
        [Range(22, 70)]
        public int TeacherAge { get; set; }

    }
}
