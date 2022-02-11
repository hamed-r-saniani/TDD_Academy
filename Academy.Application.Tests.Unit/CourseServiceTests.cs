using Academy.Domain;
using Academy.Domain.Exceptions;
using Academy.Domain.Tests.Unit.Builders;
using FluentAssertions;
using NSubstitute;
using System;
using Xunit;
using Faker;
using Tynamix.ObjectFiller;
using NSubstitute.ReturnsExtensions;

namespace Academy.Application.Tests.Unit
{
    public class CourseServiceTests
    {
        private readonly CourseService _courseService;
        private readonly ICourseRepository _courseRepository;
        private readonly CourseTestBuilder _courseTestBuilder;

        public CourseServiceTests()
        {
            _courseRepository = Substitute.For<ICourseRepository>();
            //courseRepository.GetAll().Returns();
            _courseService = new CourseService(_courseRepository);
            _courseTestBuilder = new CourseTestBuilder();
        }

        [Fact]
        public void Should_CreateANewCourse()
        {
            //arrange
            CreateCourseViewModel command = SomeCreateCourse();

            //act
            _courseService.Create(command);

            //assert
            _courseRepository.Received(1).Create(Arg.Any<Course>()); // we must check that create in repository call or not because create method tests in past sessions so that work well and we just test that create method call or not
            //courseRepository.ReceivedWithAnyArgs().Create(default);
        }

        private static CreateCourseViewModel SomeCreateCourse()
        {
            //return new CreateCourseViewModel
            //{
            //    Id = Faker.RandomNumber.Next(1,44),
            //    Name = "Onion Architecture",
            //    IsOnline = true,
            //    Tuition = Faker.RandomNumber.Next(),
            //    //Instructor = "Hamed"
            //    Instructor = Faker.Name.FullName()
            //};

            //return new Filler<CreateCourseViewModel>().Create();

            //objectfiller.net -> site of this Package
            var filler = new Filler<CreateCourseViewModel>();
            //filler.Setup().OnProperty(z => z.Tuition).Use(4444);
            filler.Setup().OnProperty(z => z.Tuition).Use(Faker.RandomNumber.Next(1,4444));

            return filler.Create();
        }

        [Fact]
        public void Should_CreateNewCourseAndReturnId()
        {
            //arrange
            var command = SomeCreateCourse();

            //act
            var id = _courseService.Create(command);

            //assert
            id.Should().Be(command.Id);
        }

        [Fact]
        public void Should_ThrowException_WhenCourseAlreadyExisits()
        {
            //arrange
            var command = SomeCreateCourse();

            var course = _courseTestBuilder.Build();
            _courseRepository.GetBy(Arg.Any<string>()).Returns(course);
            //courseRepository.GetAll().Returns();

            //act
            Action actual = () => _courseService.Create(command);


            //assert
            actual.Should().Throw<DuplicatedCourseNameException>();
        }

        [Fact]
        public void Should_UpdateCourse()
        {
            //arrange
            var command = SomeEditCourse();
            var course = _courseTestBuilder.Build();
            _courseRepository.GetBy(command.Id).Returns(course);

            //act
            _courseService.Edit(command);

            //assert
            Received.InOrder(() =>    //Order is Important
            {
                _courseRepository.Received().Delete(command.Id);
                _courseRepository.Received().Create(Arg.Any<Course>());
            });
        }

        [Fact]
        public void Should_ThrowException_WhenUpdatingCourseNotExists()
        {
            EditCourseViewModel command = SomeEditCourse();
            _courseRepository.GetBy(command.Id).ReturnsNull();

            //act
            Action action = () => _courseService.Edit(command);


            //assert
            action.Should().ThrowExactly<CourseNotExistsException>();
        }

        private static EditCourseViewModel SomeEditCourse()
        {
            //arrange
            return new EditCourseViewModel
            {
                Id = Faker.RandomNumber.Next(1, 44),
                Name = Faker.Lorem.GetFirstWord(),
                IsOnline = true,
                Tuition = Faker.RandomNumber.Next(),
                Instructor = Faker.Name.FullName()
            };
        }
    }
}
