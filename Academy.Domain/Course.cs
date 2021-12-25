using System;

namespace Academy.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; internal set; }
        public bool IsOnline { get; internal set; }
        public double Tuition { get; internal set; }
        public Course(int id, string name, bool isOnline, double tuition)
        {
            CheckNameIsNull(name);
            CheckTuitionIsLessOrEqualZero(tuition);
            Id = id;
            Name = name;
            IsOnline = isOnline;
            Tuition = tuition;
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
