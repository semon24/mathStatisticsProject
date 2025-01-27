﻿namespace MathStatisticsProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }

        public string Group { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}
