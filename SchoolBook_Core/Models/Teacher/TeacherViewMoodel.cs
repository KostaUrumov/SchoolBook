﻿namespace SchoolBook_Core.Models.Teacher
{
    public class TeacherViewMoodel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Discipline { get; set; } = null!;

        public bool IsPrincipal { get; set; }

        public string Id { get; set; } = null!;
    }
}
