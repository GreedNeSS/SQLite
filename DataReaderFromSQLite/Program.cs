using DataReaderFromSQLite;
using DataReaderFromSQLite.Models;

Console.WriteLine("***** DataReader From SQLite *****");

SQLliteQuery db = new SQLliteQuery();
db.CreateTableUsers();

List<User> users = new List<User>
{
    new User("GreeGNeSS", 30),
    new User("Marcus", 45),
    new User("Henry", 24)
};

users.ForEach(u => Console.WriteLine(u));

db.InsertDataFromUsers(users);
users = db.GetUsersFromSQLiteDB();

users.ForEach(u => Console.WriteLine(u));