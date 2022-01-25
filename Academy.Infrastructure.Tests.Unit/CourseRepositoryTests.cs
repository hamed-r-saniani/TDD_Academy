using Academy.Domain.Tests.Unit.Builders;
using FluentAssertions;
using System;
using Xunit;

namespace Academy.Infrastructure.Tests.Unit
{
    public class CourseRepositoryTests
    {
        [Fact]
        public void Should_AddNewCourseToCoursesList()
        {
            //arrange
            var courseBuilder = new CourseTestBuilder();
            var course = courseBuilder.Build();
            var repository = new CourseRepository();

            //act
            repository.Create(course);

            //assert
            //repository.Courses.Should().ContainEquivalentOf(course); //Test Equal of MembersName of Two Object and Then MembersValues of Two Object // if two object come from different point this method is uses and we want check MembersValues of Two Object
            repository.Courses.Should().Contain(course); //Can Override For Better Performance // Test Reference Of Two Object that Does not work in Database Repository but Work in Local DataStoring // Call Equal Method of Object

            // Speed Of Tests is Important to us
        }
    }
}
