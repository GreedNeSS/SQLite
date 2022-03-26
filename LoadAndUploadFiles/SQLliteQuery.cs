using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using LoadAndUploadFiles.Models;

namespace LoadAndUploadFiles
{
    public class SQLliteQuery
    {
        private SqliteConnection _connection;
        private readonly string _connnectionString;

        public SQLliteQuery(string connectionString)
        {
            _connnectionString = connectionString;
        }

        public SQLliteQuery(): this("Data Source=filesdata.db")
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

        public void CreateTableFiles()
        {
            string sql = @"CREATE TABLE Files(
                            Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
                            FileName TEXT NOT NULL,
                            Title TEXT NOT NULL,
                            Data BLOB)";
            OpenConnection();
            SqliteCommand command = new SqliteCommand
            {
                Connection = _connection,
                CommandText = sql
            };
            command.ExecuteNonQuery();

            Console.WriteLine("Таблица Files создана!");
            CloseConnection();
        }

        public void InsertDataFromDB(List<Image> files)
        {
            string sql = @"INSERT INTO Files(FileName, Title, Data) VALUES(@filename, @title, @data)";
            OpenConnection();

            foreach (Image file in files)
            {
                SqliteCommand command = new SqliteCommand
                {
                    Connection = _connection,
                    CommandText = sql
                };

                SqliteParameter nameParam = new SqliteParameter("@filename", file.FileName);
                SqliteParameter ageParam = new SqliteParameter("@title", file.Title);
                SqliteParameter dataParam = new SqliteParameter("@data", file.Data);
                command.Parameters.Add(nameParam);
                command.Parameters.Add(ageParam);
                command.Parameters.Add(dataParam);
                command.ExecuteNonQuery();

                Console.WriteLine($"{file.FileName} добавлен в таблицу!");
            }

            CloseConnection();
        }

        public List<Image> GetFilesFromSQLiteDB()
        {
            List<Image> images = new List<Image>();
            string sql = @"Select * From Files";
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
                        images.Add(
                            new Image(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                (byte[])reader.GetValue(3)
                                ));
                    }
                }
            }

            CloseConnection();
            return images;
        }
    }
}