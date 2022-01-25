using System;

namespace Academy.Domain.Tests.Unit.ClassFixtures
{
    public class IdentifierFixture : IDisposable // Persistant Shared Fixture
    {
        public static Guid Id { get; set; }
        public IdentifierFixture() // Call Before Test Class
        {
            Id = Guid.NewGuid();
        }
        public void Dispose() // Call After Test Class
        {
            Id = Guid.Empty;
        }
    }
}
