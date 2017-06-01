using System;
using Extension1;
using Extension2;

namespace Extensions
{

    // Peter Walter Morris

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person {
                FirstName = "Perter",
                LastName = "Morris"
            };

            Console.WriteLine(person.GetFullName());
        }
    }
}
