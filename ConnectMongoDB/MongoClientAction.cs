using MongoDB.Driver;

namespace ConnectMongoDB
{
    public class MongoClientAction
    {
        /*
         یک متغیر خصوصی به نام _client از نوع MongoClient تعریف شده است. این متغیر برای نگهداری نمونه MongoClient استفاده می‌شود.

         */
        MongoClient _client;
        /*
            این متد سازنده کلاس MongoClientAction است و یک نمونه از کلاس MongoClient را به عنوان پارامتر دریافت می‌کند. با استفاده از این سازنده، یک نمونه از کلاس MongoClientAction ایجاد می‌شود و نمونه MongoClient دریافت شده در متغیر _client ذخیره می‌شود.
         */
        public MongoClientAction(MongoClient client)
        {
            _client = client;
        }
        /*
            این متد، یک نام پایگاه داده (dbName) را به عنوان ورودی دریافت می‌کند و یک نمونه از کلاس IMongoDatabase را برمی‌گرداند. برای این منظور، از نمونه _client استفاده می‌شود و با فراخوانی متد GetDatabase(dbName) بر روی _client، نمونه مربوط به پایگاه داده با نام مشخص شده ایجاد و به عنوان نتیجه برگردانده می‌شود.

از کلاس MongoClientAction با استفاده از نمونه MongoClient می‌توانید به پایگاه داده‌های MongoDB دسترسی پیدا کنید و عملیات مختلفی مانند خواندن و نوشتن داده‌ها را روی آنها انجام دهید. با فراخوانی متد GetDatabase می‌توانید نمونه‌ای از پایگاه داده انتخاب شده را دریافت کنید و سپس از آن برای انجام عملیات مورد نظر استفاده کنید.
         */
        public IMongoDatabase GetDatabase(string dbName)
        {
            return _client.GetDatabase(dbName);
        }
        /*
         1. public bool dropDataBase(string dbName):
   این متد یک نام پایگاه داده (dbName) را به عنوان ورودی دریافت می‌کند و یک مقدار منطقی (bool) را برمی‌گرداند. نام این متد به صورت camel case است و می‌توانید به آن dropDataBase بگویید.

   
2. _client.DropDatabase(dbName);:
   در این بخش، با استفاده از نمونه _client از کلاس MongoClient، عملیات حذف پایگاه داده با نام مشخص شده (dbName) انجام می‌شود. DropDatabase یک متد در کلاس MongoClient است که برای حذف یک پایگاه داده استفاده می‌شود.


3. return true;:
   پس از حذف موفقیت‌آمیز پایگاه داده، مقدار true برگردانده می‌شود به منظور نشان دادن اینکه عملیات حذف با موفقیت انجام شده است.

با استفاده از این تابع dropDataBase در کلاس MongoClientAction، می‌توانید یک پایگاه داده MongoDB را با نام مشخص شده حذف کنید. توجه داشته باشید که عمل حذف پایگاه داده بسیار مهم است و باید با دقت مورد استفاده قرار گیرد تا از حذف ناخواسته داده‌های مهم جلوگیری شود.
         */
        public bool dropDataBase(string dbName)
        {
            _client.DropDatabase(dbName);
            return true;
        }
        /*
         1. public string DatabaseList():
   این متد بدون ورودی تعریف شده است و یک رشته (string) را برمی‌گرداند. نام این متد به صورت Pascal case است و می‌توانید به آن DatabaseList بگویید.

2. var result = _client.ListDatabaseNames().ToList();:
   در این بخش، با فراخوانی متد ListDatabaseNames بر روی نمونه _client از کلاس MongoClient، لیستی از نام‌های پایگاه داده‌های موجود در MongoDB بازیابی می‌شود. نتیجه این عملیات به صورت یک IEnumerable<string> برگردانده می‌شود و با استفاده از متد ToList() به یک لیست تبدیل می‌شود. نام پایگاه‌های داده در این لیست ذخیره می‌شوند.

3. return string.Join(",", result);:
   با استفاده از متد Join در کلاس string، نام‌های پایگاه داده‌ها که در لیست result قرار دارند، با کاراکتر , جدا شده و به عنوان یک رشته برگردانده می‌شوند. بنابراین، نتیجه این متد یک رشته است که نام‌های پایگاه داده‌ها جدا شده با , را نشان می‌دهد.

با استفاده از این تابع DatabaseList در کلاس MongoClientAction، می‌توانید لیست نام‌های پایگاه داده‌های موجود در MongoDB را دریافت کنید و در جایی دلخواه استفاده کنید.
         */
        public string DatabaseList()
        {
            var result = _client.ListDatabaseNames().ToList();
            return string.Join(",", result);
        }
    }
}
