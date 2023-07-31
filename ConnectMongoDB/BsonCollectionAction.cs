using MongoDB.Bson;
using MongoDB.Driver;

namespace ConnectMongoDB
{
    public class BsonCollectionAction
    {
        private readonly IMongoCollection<BsonDocument> _mongoCollection;
        public BsonCollectionAction(IMongoCollection<BsonDocument> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }
        public void InsertOne(string firstName, string lastName,  string[] tags, int age)
        {
            var document = new BsonDocument
            {
                {"firstname",BsonValue.Create(firstName) },
                {"lastName" ,new  BsonString(lastName) },
                {"subjects",new BsonArray(tags)},
                { "agr",age }

            };
            _mongoCollection.InsertOne(document);
        }

    }
}
