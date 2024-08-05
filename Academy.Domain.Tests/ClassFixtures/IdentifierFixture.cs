using System;

namespace Academy.Domain.Tests.Unit.ClassFixtures
{
    public class IdentifierFixture : IDisposable // Persistant Shared Fixture
    {
        /* examples of fixtures that we can create:
         -connection to database
         -create user in database
         -create a new database(sandbox database) for tests only
         -call a api for Prerequisite preparation
         */
        public static Guid Id { get; set; }
        public IdentifierFixture() // Call Before Test Class
        {
            Id = Guid.NewGuid();
        }
        public void Dispose() // Call After Test Class // if test run in parallel if we use Id in another class this method call after that call
        {
            Id = Guid.Empty;
        }
    }
}
