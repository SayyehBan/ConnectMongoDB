using ConnectMongoDB.Entites;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConnectMongoDB
{
    public class MongoDataBaseAction
    {
        /*
         1. private readonly IMongoDatabase _MongoDatabase;:
   در این بخش، یک متغیر خصوصی با نام _MongoDatabase از نوع IMongoDatabase تعریف شده است. این متغیر برای نگهداری نمونه‌ای از پایگاه داده MongoDB استفاده می‌شود.

2. public MongoDataBaseAction(IMongoDatabase mongoDatabase):
   این کلاس سازنده ایجاد کننده‌ای دارد که یک ورودی از نوع IMongoDatabase به نام mongoDatabase دریافت می‌کند. عملکرد این سازنده نیاز به یک نمونه از پایگاه داده MongoDB دارد.

3. _MongoDatabase = mongoDatabase;:
   در بدنه سازنده، مقدار mongoDatabase که یک نمونه از پایگاه داده MongoDB است، به متغیر _MongoDatabase اختصاص داده می‌شود. این کار به معنی تنظیم نمونه در داخل کلاس MongoDataBaseAction است تا بتوانیم از آن برای انجام عملیات مختلف بر روی پایگاه داده MongoDB استفاده کنیم.

با استفاده از این کد، می‌توانید کلاس MongoDataBaseAction را برای انجام عملیات مربوط به پایگاه داده MongoDB استفاده کنید. با دریافت یک نمونه از پایگاه داده MongoDB به عنوان ورودی سازنده، شما می‌توانید از آن برای انجام عملیات مختلفی مانند خواندن، نوشتن و حذف داده‌ها استفاده کنید.
         */
        private readonly IMongoDatabase _MongoDatabase;
        public
            MongoDataBaseAction(IMongoDatabase mongoDatabase)
        {
            _MongoDatabase = mongoDatabase;
        }
        /*
         1. public void CreateCollection(string collectionName):
   تابع CreateCollection به عنوان متد عمومی و بدون بازگشت (void) تعریف شده است. این متد یک ورودی از نوع رشته (string) به نام collectionName دریافت می‌کند که نامی برای مجموعه داده جدید است.

2. _MongoDatabase.CreateCollection(collectionName):
   در داخل بدنه متد CreateCollection، با استفاده از امکانات مربوط به _MongoDatabase (نمونه‌ای از پایگاه داده MongoDB)، یک مجموعه داده جدید با نام مشخص شده توسط collectionName ایجاد می‌شود. این کار با فراخوانی متد CreateCollection() روی _MongoDatabase انجام می‌شود.

با استفاده از این کد، می‌توانید تابع CreateCollection را فراخوانی کنید تا یک مجموعه داده جدید با نام مورد نظر ایجاد شود. این مجموعه داده می‌تواند جهت ذخیره و مدیریت داده‌های مربوط به نیازهای شما در پایگاه داده MongoDB مورد استفاده قرار گیرد.
         */
        public void CreateCollection(string collectionName)
        {
            _MongoDatabase.CreateCollection(collectionName);
        }
        /*
         1. public string CollectionList():
   تابع CollectionList به عنوان یک متد عمومی تعریف شده است و یک رشته (string) به عنوان خروجی برمی‌گرداند. این متد برای دریافت لیستی از نام‌های مجموعه‌های داده موجود در پایگاه داده MongoDB استفاده می‌شود.

2. var collections = _MongoDatabase.ListCollectionNames().ToList();:
   در این بخش، با استفاده از _MongoDatabase (نمونه‌ای از پایگاه داده MongoDB)، متد ListCollectionNames فراخوانی می‌شود تا لیستی از نام‌های مجموعه‌های داده موجود در پایگاه داده را برگرداند. سپس نتیجه این لیست به یک لیست در داخل متغیر collections اختصاص داده می‌شود.

3. return string.Join(",", collections);:
   در بدنه متد CollectionList، با استفاده از متد string.Join()، نام‌های مجموعه‌ها از لیست collections با کاراکتر , جدا شده و به عنوان یک رشته واحد برگردانده می‌شود.

با استفاده از این کد، می‌توانید تابع CollectionList را فراخوانی کنید تا لیستی از نام‌های مجموعه‌های داده موجود در پایگاه داده MongoDB را دریافت کنید. این لیست، به صورت یک رشته از نام‌ها جدا شده با , به شما برگردانده می‌شود.
         */
        public string CollectionList()
        {
            var collections = _MongoDatabase.ListCollectionNames().ToList();
            return string.Join(",", collections);
        }
        /*
         1. public IMongoCollection<BsonDocument> GetCollection(string collectionName):
   این متد به عنوان یک متد عمومی تعریف شده است و یک ورودی از نوع رشته (string) به نام collectionName دریافت می‌کند. ورودی collectionName نام مجموعه داده است که می‌خواهید نمونه آن را دریافت کنید. این متد نمونه‌ای از مجموعه داده MongoDB را بر اساس نام مشخص شده بر می‌گرداند.

2. return _MongoDatabase.GetCollection<BsonDocument>(collectionName);:
   در بدنه متد GetCollection، با استفاده از _MongoDatabase (نمونه‌ای از پایگاه داده MongoDB) و متد GetCollection<TDocument>(...)، نمونه‌ای از مجموعه داده را بر اساس نام (collectionName) ورودی دریافتی ایجاد می‌کند. در اینجا، BsonDocument به عنوان نوع سند مجموعه مورد استفاده قرار می‌گیرد.

با استفاده از این کد، شما می‌توانید تابع GetCollection را با ارسال نام مجموعه مورد نظر به عنوان ورودی فراخوانی کنید. این متد نمونه‌ای از مجموعه داده MongoDB را بر اساس نام مورد نظر به شما برگردانده و شما می‌توانید از آن برای انجام عملیات‌های مختلف مانند خواندن، نوشتن و حذف اسناد استفاده کنید.
         */
        public IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            return _MongoDatabase.GetCollection<BsonDocument>(collectionName);
        }

        public IMongoCollection<Person> GetPersonCollection(string collectionName)
        {
            return _MongoDatabase.GetCollection<Person>(collectionName);
        }
    }
}
