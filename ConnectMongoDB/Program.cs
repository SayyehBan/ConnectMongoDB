using ConnectMongoDB;
using ConnectMongoDB.Entites;
using MongoDB.Driver;

class Program
{
    static void Main(string[] args)
    {
        /*

          در این بخش، یک نمونه از کلاس MongoClientFactory ایجاد می‌شود. این کلاس احتمالاً یک کلاس کمکی است که برای تولید نمونه‌های MongoClient با تنظیمات مخصوص مورد استفاده قرار می‌گیرد.
         */
        var mongoClient = new MongoClientFactory().GetDefaultConstractor();
        var database = new MongoClientAction(mongoClient).GetDatabase("TestDB");
        //new MongoDataBaseAction(database).CreateCollection("testCollection");
        //GetColectionNames(database);
        var bsonCollection = new MongoDataBaseAction(database).GetCollection("BsonCollection");
        var personCollection = new MongoDataBaseAction(database).GetPersonCollection("people");
        //Person Action
        var personAction = new PersonCollectionAction(personCollection);
        var peroson = new Person
        {
            FirstName = "navid",
            LastName = "afcari",
            Age = 22,
            Tags = new string[] {"Group01","Group02"}
        };
        personAction.InsertOne(peroson);
        Console.ReadLine();
    }

    private static void GetColectionNames(IMongoDatabase database)
    {
        var collectionList = new MongoDataBaseAction(database).CollectionList();
        Console.WriteLine(collectionList);
    }

    private static void DataBaseList(MongoClient mongoClient)
    {
        /*
   در این بخش، متد GetDefaultConstractor() روی نمونه ایجاد شده از MongoClientFactory فراخوانی می‌شود. این متد احتمالاً تنظیمات مربوط به اتصال به پایگاه داده را از MongoClientFactory دریافت کرده و با استفاده از آنها، یک نمونه از کلاس MongoClient را با تنظیمات پیش فرض ایجاد می‌کند. نمونه ایجاد شده، سپس در متغیر mongoClient ذخیره می‌شود.

با استفاده از این کد، یک نمونه از کلاس MongoClient با تنظیمات پیش فرض (یا تنظیماتی که در کلاس MongoClientFactory تعریف شده اند) ایجاد می‌شود. می‌توانید این نمونه را برای برقراری اتصال به پایگاه داده MongoDB و انجام عملیات مربوطه استفاده کنید.
 */

        var databaseList = new MongoClientAction(mongoClient).DatabaseList();

        Console.WriteLine(databaseList);
    }
}

