using Academy.Domain.Exceptions;
using Academy.Domain.Tests.Unit.Builders;
using Academy.Domain.Tests.Unit.ClassFixtures;
using Academy.Domain.Tests.Unit.CollectionFixture;
using Academy.Domain.Tests.Unit.Factories;
using FluentAssertions;
using System;
using Xunit;

namespace Academy.Domain.Tests.Unit.Tests
{
    [Collection("Database Collection")] // Attribute for XUnit
    public class CourseTests : IClassFixture<IdentifierFixture> // this interface for XUnit Framework //IdentifierFixture call before this test class //if we want use data of IdentifierFixture we must inject it in constructor (another way is static field or property in IdentifierFixture class and without inject in this class use it with name of IdentifierFixture class)
    {
        private readonly CourseTestBuilder courseBuilder;
        public CourseTests(DatabaseFixture databaseFixture) // this constructor run befor run any Fact // when code Achieve here get us DatabaseFixture class
        {
            // we can have Fresh Fixture here
            courseBuilder = new CourseTestBuilder();// Fresh Transient Fixture // Implicit(with a Hook of XUnit create Implicit Setup Fixture) // You Can Serach "XUnit Hooks" in Google for more information
        }
        private const int id = 1;
        private const string name = "Tdd & Bdd";
        private const bool isOnline = true;
        private const double tuition = 4000;
        private const string instructor = "Hamed";
        [Fact]
        public void Constructor_ShouldConstructCourseProperly()
        {
            var guid = IdentifierFixture.Id;

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
            course.Sections.Should().BeEmpty();
        }
        [Fact]
        public void Constructor_ShouldThrowException_When_NameIsNotProvided()
        {
            var guid = IdentifierFixture.Id;

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

        [Fact]
        public void AddSection_ShouldAddNewSectionToSections_WhenIdAndNamePassed()
        {
            //Arrange

            var courseBuilder = new CourseTestBuilder();
            var course = courseBuilder.Build();
            var section = SectionFactory.Create();

            //Act
            course.AddSection(section);


            //Assert

            course.Sections.Should().ContainEquivalentOf(section);
        }

        //public void Dispose() // this run after any Fact //must inheritance from IDisposable
        //{
        //    // we can write TearDown Code Here (but not nessery in unit tests)
        //}

        [Fact]
        public void Should_BeEqual_WhenIdIsTheSame()
        {
            //arrange
            const int sameId = 4;
            var courseBuilder = new CourseTestBuilder();
            var course1 = courseBuilder.WithId(sameId).Build();
            var course2 = courseBuilder.WithId(sameId).Build();

            //act
            var actual = course1.Equals(course2);

            //assert
            actual.Should().BeTrue();
            //course1.Should().Be(course2);
        }

        [Fact]
        public void Should_NotBeEqual_WhenIdIsNotTheSame()
        {
            //arrange
            const int sameId = 4;
            var courseBuilder = new CourseTestBuilder();
            var course1 = courseBuilder.WithId(sameId).Build();
            var course2 = courseBuilder.WithId(sameId+4).Build();

            //act
            var actual = course1.Equals(course2);

            //assert
            actual.Should().BeFalse();
            //course1.Should().NotBe(course2);
        }

        [Fact]
        public void Should_NotBeEqual_WhenSecondObjectIsNull()
        {
            //arrange
            var courseBuilder = new CourseTestBuilder();
            var course = courseBuilder.Build();

            //act
            var actual = course.Equals(null);

            //assert
            actual.Should().BeFalse();
        }
    }
}
