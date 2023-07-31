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
        public void FindFilteredLimit()
        {
            var result = _person.Find(c => c.Age > 100).Limit(2).ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.FirstName}  {item.LastName}");
            }
        }
        public void FindPaged()
        {
            var result=_person.Find(FilterDefinition<Person>.Empty).Skip(10).Limit(2).ToList();
            foreach(var item in result)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }
    }
}
