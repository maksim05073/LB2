using System;
using System.Collections.Generic;
using System.Linq;

namespace lb2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var firms = new List<Firm>
            {
                new Firm { Name = "Food World", FoundationDate = new DateTime(2020, 1, 10), BusinessProfile = "Food", DirectorName = "John Smith", EmployeeCount = 50, Address = "London, UK" },
                new Firm { Name = "TechSolutions", FoundationDate = new DateTime(2015, 5, 20), BusinessProfile = "IT", DirectorName = "Bill White", EmployeeCount = 150, Address = "New York, USA" },
                new Firm { Name = "MarketMasters", FoundationDate = new DateTime(2023, 8, 15), BusinessProfile = "Marketing", DirectorName = "Anna Black", EmployeeCount = 20, Address = "Kyiv, Ukraine" },
                new Firm { Name = "Super IT", FoundationDate = new DateTime(2010, 3, 5), BusinessProfile = "IT", DirectorName = "George White", EmployeeCount = 350, Address = "London, Baker St" },
                new Firm { Name = "White House Food", FoundationDate = new DateTime(2024, 1, 1), BusinessProfile = "Food", DirectorName = "Walter Black", EmployeeCount = 120, Address = "Paris, France" },
                new Firm { Name = "Global Marketing", FoundationDate = new DateTime(2018, 11, 30), BusinessProfile = "Marketing", DirectorName = "Elena Cruz", EmployeeCount = 250, Address = "Berlin, Germany" }
            };

            Console.WriteLine("--- 1. Усі фірми ---");
            Print(firms);

            Console.WriteLine("\n--- 2. Фірми, які мають назву Food (містять слово Food) ---");
            var foodFirms = firms.Where(f => f.Name.Contains("Food"));
            Print(foodFirms);

            Console.WriteLine("\n--- 3. Фірми, що працюють у галузі маркетингу ---");
            var marketingFirms = firms.Where(f => f.BusinessProfile == "Marketing");
            Print(marketingFirms);

            Console.WriteLine("\n--- 4. Фірми, що працюють у галузі маркетингу або IT ---");
            var marketingOrIt = firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT");
            Print(marketingOrIt);

            Console.WriteLine("\n--- 5. Фірми з кількістю співробітників більше 100 ---");
            var largeFirms = firms.Where(f => f.EmployeeCount > 100);
            Print(largeFirms);

            Console.WriteLine("\n--- 6. Фірми з кількістю співробітників від 100 до 300 ---");
            var mediumFirms = firms.Where(f => f.EmployeeCount >= 100 && f.EmployeeCount <= 300);
            Print(mediumFirms);

            Console.WriteLine("\n--- 7. Фірми, що знаходяться у Лондоні ---");
            var londonFirms = firms.Where(f => f.Address.Contains("London"));
            Print(londonFirms);

            Console.WriteLine("\n--- 8. Фірми, у яких прізвище директора White ---");
            var directorWhite = firms.Where(f => f.DirectorName.Contains("White"));
            Print(directorWhite);

            Console.WriteLine("\n--- 9. Фірми, які засновані понад 2 роки тому ---");
            var twoYearsAgo = DateTime.Now.AddYears(-2);
            var oldFirms = firms.Where(f => f.FoundationDate < twoYearsAgo);
            Print(oldFirms);

            Console.WriteLine("\n--- 10. Фірми, з дня заснування яких минуло більше 150 днів ---");
            var hundredFiftyDaysAgo = DateTime.Now.AddDays(-150);
            var days150Firms = firms.Where(f => f.FoundationDate < hundredFiftyDaysAgo);
            Print(days150Firms);

            Console.WriteLine("\n--- 11. Прізвище директора Black та назва фірми містить слово White ---");
            var blackAndWhite = firms.Where(f => f.DirectorName.Contains("Black") && f.Name.Contains("White"));
            Print(blackAndWhite);
            Console.ReadKey();
        }
        static void Print(IEnumerable<Firm> firms)
        {
            if (!firms.Any())
            {
                Console.WriteLine("(Нічого не знайдено)");
                return;
            }
            
            foreach (var f in firms)
            {
                Console.WriteLine(f);
            }
        }
    }
}