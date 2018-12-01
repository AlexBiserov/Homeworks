using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuple
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int[] Marks { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Name: {Name}");
            builder.AppendLine($"Age: {Age}");

            foreach (var m in Marks)
            {
                builder.Append(m + " ");
            }
            builder.AppendLine();

            return builder.ToString();
        }
    }
    class Program
    {
        static dynamic Test()
        {
            return new { a = 0, b = 10 };
        }

        static (int sum, int count) SumArray(int[] arr)
        {
            return (arr.Sum(), arr.Length);
        }

        static void Ex((int[] arr, string name) tuple)
        {
            Console.WriteLine(tuple.name);
            foreach (var item in tuple.arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static (double average, Person person) Ex02(List<Person> people)
        {
            var avg = people.Max(p => p.Marks.Average());
            var pers = people.Where(p => p.Marks.Average() == avg).First();
            return (avg, pers);
        }

        static void Main(string[] args)
        {
            //var tuple = (a: 5, b: 10, "Hello");
            //dynamic t = Test();
            //Console.WriteLine(tuple);


            /*int[] nums = new int[] { 10, -6, 20, 36, 11, 26 };
            var res = SumArray(nums);
            Console.WriteLine($"Count = {res.count}");
            Console.WriteLine($"Sum = {res.sum}");
            Ex((nums, "Array"));*/

            //Коллекция людей
            List<Person> people = new List<Person>
            {
                new Person { Age = 20, Marks = new int[] { 5, 1, 2, 4, 4 }, Name = "Вася" },
                new Person { Age = 25, Marks = new int[] { 5, 5, 4, 3, 5 }, Name = "Петя" },
                new Person { Age = 18, Marks = new int[] { 5, 5, 5, 4, 4 }, Name = "Маша" },
                new Person { Age = 15, Marks = new int[] { 1, 1, 3, 2, 4 }, Name = "Саша" },
            };

            /*var result = Ex02(people);

            Console.WriteLine($"Average: {result.average}");
            Console.WriteLine(result.person);
            Console.WriteLine(result.person.Marks.Average());*/


            //Все ли совершеннолетние?
            var isAll = people.All(p => p.Age >= 18);
            Console.WriteLine($"Все совершеннолетние = {isAll}");

            //Хотя бы один не совершеннолетний
            var isExists = people.Any(p => p.Age < 18);
            Console.WriteLine($"Хотя бы один не совершеннолетний = {isExists}");

            var sum = people.Sum(p => p.Age);
            Console.WriteLine($"Sum age = {sum}");

            var a = people.Where(p => p.Age > 18);

            var n = people.Aggregate((p1, p2) => new Person { Age = p1.Age + p2.Age });
            


            Console.Read();
        }
    }
}
