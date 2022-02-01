using Academy.Domain;
using Academy.Domain.Tests.Unit.Builders;
using FluentAssertions;
using NSubstitute;
using System;
using Xunit;

namespace Academy.Application.Tests.Unit
{
    public class CourseServiceTests
    {
        [Fact]
        public void Should_CreateANewCourse()
        {
            //arrange
            var command = new CreateCourseViewModel
            {
                Id = 4,
                Name = "Onion Architecture",
                IsOnline = true,
                Tuition = 4444,
                Instructor = "Hamed"
            };

            var courseRepository = Substitute.For<ICourseRepository>();
            //courseRepository.GetAll().Returns();
            var courseService = new CourseService(courseRepository);

            //act
            courseService.Create(command);

            //assert
            courseRepository.Received(1).Create(Arg.Any<Course>()); // we must check that create in repository call or not because create method tests in past sessions so that work well and we just test that create method call or not
            //courseRepository.ReceivedWithAnyArgs().Create(default);
        }

        [Fact]
        public void Should_CreateNewCourseAndReturnId()
        {
            //arrange
            var command = new CreateCourseViewModel
            {
                Id = 4,
                Name = "Onion Architecture",
                IsOnline = true,
                Tuition = 4444,
                Instructor = "Hamed"
            };

            var courseRepository = Substitute.For<ICourseRepository>();
            //courseRepository.GetAll().Returns();
            var courseService = new CourseService(courseRepository);

            //act
            var id = courseService.Create(command);

            //assert
            id.Should().Be(command.Id);
        }

        [Fact]
        public void Should_ThrowException_WhenCourseAlreadyExisits()
        {
            //arrange
            var command = new CreateCourseViewModel
            {
                Id = 4,
                Name = "Onion Architecture",
                IsOnline = true,
                Tuition = 4444,
                Instructor = "Hamed"
            };

            var courseRepository = Substitute.For<ICourseRepository>();
            var course = new CourseTestBuilder().Build();
            courseRepository.GetBy(Arg.Any<string>()).Returns(course);
            //courseRepository.GetAll().Returns();
            var courseService = new CourseService(courseRepository);

            //act
            Action actual = () => courseService.Create(command);


            //assert
            actual.Should().Throw<Exception>();
        }
    }
}
