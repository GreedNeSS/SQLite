using QueryExecution;
using QueryExecution.Models;

Console.WriteLine("***** Query Execution *****");

SQLliteQuery queryObject = new SQLliteQuery();
//queryObject.CreateTableUsers();

List<User> users = new List<User>
{
    new User("GreeGNeSS", 30),
    new User("Marcus", 45),
    new User("Henry", 24)
};

queryObject.InsertDataFromUsers(users);
queryObject.UpdateUsers(2, new User("Bob", 19));
queryObject.DeleteUser(6);