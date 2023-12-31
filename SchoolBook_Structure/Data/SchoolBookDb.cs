﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolBook_Structure.Entities;

namespace SchoolBook_Structure.Data
{
    public class SchoolBookDb : IdentityDbContext<User>
    {
        public SchoolBookDb(DbContextOptions<SchoolBookDb> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Principal", NormalizedName = "PRINCIPAL".ToUpper() },
                new IdentityRole { Id = "2c93174e-3b0e-446f-86af-883d56fr7210", Name = "Teacher", NormalizedName = "TEACHER".ToUpper() },
                new IdentityRole { Id = "0ft3109e-3t4e-446f-46he-085116fr7450", Name = "Admin", NormalizedName = "ADMIN".ToUpper() },
                new IdentityRole { Id = "3j99004e-3b0e-446f-86af-073p96de6410", Name = "Parent", NormalizedName = "PARENT".ToUpper() });

            builder.Entity<ParentsStudents>()
                .HasKey(k => new { k.ParentId, k.StudentId });

            builder.Entity<TeacherStudent>()
                .HasKey(k => new { k.TeacherId, k.StudentId });

            builder.Entity<StudentExam>()
               .HasKey(k => new { k.ExamId, k.StudentId });

            base.OnModelCreating(builder);
        }

        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Parent> Parents { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<ParentsStudents> ParentsStudents { get; set; } = null!;
        public DbSet<TeacherStudent> TeacherStudents { get; set; } = null!;
        public DbSet<Exam> Exams { get; set; } = null!;
        public DbSet<StudentExam> StudentsExams { get; set; } = null!;

    }
}