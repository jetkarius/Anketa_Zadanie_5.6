using System;

namespace Anketa_5._6
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = GetData();
            DisplayData(data);
        }

        static (string Name, string LastName, int Age, string[] Pets, string[] Colors) GetData()
        {
            (string Name, string LastName, int Age, string[] Pets, string[] Colors) anketa;

            string Name;
            do
            {
                Console.WriteLine("Введите ваше имя:");
                Name = Console.ReadLine();
            }
            while (ValidateName(Name));
            anketa.Name = Name;

            string LastName;
            do
            {
                Console.WriteLine("Введите вашу фамилию:");
                LastName = Console.ReadLine();
            }
            while (ValidateName(LastName));
            anketa.LastName = LastName;

            string age;
            int intage;
            do
            {
                Console.WriteLine("Введите возраст цифрами:");
                age = Console.ReadLine();
            }
            while (CheckNum(age, out intage));
            anketa.Age = intage;

            Console.WriteLine("У вас есть домашние животные? Да или нет?");
            var haspet = Console.ReadLine();
            var Pets = new string[0];
            if (haspet == "Да" || haspet == "да")
            {
                string petsNum;
                do
                {
                    Console.WriteLine("Сколько у вас домашних животных?");
                    petsNum = Console.ReadLine();
                }
                while (Validate(petsNum));
                Pets = CreateArrayPets(int.Parse(petsNum));
            }

            string colorsNum;
            string[] Colors;
            do
            {
                Console.WriteLine("Сколько у вас любимых цветов?");
                colorsNum = Console.ReadLine();
            }
            while (Validate(colorsNum));
            Colors = CreateArrayColors(int.Parse(colorsNum));

            var result = (anketa.Name, anketa.LastName, anketa.Age, Pets, Colors);
            return result;
        }
        static bool ValidateName(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (int.TryParse(name[i].ToString(), out int result))
                {
                    return true;
                }
            }

            return false;
        }

        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                corrnumber = intnum;
                return false;
            }
            else
            {
                corrnumber = 0;
                return true;
            }
        }
        static bool Validate(string n)
        {
            int result;
            if (int.TryParse(n, out result) && result > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static string[] CreateArrayPets(int petsNum)
        {
            var namepets = new string[petsNum];
            for (int i = 0; i < petsNum; i++)
            {
                Console.WriteLine("Введите имя питомца {0}:", i + 1);
                namepets[i] = Console.ReadLine();
            }

            return namepets;
        }
        static string[] CreateArrayColors(int count)
        {
            var colors = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите цвет {0}:", i + 1);
                colors[i] = Console.ReadLine();
            }

            return colors;
        }


        static void DisplayData((string Name, string LastName, int Age, string[] Pets, string[] Colors) anketa)
        {
            Console.WriteLine("\tВаши данные:");
            Console.WriteLine("Имя:");
            Console.WriteLine(anketa.Name);
            Console.WriteLine("Фамилия:", anketa.LastName);
            Console.WriteLine(anketa.LastName);
            Console.WriteLine("Возраст:", anketa.Age);
            Console.WriteLine(anketa.Age);

            if (anketa.Pets != null && anketa.Pets.Length > 0)
            {
                Console.WriteLine("Домашные животные:");
                for (int i = 0; i < anketa.Pets.Length; i++)
                {
                    Console.WriteLine(anketa.Pets[i]);
                }
            }

            if (anketa.Colors != null && anketa.Colors.Length > 0)
            {
                Console.WriteLine("Цвета:");
                for (int i = 0; i < anketa.Colors.Length; i++)
                {
                    Console.WriteLine(anketa.Colors[i]);
                }
            }
        }
    }
}