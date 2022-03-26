using DataReaderFromSQLite;
using DataReaderFromSQLite.Models;

Console.WriteLine("***** DataReader From SQLite *****");

SQLliteQuery db = new SQLliteQuery();
List<User> users = db.GetUsersFromSQLiteDB();
users.ForEach(u => Console.WriteLine(u));