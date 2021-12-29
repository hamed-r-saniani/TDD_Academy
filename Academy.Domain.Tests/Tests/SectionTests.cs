using FluentAssertions;
using Xunit;

namespace Academy.Domain.Tests
{
    public class SectionTests
    {
        [Fact]
        public void Constructor_ShouldConstructCourseProperly()
        {
            //Arrange (Ready SUT For Test) -> Setup

            const int id = 1;
            const string name = "TDD Section";

            //Act (Execute SUT) -> Exercise

            var section = new Section(id,name);

            //Assert (Verify(Test) SUT) -> Verify

            section.Id.Should().Be(id);
            section.Name.Should().Be(name);


            //TearDown (Dispose things that we create in Arrange)(we dont have it in UnitTest)(Because in UnitTest all things do in Memory and GC Clean it Automatically)
        }
    }
}
