using Xunit;

namespace Academy.Domain.Tests.CollectionFixture
{
    [CollectionDefinition("Database Collection")]
    public class DatabaseFixtureDefinition : ICollectionFixture<DatabaseFixture>
    {
        // all class that will DatabaseFixture class happen for that, will subset [CollectionDefinition("Database Collection")]
        // with ICollectionFixture we can group many classes and use a Fixture - For Example we have many class that test Course for default a database 10 Course define in it and 5 section define in it and we have 3 user that will do something different things for example one finish course and another want register and ... we supply first seed data with this way and Dispose it
    }
}
