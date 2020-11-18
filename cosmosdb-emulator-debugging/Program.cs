using MongoDB.Driver;
using System;

namespace cosmosdb_emulator_debugging
{
    static class Program
    {
        // cmd to start the emulator: Microsoft.Azure.Cosmos.Emulator.exe /EnableMongoDbEndpoint=3.6
        static string CONNECTION_STRING = "mongodb://localhost:C2y6yDjf5%2FR%2Bob0N8A7Cgv30VRDJIWEHLM%2B4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw%2FJw%3D%3D@localhost:10255/admin?ssl=true";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var mongoClient = new MongoClient(CONNECTION_STRING);
            var database = mongoClient.GetDatabase("debugging");
            var collection = database.GetCollection<Dog>("dogs");

            collection.InsertOne(new Dog()  // should raise exception System.ArgumentException: 'localhost:' is not a valid end point. (Parameter 'value')
            {
                Name = "Beethoven"
            });

            Console.WriteLine("Succes !");
        }
    }
}
