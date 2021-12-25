using System;
using Xunit;

namespace Academy.Domain.Tests
{
    public class CourseTests
    {
        [Fact]
        public void Constructor_ShouldConstructCourseProperly()
        {
            const int id = 1;
            const string name = "Tdd & Bdd";
            const bool isOnline = true;
            const double tuition = 4000;

            var course = new Course(id, name, isOnline, tuition);

            Assert.Equal(id, course.Id);
            Assert.Equal(name, course.Name);
            Assert.Equal(isOnline, course.IsOnline);
            Assert.Equal(tuition, course.Tuition);
        }
        [Fact]
        public void Constructor_ShouldThrowException_When_NameIsNotProvided()
        {
            const int id = 1;
            const string name = "";
            const bool isOnline = true;
            const double tuition = 4000;

            //Action course = () => new Course(id, name, isOnline, tuition);
            void course() => new Course(id, name, isOnline, tuition);

            Assert.Throws<Exception>((Action) course);
        }
        [Fact]
        public void Constructor_ShouldThrowException_When_TuitionIsNotProvided()
        {
            const int id = 1;
            const string name = "Tdd & Bdd";
            const bool isOnline = true;
            double tuition = 0;

            Action course = () => new Course(id, name, isOnline, tuition);
            //void course() => new Course(id, name, isOnline, tuition);

            tuition = -1;

            Action course2 = () => new Course(id, name, isOnline, tuition);

            Assert.Throws<ArgumentOutOfRangeException>(course);
            Assert.Throws<ArgumentOutOfRangeException>(course2);
        }
    }
}
