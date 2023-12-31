﻿using ConnectMongoDB;
using ConnectMongoDB.Entites;
using MongoDB.Bson;
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
        //PersonInsert(personCollection);
        //BsonInsert(bsonCollection);
        //personAction.InsertOne(peroson);
        BsonInsertMany(bsonCollection);
        //BsonFindAll(bsonCollection);
        //FindFilter(bsonCollection, 65);
        Console.ReadLine();
    }

    private static void FindFilter(IMongoCollection<BsonDocument> bsonCollection,int age)
    {
        var bsonCollectionAction = new BsonCollectionAction(bsonCollection);
        bsonCollectionAction.FindFiltered(age);
    }

    private static void BsonFindAll(IMongoCollection<BsonDocument> bsonCollection)
    {
        var bsonCollectionAction = new BsonCollectionAction(bsonCollection);
        bsonCollectionAction.FindAll();
    }

    private static void BsonInsertMany(IMongoCollection<BsonDocument> bsonCollection)
    {
        var bsonCollectionAction = new BsonCollectionAction(bsonCollection);
        bsonCollectionAction.InsertMany("Nika", "shahKarami", new string[] { "Group01", "Group02" }, 18);
    }

    private static void BsonInsert(IMongoCollection<BsonDocument> bsonCollection)
    {
        var bsonCollectionAction = new BsonCollectionAction(bsonCollection);
        bsonCollectionAction.InsertOne("Nika", "shahKarami", new string[] { "Group01", "Group02" }, 18);
    }

    private static void PersonInsert(IMongoCollection<Person> personCollection)
    {
        var personAction = new PersonCollectionAction(personCollection);
        var peroson = new Person
        {
            FirstName = "navid",
            LastName = "afcari",
            Age = 22,
            Tags = new string[] { "Group01", "Group02" }
        };
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

