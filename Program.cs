using System;

namespace Lab2
{
    public class City
    {
        private string _name;
        private string _country;
        private long _population;

        public string Name
        {
            get => _name;
            set => _name = string.IsNullOrWhiteSpace(value) ? "Unknown" : value;
        }

        public string Country
        {
            get => _country;
            set => _country = string.IsNullOrWhiteSpace(value) ? "Unknown" : value;
        }

        public long Population
        {
            get => _population;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine($"[Валідація] Помилка: Населення міста {Name} не може бути від'ємним ({value}). Встановлено 0.");
                    _population = 0;
                }
                else
                {
                    _population = value;
                }
            }
        }

        public City(string name, string country, long population)
        {
            Name = name;
            Country = country;
            Population = population;
            Console.WriteLine($"[Конструктор] Створено об'єкт міста: {Name}");
        }

        public City() : this("Unknown", "Unknown", 0)
        {
        }

        public City(string name, string country) : this(name, country, 0)
        {
        }

        public string GetCityInfo()
        {
            return $"Місто: {Name} | Країна: {Country} | Населення: {Population:N0} осіб";
        }

        ~City()
        {
            Console.WriteLine($"[Деструктор] Об'єкт міста \"{_name}\" знищено з пам'яті.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Створення об'єктів ===");

            City city1 = new City();
            City city2 = new City("Київ", "Україна", 2950000);
            City city3 = new City("Лондон", "Великобританія", -500);

            Console.WriteLine("\n=== Демонстрація роботи методів ===");
            Console.WriteLine(city1.GetCityInfo());
            Console.WriteLine(city2.GetCityInfo());
            Console.WriteLine(city3.GetCityInfo());

            Console.WriteLine("\n=== Підготовка до очищення пам'яті (GC) ===");

            city1 = null;
            city2 = null;
            city3 = null;

            Console.WriteLine("Примусовий виклик Garbage Collector...");

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Програму завершено.");
        }
    }
}