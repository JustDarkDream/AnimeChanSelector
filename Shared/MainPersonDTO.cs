using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class MainPersonDTO
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Height { get; }

        public int Weight { get; }

        public int Age { get; }
        public int Size { get; }


        public MainPersonDTO(string firstName, string lastName, int height,
                             int weight,int age,int size)
        {
            FirstName = firstName;
            LastName = lastName;
            Height = height;
            Weight = weight;
            Age = age;
            Size = size;
        }
    }
}
