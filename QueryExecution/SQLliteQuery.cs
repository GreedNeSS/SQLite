using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using QueryExecution.Models;

namespace QueryExecution
{
    public class SQLliteQuery
    {
        private SqliteConnection _connection;
        private readonly string _connnectionString;

        public SQLliteQuery(string connectionString)
        {
            _connnectionString = connectionString;
        }

        public SQLliteQuery(): this("Data Source=usersdata.db")
        {

        }

        private void OpenConnection()
        {
            _connection = new SqliteConnection(_connnectionString);
            _connection.Open();
        }

        private void CloseConnection()
        {
            if (_connection.State != System.Data.ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        public void CreateTableUsers()
        {
            string sql = @"CREATE TABLE Users(
                            Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
                            Name TEXT NOT NULL,
                            Age INTEGER NOT NULL)";
            OpenConnection();
            SqliteCommand command = new SqliteCommand
            {
                Connection = _connection,
                CommandText = sql
            };
            command.ExecuteNonQuery();

            Console.WriteLine("Таблица Users создана!");
            CloseConnection();
        }

        public void InsertDataFromUsers(List<User> users)
        {
            string sql = @"INSERT INTO Users(Name, Age) VALUES(@name, @age)";
            OpenConnection();

            foreach (User user in users)
            {
                SqliteCommand command = new SqliteCommand
                {
                    Connection = _connection,
                    CommandText = sql
                };

                SqliteParameter nameParam = new SqliteParameter("@name", user.Name);
                SqliteParameter ageParam = new SqliteParameter("@age", user.Age);
                command.Parameters.Add(nameParam);
                command.Parameters.Add(ageParam);
                command.ExecuteNonQuery();

                Console.WriteLine($"{user.Name} добавлен в таблицу!");
            }

            CloseConnection();
        }

        public void UpdateUsers(int id, User user)
        {
            string sql = @"UPDATE Users SET Name=@name, Age=@age WHERE Id=@id";
            OpenConnection();

                SqliteCommand command = new SqliteCommand
                {
                    Connection = _connection,
                    CommandText = sql
                };

                SqliteParameter idParam = new SqliteParameter("@id", id);
                SqliteParameter nameParam = new SqliteParameter("@name", user.Name);
                SqliteParameter ageParam = new SqliteParameter("@age", user.Age);
                command.Parameters.Add(idParam );
                command.Parameters.Add(nameParam);
                command.Parameters.Add(ageParam);
                command.ExecuteNonQuery();

                Console.WriteLine($"Изменен пользователь под #{id}!");
            
            CloseConnection();
        }

        public void DeleteUser(int id)
        {
            string sql = @"DELETE FROM Users WHERE Id=@id";
            OpenConnection();

                SqliteCommand command = new SqliteCommand
                {
                    Connection = _connection,
                    CommandText = sql
                };

                SqliteParameter idParam = new SqliteParameter("@id", id);
                command.Parameters.Add(idParam );
                command.ExecuteNonQuery();

                Console.WriteLine($"Удалён пользователь под #{id}!");
            
            CloseConnection();
        }
    }
}
