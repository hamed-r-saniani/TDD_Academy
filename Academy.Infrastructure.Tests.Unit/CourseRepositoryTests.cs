using Academy.Domain.Tests.Unit.Builders;
using FluentAssertions;
using System;
using Xunit;

namespace Academy.Infrastructure.Tests.Unit
{
    public class CourseRepositoryTests
    {
        private readonly CourseRepository _courseRepository;
        private readonly CourseTestBuilder _courseTestBuilder;

        public CourseRepositoryTests()
        {
            _courseRepository = new CourseRepository();
            _courseTestBuilder = new CourseTestBuilder();
        }

        [Fact]
        public void Should_AddNewCourseToCoursesList()
        {
            //arrange
            var course = _courseTestBuilder.Build();

            //act
            _courseRepository.Create(course);

            //assert
            //repository.Courses.Should().ContainEquivalentOf(course); //Test Equal of MembersName of Two Object and Then MembersValues of Two Object // if two object come from different point this method is uses and we want check MembersValues of Two Object // run slowly
            _courseRepository.Courses.Should().Contain(course); //Can Override For Better Performance // Test Reference Of Two Object that Does not work in Database Repository but Work in Local DataStoring // Call Equal Method of Object

            // Speed Of Tests is Important to us
        }

        [Fact]
        public void Should_ReturnListOfCourses()
        {
            //arrange
            //var courseRepository = new CourseRepository();

            //act
            var courses = _courseRepository.GetAll();

            //assert
            courses.Should().HaveCountGreaterThanOrEqualTo(0);
        }

        [Fact]
        public void Should_ReturnCourseById()
        {
            //arrange
            const int id = 4;
            var expectedCourse = _courseTestBuilder.WithId(id).Build();
            _courseRepository.Create(expectedCourse);

            //act
            var actual = _courseRepository.GetBy(id);

            //assert
            actual.Should().Be(expectedCourse);
        }

        [Fact]
        public void Should_ReturnNull_WhenIdNotExists()
        {
            //arrange
            const int id = 300;

            //act
            var actual = _courseRepository.GetBy(id);

            //assert
            actual.Should().BeNull();
        }

        [Fact]
        public void Should_DeleteCourseFromCourses()
        {
            //arrange
            const int id = 44;
            var course = _courseTestBuilder.WithId(id).Build();
            _courseRepository.Create(course);

            //act
            _courseRepository.Delete(id);

            //assert
            _courseRepository.Courses.Should().NotContain(course);
        }

        [Fact]
        public void Should_ReturnCourseByName()
        {
            //arrange
            const string tdd = "TDD";
            var expectedCourse = _courseTestBuilder.WithName(tdd).Build();
            _courseRepository.Create(expectedCourse);

            //act
            var actual = _courseRepository.GetBy(tdd);

            //assert
            actual.Should().Be(expectedCourse);
            //actual.Name.Should().Be(tdd); //This is Ok Too
        }

        [Fact]
        public void Should_ReturnNull_WhenNameNotExists()
        {
            //arrange
            const string bdd = "BDD";

            //act
            var actual = _courseRepository.GetBy(bdd);

            //assert
            actual.Should().BeNull();
        }
    }
}
