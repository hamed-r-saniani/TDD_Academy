using System;

namespace Academy.Domain.Tests.CollectionFixture
{
    public class DatabaseFixture : IDisposable
    {
        public Guid FakeConnectionString { get; set; }
        public DatabaseFixture() // run before many test classes - same between group test classes
        {
            FakeConnectionString = Guid.NewGuid();
        }
        public void Dispose() // run after many test classes
        {
            FakeConnectionString = Guid.Empty;
        }
    }
}
