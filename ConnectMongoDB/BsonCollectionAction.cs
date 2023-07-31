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
        public void InsertOne(string firstName, string lastName, string[] tags, int age)
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
        public void InsertMany(string firstName, string lastName, string[] tags, int age)
        {
            List<BsonDocument> list = new List<BsonDocument>();
            for (int i = 0; i < 100; i++)
            {
                var document = new BsonDocument
            {
                {"firstname",BsonValue.Create(firstName+i) },
                {"lastName" ,new  BsonString(lastName+i) },
                {"subjects",new BsonArray(tags)},
                { "age",age+i }

            };
                list.Add(document);
            }

            _mongoCollection.InsertMany(list);
        }
        public void FindAll()
        {
            FilterDefinition<BsonDocument> filter = FilterDefinition<BsonDocument>.Empty;
            FindOptions<BsonDocument> options = new FindOptions<BsonDocument>
            {
                BatchSize = 2,
                NoCursorTimeout = false
            };
            using (IAsyncCursor<BsonDocument> cursor = _mongoCollection.FindAsync(filter, options).Result)
            {
                while (cursor.MoveNext())
                {
                    IEnumerable<BsonDocument> batch = cursor.Current;
                    foreach (BsonDocument doc in batch)
                    {
                        Console.WriteLine(doc);
                    }
                }
                Console.WriteLine("--------------------------");
            }
        }
        public void FindFiltered(int age)
        {
            FilterDefinition<BsonDocument> filter = new FilterDefinitionBuilder<BsonDocument>().Eq("agr", age);
            FindOptions<BsonDocument> options = new FindOptions<BsonDocument>
            {
                BatchSize = 2,
                NoCursorTimeout = false
            };
            using (IAsyncCursor<BsonDocument> cursor = _mongoCollection.FindAsync(filter, options).Result)
            {
                while (cursor.MoveNext())
                {
                    IEnumerable<BsonDocument> batch = cursor.Current;
                    foreach (BsonDocument doc in batch)
                    {
                        Console.WriteLine(doc);
                    }
                }
                Console.WriteLine("--------------------------");
            }
        }
        public void FindFilteredLimit()
        {
            //var result=_mongoCollection.Find(c=>c.agr>100)
        }
    }
}
