using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class MainPerson
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public int Height { get; internal set; }

        public int Weight { get; internal set; }

        public int Age { get; internal set; }
        public int Size { get; internal set; }

        public MainPerson(string firstName, string lastName, int age, int height, int weight, int size)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Height = height;
            Weight = weight;
            Size = size;
        }
    }
}
