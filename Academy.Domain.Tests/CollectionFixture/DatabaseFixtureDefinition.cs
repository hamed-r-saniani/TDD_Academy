using Xunit;

namespace Academy.Domain.Tests.Unit.CollectionFixture
{
    //There is an intermediate class
    [CollectionDefinition("Database Collection")] //Name of our Collection
    public class DatabaseFixtureDefinition : ICollectionFixture<DatabaseFixture>
    {
        // all class that will DatabaseFixture class happen for that, will subset [CollectionDefinition("Database Collection")] 
        // with ICollectionFixture we can group many classes and use a Fixture - For Example we have many class that test Course for default a database 10 Course define in it and 5 section define in it and we have 3 user that will do something different things for example one finish course and another want register and ... we supply first seed data with this way and Dispose it


        /*
         example that we use this is we have some classes that work with course and the base need is There is a database and five course create in it and ten section too and three user that do something for example one of them complete course or one of them in the course and... that first data is provided from this and then dispose that 
         */
    }
}
