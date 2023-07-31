using ConnectMongoDB.Entites;
using MongoDB.Driver;

namespace ConnectMongoDB
{
    public class PersonCollectionAction
    {
        private readonly IMongoCollection<Person> _person;
        public PersonCollectionAction(IMongoCollection<Person> mongoCollection)
        {
            _person = mongoCollection;
        }
        public void InsertOne(Person person)
        {
            _person.InsertOne(person);
        }
    }
}
