namespace AngularWebApiApp.Data
{
    using AngularWebApiApp.Domain;
    using AngularWebApiApp.Domain.Entities;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Conventions;
    using MongoDB.Driver;
    using System.Configuration;

    public class MongoContext : IMongoContext
    {
        private readonly MongoCollection<User> userCollection;
        private readonly MongoCollection<Role> roleCollection;
        private readonly MongoCollection<Client> clientCollection;
        private readonly MongoCollection<RefreshToken> refreshTokenCollection;
        private readonly MongoCollection<Proj> projectsCollection;

        public MongoContext()
        {
            var pack = new ConventionPack()
            {
                new CamelCaseElementNameConvention(),
                new EnumRepresentationConvention(BsonType.String)
            };

            ConventionRegistry.Register("CamelCaseConvensions", pack, t => true);
            EnvironmentConfigSection configSection = ConfigurationManager.GetSection("EnvironmentConfig") as EnvironmentConfigSection;

            var mongoUrlBuilder = new MongoUrlBuilder(configSection.ConnectionString.Value);

            var mongoClient = new MongoClient(mongoUrlBuilder.ToMongoUrl());
            var server = mongoClient.GetServer();

            Database = server.GetDatabase(mongoUrlBuilder.DatabaseName);

            userCollection = Database.GetCollection<User>("users");
            roleCollection = Database.GetCollection<Role>("roles");
            clientCollection = Database.GetCollection<Client>("clients");
            refreshTokenCollection = Database.GetCollection<RefreshToken>("refreshTokens");
            projectsCollection = Database.GetCollection<Proj>("Projects");
        }

        public MongoDatabase Database { get; private set; }

        public MongoCollection<User> Users
        {
            get { return userCollection; }
        }

        public MongoCollection<Role> Roles
        {
            get { return roleCollection; }
        }

        public MongoCollection<Client> Clients
        {
            get { return clientCollection; }
        }

        public MongoCollection<RefreshToken> RefreshTokens
        {
            get { return refreshTokenCollection; }
        }


        public MongoCollection<Proj> Projects
        {
            get { return projectsCollection; }
        }

    }
}
