using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using DataReaderFromSQLite.Models;

namespace DataReaderFromSQLite
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

        public List<User> GetUsersFromSQLiteDB()
        {
            List<User> users = new List<User>();
            string sql = @"Select * From Users";
            OpenConnection();

                SqliteCommand command = new SqliteCommand
                {
                    Connection = _connection,
                    CommandText = sql
                };

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        users.Add(
                            new User
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Age = reader.GetInt32(2),
                            });
                    }
                }
            }
            
            CloseConnection();
            return users;
        }
    }
}