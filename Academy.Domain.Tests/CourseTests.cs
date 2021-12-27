using FluentAssertions;
using System;
using Xunit;

namespace Academy.Domain.Tests
{
    public class CourseTests
    {
        CourseTestBuilder courseBuilder = new CourseTestBuilder();
        private const int id = 1;
        private const string name = "Tdd & Bdd";
        private const bool isOnline = true;
        private const double tuition = 4000;
        private const string instructor = "Hamed";
        [Fact]
        public void Constructor_ShouldConstructCourseProperly()
        {  
            var course = courseBuilder.Build(); 

            //Assert.Equal(id, course.Id);
            //Assert.Equal(name, course.Name);
            //Assert.Equal(isOnline, course.IsOnline);
            //Assert.Equal(tuition, course.Tuition);

            course.Id.Should().Be(id);
            course.Name.Should().Be(name);
            course.IsOnline.Should().Be(isOnline);
            course.Tuition.Should().Be(tuition);
            course.Instructor.Should().Be(instructor);
        }
        [Fact]
        public void Constructor_ShouldThrowException_When_NameIsNotProvided()
        {
            //Action course = () => new Course(id, name, isOnline, tuition);
            //void course() => new Course(id, name, isOnline, tuition);

            // You Can Do this Too
            //Action course = () => courseBuilder.WithName("").WithId(1).Withtuition(1451).Build();

            Action course = () => courseBuilder.WithName("").Build();

            //Assert.Throws<Exception>((Action) course);

            //course.Should().ThrowExactly<CourseNameIsInvalidException>().WithMessage();
            course.Should().ThrowExactly<CourseNameIsInvalidException>();
        }
        [Fact]
        public void Constructor_ShouldThrowException_When_TuitionIsNotProvided()
        {
            //Action course = () => new Course(id, name, isOnline, tuition);
            //void course() => new Course(id, name, isOnline, tuition);

            Action course = () => courseBuilder.Withtuition(0).Build();
            Action course2 = () => courseBuilder.Withtuition(-1).Build();

            //Assert.Throws<ArgumentOutOfRangeException>(course);
            //Assert.Throws<ArgumentOutOfRangeException>(course2);

            course.Should().Throw<ArgumentOutOfRangeException>();
            course2.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
