using MongoDB.Bson;
using MongoDB.Driver;

namespace mongocli
{
    /*
    > db.authors.findOne()
    {
            "_id" : ObjectId("53b64a0d5e3a0f36209b572c"),
            "name" : "Kha─lid Muh?ammad ?Ali─ al-H?a─jj",
            "personal_name" : "Kha─lid Muh?ammad ?Ali─ al-H?a─jj",
            "last_modified" : {
                    "type" : "/type/datetime",
                    "value" : "2008-08-20T17:57:09.66187"
            },
            "key" : "/authors/OL1000057A",
            "type" : {
                    "key" : "/type/author"
            },
            "revision" : 2
    }
    */

    public class LastModified
    {
        public string type;
        public string value;
    }

    public class Type
    {
        public string key;
    }

    class Author
    {
        public ObjectId _id;
        public string name;
        public string personal_name;
        public LastModified last_modified;
        public string key;
        public Type type;
        public int revision;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "mongodb://10.121.1.184";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("openlib");
            var collection = database.GetCollection<Author>("authors");
            var author = collection.FindOne();
        }
    }
}
