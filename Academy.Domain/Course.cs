using System;

namespace Academy.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; internal set; }
        public bool IsOnline { get; internal set; }
        public double Tuition { get; internal set; }
        public string Instructor { get; set; }
        public Course(int id, string name, bool isOnline, double tuition,string instructor)
        {
            CheckNameIsNull(name);
            CheckTuitionIsLessOrEqualZero(tuition);
            Id = id;
            Name = name;
            IsOnline = isOnline;
            Tuition = tuition;
            Instructor = instructor;
        }

        private static void CheckTuitionIsLessOrEqualZero(double tuition)
        {
            if (tuition <= 0)
                throw new ArgumentOutOfRangeException();
        }

        private static void CheckNameIsNull(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception();
        }
    }
}
