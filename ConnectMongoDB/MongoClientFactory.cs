using MongoDB.Driver;

namespace ConnectMongoDB
{
    public class MongoClientFactory
    {
        /*
          در این خط، یک رشته به نام connection تعریف شده است که آدرس و پورت مربوط به اتصال به MongoDB را نگهداری می‌کند. در این مثال، اتصال به MongoDB در لوکال هاست (localhost) در پورت 27017 صورت می‌گیرد.
        */
        string connection = "mongodb://localhost:27017";

        /*
          این تابع یک نمونه جدید از کلاس MongoClient ایجاد می‌کند بدون ارائه هیچگونه پارامتری. به عبارت دیگر، این تابع یک MongoClient خالی ایجاد می‌کند که برای برقراری اتصال به MongoDB به پیش فرض استفاده می‌شود.
         */
        public MongoClient GetDefaultConstractor()
        {
            return new MongoClient();
        }
        /*
            این تابع یک نمونه جدید از کلاس MongoClient ایجاد می‌کند با استفاده از رشته connection که آدرس و پورت اتصال به MongoDB را نشان می‌دهد. این تابع برای اتصال به MongoDB با استفاده از یک رشته اتصال بکار می‌رود.
         */
        public MongoClient GetConnectionString()
        {
            return new MongoClient(connection);
        }
        /*
         در این تابع، یک شیء جدید از کلاس MongoClient ایجاد می‌شود. این تابع از دو پارامتر استفاده می‌کند: useUrlCreator که پیش فرضاً برابر true است و برای تعیین اینکه آیا از سازنده URL استفاده شود یا خیر؛ connection که به‌عنوان رشته اتصال استفاده می‌شود. اگر useUrlCreator برابر true باشد، از MongoUrl.Create(connection) برای ایجاد URL استفاده می‌شود و اگر false باشد، از new MongoUrl(connection) استفاده می‌شود. ابتدا MongoUrl ایجاد می‌شود و سپس برای ایجاد نمونه MongoClient از این URL استفاده می‌شود.
         */
        public MongoClient GetUrl(bool useUrlCreator = true)
        {
            return useUrlCreator ? new MongoClient(MongoUrl.Create(connection)) :
                new MongoClient(new MongoUrl(connection));
        }
        /*
            این تابع یک شیء تنظیمات (settings) از کلاس MongoClientSettings ایجاد می‌کند براساس رشته اتصال (connection) با استفاده از MongoUrl.Create(connection)، سپس از این تنظیمات برای ایجاد یک نمونه جدید از MongoClient استفاده می‌کند.

از این توابع می‌توانید برای ایجاد اتصال به MongoDB با استفاده از مختلف روش‌ها و تنظیمات مختلف استفاده کنید.
         */
        public MongoClient GetSettingFromUrl()
        {
            var settings = MongoClientSettings.FromUrl(MongoUrl.Create(connection));
            return new MongoClient(settings);
        }
        /*
            یک متغیر به نام settings از نوع MongoClientSettings ایجاد می‌شود. این متغیر برای ذخیره کردن تنظیمات اتصال به MongoDB به کار می‌رود.
         */
        public MongoClient GetSetting()
        {
            /*
               در این خط، تنظیمات مربوط به سرور MongoDB مشخص می‌شوند. از MongoServerAddress استفاده می‌شود و آدرس سرور (localhost) و پورت (27017) را مشخص می‌کند. در این مثال، اتصال به MongoDB در لوکال هاست (localhost) در پورت 27017 صورت می‌گیرد.
           این بخش برای تنظیم استفاده از SSL در ارتباط با MongoDB است. در این حالت، false تعیین شده است که به معنی عدم استفاده از SSL است.
             */
            var settings = new MongoClientSettings
            {
                Server = new MongoServerAddress("localhost", 27017),
                UseSsl = false
            };
            /*
             با استفاده از تنظیمات settings ساخته شده، یک نمونه جدید از کلاس MongoClient ایجاد می‌شود و به عنوان نتیجه تابع برگردانده می‌شود.

             */
            return new MongoClient(settings);
        }
    }
}
