using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryExecution.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public User(string name, int age)
        {
            Name = name;
            Age = age; 
        }
        public User()
        {

        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}";
        }
    }
}
