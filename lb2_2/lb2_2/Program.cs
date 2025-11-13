using System;
using System.Collections.Generic;
using System.Linq;

namespace lb2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var phones = new List<Phone>
            {
                new Phone { Name = "iPhone 11", Manufacturer = "Apple", Price = 450, ReleaseDate = new DateTime(2019, 9, 20) },
                new Phone { Name = "iPhone 13", Manufacturer = "Apple", Price = 750, ReleaseDate = new DateTime(2021, 9, 24) },
                new Phone { Name = "iPhone 13", Manufacturer = "Apple", Price = 750, ReleaseDate = new DateTime(2021, 9, 24) },
                new Phone { Name = "iPhone 15 Pro", Manufacturer = "Apple", Price = 1200, ReleaseDate = new DateTime(2023, 9, 22) },
                new Phone { Name = "Galaxy S22", Manufacturer = "Samsung", Price = 600, ReleaseDate = new DateTime(2022, 2, 25) },
                new Phone { Name = "Galaxy S21", Manufacturer = "Samsung", Price = 400, ReleaseDate = new DateTime(2021, 1, 29) },
                new Phone { Name = "Galaxy A54", Manufacturer = "Samsung", Price = 350, ReleaseDate = new DateTime(2023, 3, 15) },
                new Phone { Name = "Redmi Note 10", Manufacturer = "Xiaomi", Price = 180, ReleaseDate = new DateTime(2021, 3, 4) },
                new Phone { Name = "12T Pro", Manufacturer = "Xiaomi", Price = 550, ReleaseDate = new DateTime(2022, 10, 6) },
                new Phone { Name = "Xperia 1", Manufacturer = "Sony", Price = 900, ReleaseDate = new DateTime(2019, 6, 1) },
                new Phone { Name = "Nokia 3310", Manufacturer = "Nokia", Price = 50, ReleaseDate = new DateTime(2000, 9, 1) }
            };

            Console.WriteLine("--- Вхідні дані (всі телефони) ---");
            Print(phones);

            Console.WriteLine($"\n1. Кількість телефонів: {phones.Count}");

            Console.WriteLine($"2. Кількість телефонів із ціною > 100: {phones.Count(p => p.Price > 100)}");

            Console.WriteLine($"3. Кількість телефонів із ціною 400-700: {phones.Count(p => p.Price >= 400 && p.Price <= 700)}");

            string targetManufacturer = "Apple";
            Console.WriteLine($"4. Кількість телефонів виробника {targetManufacturer}: {phones.Count(p => p.Manufacturer == targetManufacturer)}");
            var minPricePhone = phones.OrderBy(p => p.Price).FirstOrDefault();
            Console.WriteLine($"\n5. Телефон із мінімальною ціною: {minPricePhone}");

            var maxPricePhone = phones.OrderByDescending(p => p.Price).FirstOrDefault();
            Console.WriteLine($"6. Телефон із максимальною ціною: {maxPricePhone}");

            var oldestPhone = phones.OrderBy(p => p.ReleaseDate).FirstOrDefault();
            Console.WriteLine($"\n7. Найстаріший телефон: {oldestPhone}");

            var newestPhone = phones.OrderByDescending(p => p.ReleaseDate).FirstOrDefault();
            Console.WriteLine($"8. Найсвіжіший телефон: {newestPhone}");

            Console.WriteLine($"\n9. Середня ціна телефону: {phones.Average(p => p.Price):F2}$");

            Console.WriteLine("\n10. П'ять найдорожчих телефонів:");
            var top5Expensive = phones.OrderByDescending(p => p.Price).Take(5);
            Print(top5Expensive);

            Console.WriteLine("\n11. П'ять найдешевших телефонів:");
            var top5Cheap = phones.OrderBy(p => p.Price).Take(5);
            Print(top5Cheap);

            Console.WriteLine("\n12. Три найстаріші телефони:");
            var top3Oldest = phones.OrderBy(p => p.ReleaseDate).Take(3);
            Print(top3Oldest);

            Console.WriteLine("\n13. Три найновіші телефони:");
            var top3Newest = phones.OrderByDescending(p => p.ReleaseDate).Take(3);
            Print(top3Newest);
            

            Console.WriteLine("\n14. Статистика по виробниках:");
            var manufacturerStats = phones.GroupBy(p => p.Manufacturer)
                                          .Select(g => new { Name = g.Key, Count = g.Count() });
            foreach (var item in manufacturerStats)
            {
                Console.WriteLine($"{item.Name} - {item.Count}");
            }

            Console.WriteLine("\n15. Статистика по моделях:");
            var modelStats = phones.GroupBy(p => p.Name)
                                   .Select(g => new { Model = g.Key, Count = g.Count() });
            foreach (var item in modelStats)
            {
                Console.WriteLine($"{item.Model} - {item.Count}");
            }

            Console.WriteLine("\n16. Статистика по роках:");
            var yearStats = phones.GroupBy(p => p.ReleaseDate.Year)
                                  .OrderBy(g => g.Key)
                                  .Select(g => new { Year = g.Key, Count = g.Count() });
            foreach (var item in yearStats)
            {
                Console.WriteLine($"{item.Year} рік - {item.Count}");
            }

            Console.ReadKey();
        }

        static void Print(IEnumerable<Phone> phones)
        {
            foreach (var p in phones)
            {
                Console.WriteLine(p);
            }
        }
    }
}