using Academy.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace Academy.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; internal set; }
        public bool IsOnline { get; internal set; }
        public double Tuition { get; internal set; }
        public string Instructor { get; set; }
        public List<Section> Sections { get; set; }
        public Course(int id, string name, bool isOnline, double tuition,string instructor)
        {
            CheckNameIsNull(name);
            CheckTuitionIsLessOrEqualZero(tuition);
            Id = id;
            Name = name;
            IsOnline = isOnline;
            Tuition = tuition;
            Instructor = instructor;
            Sections = new List<Section>();
        }

        private static void CheckTuitionIsLessOrEqualZero(double tuition)
        {
            if (tuition <= 0)
                throw new ArgumentOutOfRangeException();
        }

        private static void CheckNameIsNull(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new CourseNameIsInvalidException();
        }

        public void AddSection(Section section)
        {
            this.Sections.Add(section);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Course course)
                return false;

            return Id == course.Id;
        }
    }
}
