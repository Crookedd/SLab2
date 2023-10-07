using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;

namespace SLab2
{
    public class Lab1 
    { 
        public void Task()
        {
             Console.WriteLine("Введите значение плотности кг/м^3: ");
             double density = Convert.ToDouble(Console.ReadLine());
             Console.WriteLine("Введите значение диаметр мм: ");
             double diameter = Convert.ToDouble(Console.ReadLine());
             Console.WriteLine("Введите значение массы кг: ");
             double mass = Convert.ToDouble(Console.ReadLine());
             double diameterN = diameter / 1000;

             double area = Math.PI * Math.Pow(diameterN/ 2, 2);  
             double thickness = mass / (area * density);
             Console.WriteLine($"толщина диска: {thickness} м");
        }
    }

    public class Person
    {
        public string Name;
        public string Lastname;
        public string Gender;
        public int Height;
    }
    class Program
    {
        static List<Person> GeneratePeoplesFileJson()
        {
            return new List<Person>() {
            new Person() { Name = "Vladimir", Lastname = "Sokolov", Gender = "B", Height = 185 },
            new Person() { Name = "Lera", Lastname = "Ignateva", Gender = "G", Height = 155 },
            new Person() { Name = "Alex", Lastname = "Stukolov", Gender = "B", Height = 176 },
            new Person() { Name = "Anton", Lastname = "Dmienko", Gender = "B", Height = 166 },
            new Person() { Name = "Vika", Lastname = "Grishko", Gender = "G", Height = 170 }
        };
        }

        static void WriteTestFilesJson()
        {
            string fileReaded2 = JsonConvert.SerializeObject(GeneratePeoplesFileJson(), Newtonsoft.Json.Formatting.None);
            File.WriteAllText("file.json", fileReaded2);
            
        }

        static void DefinedObjectJson()
        {
            Console.Clear();
            string reader = "file.json";
            var json = File.ReadAllText(reader);
            List<Person> persons = JsonConvert.DeserializeObject<List<Person>>(json);
            Console.WriteLine("Список людей:");
            foreach (var person in persons)
            {
                Console.WriteLine("Имя: " + person.Name + ", Фамилия: " + person.Lastname + ", Пол: " + person.Gender + ", Рост: " + person.Height);
            }

            int maleCount = 0;
            int femaleCount = 0;
            int maleTotalHeight = 0;
            int femaleTotalHeight = 0;
            int maxMaleHeight = 0;
            int maxFemaleHeight = 0;
            string maxMaleName = "";
            string maxFemaleName = "";

            foreach (var person in persons)
            {
                if (person.Gender == "B")
                {
                    maleCount++;
                    maleTotalHeight += person.Height;

                    if (person.Height > maxMaleHeight)
                    {
                        maxMaleHeight = person.Height;
                        maxMaleName = person.Name;
                    }
                }
                else if (person.Gender == "G")
                {
                    femaleCount++;
                    femaleTotalHeight += person.Height;

                    if (person.Height > maxFemaleHeight)
                    {
                        maxFemaleHeight = person.Height;
                        maxFemaleName = person.Name;
                    }
                }
            }

            double maleAverageHeight = maleCount > 0 ? (double)maleTotalHeight / maleCount : 0;
            double femaleAverageHeight = femaleCount > 0 ? (double)femaleTotalHeight / femaleCount : 0;

            Console.WriteLine("Средний рост мужчин: " + maleAverageHeight);
            Console.WriteLine("Средний рост женщин: " + femaleAverageHeight);
            Console.WriteLine("Самый высокий мужчина: " + maxMaleName + ", рост: " + maxMaleHeight);
            Console.WriteLine("Самая высокая женщина: " + maxFemaleName + ", рост: " + maxFemaleHeight);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Выберите какую задачу хотите решить. 1) Задание 1. 2) Задание 2.");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Lab1 lab1 = new Lab1();
                    lab1.Task();
                    break; 
                case "2":
                    WriteTestFilesJson();
                    DefinedObjectJson();
                    break;
                default: Console.WriteLine("Нет такого выбора");
                    break;
            }
            Console.ReadLine();
        }
    }
}
