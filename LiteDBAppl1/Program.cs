using LiteDB;

namespace LiteDBAppl1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new LiteDatabase(@"CustomerData.db"))
            {
                var collection = db.GetCollection<Author>("authors");
                var author = new Author
                {
                    FirstName = "Joydip",
                    LastName = "Kanjilal",
                    Address = "Hyderabad"
                };
                collection.Insert(author);
            }
        }
    }
}
