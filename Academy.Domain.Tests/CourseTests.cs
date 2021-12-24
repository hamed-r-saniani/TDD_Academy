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
    }
}
