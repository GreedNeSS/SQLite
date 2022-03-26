using GettingScalarValues;
using GettingScalarValues.Models;

Console.WriteLine("***** Getting Scalar Values *****");

SQLliteQuery db = new SQLliteQuery();
db.CreateTableUsers();

List<User> users = new List<User>
{
    new User("GreeGNeSS", 30),
    new User("Marcus", 45),
    new User("Henry", 24)
};

db.InsertDataFromUsers(users);
db.InsertDataFromUsers(users);
db.DeleteUser(3);
long id = db.InsertUser(new User("Fred", 12));

Console.WriteLine($"Новый пользователь поолучил Id: {id}");