using MongoDB.Driver;
using Integrador.Models;

namespace Integrador.Models
{
    public class ContextMongoDB
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }

        private IMongoDatabase _database { get; set; }

        public ContextMongoDB()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.
                    FromUrl(new MongoUrl(ConnectionString));

                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings
                    {
                        EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                    };
                }

                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception)
            {

                throw new Exception("It was not possible to connect");
            }
        }

        //public IMongoCollection<User> User
        //{
        //    get
        //    {
        //        return _database.GetCollection<User>("users");
        //    }
        //}
        public IMongoCollection<User> User => _database.GetCollection<User>("users");
        public IMongoCollection<Service> ServiceSubmit => _database.GetCollection<Service>("ServicesCo");
        //update a user
        public void UpdateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq("Id", user.Id);
            var update = Builders<User>.Update
                .Set("firstname", user.FirstName)
                .Set("lastname", user.LastName)
                .Set("email", user.Email)
                .Set("username", user.UserName)
                .Set("password", user.Password);
            _database.GetCollection<User>("users").UpdateOne(filter, update);






        }
    }
}
