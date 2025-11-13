using System;
using System.Collections.Generic;
using System.Linq;

namespace lb2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Company myCompany = new Company("Tech Giants Inc.");

            myCompany.Staff.AddRange(new List<Employer>
            {
                new President { Name = "Олексій Петренко", BirthDate = new DateTime(1975, 5, 20), ExperienceYears = 25, HasHigherEducation = true, Salary = 50000 },
                
                new Manager { Name = "Ірина Коваль", BirthDate = new DateTime(1985, 10, 12), ExperienceYears = 15, HasHigherEducation = true, Salary = 30000 },
                new Manager { Name = "Володимир Сидоренко", BirthDate = new DateTime(1990, 3, 15), ExperienceYears = 8, HasHigherEducation = true, Salary = 28000 },
                new Manager { Name = "Ольга Бондар", BirthDate = new DateTime(1980, 10, 5), ExperienceYears = 20, HasHigherEducation = true, Salary = 32000 },

                new Worker { Name = "Іван Мельник", BirthDate = new DateTime(1995, 8, 25), ExperienceYears = 5, HasHigherEducation = false, Salary = 15000 },
                new Worker { Name = "Володимир Ткаченко", BirthDate = new DateTime(2000, 1, 10), ExperienceYears = 2, HasHigherEducation = true, Salary = 14000 }, // Наймолодший Володимир
                new Worker { Name = "Петро Руденко", BirthDate = new DateTime(1965, 11, 30), ExperienceYears = 40, HasHigherEducation = false, Salary = 18000 },
                new Worker { Name = "Марія Лисенко", BirthDate = new DateTime(1970, 2, 14), ExperienceYears = 35, HasHigherEducation = true, Salary = 19000 },
                new Worker { Name = "Дмитро Козак", BirthDate = new DateTime(1998, 10, 20), ExperienceYears = 3, HasHigherEducation = false, Salary = 14500 },
                new Worker { Name = "Андрій Вовк", BirthDate = new DateTime(1982, 6, 1), ExperienceYears = 22, HasHigherEducation = false, Salary = 16000 },
                new Worker { Name = "Сергій Бойко", BirthDate = new DateTime(1978, 9, 9), ExperienceYears = 26, HasHigherEducation = true, Salary = 17000 }
            });

            Console.WriteLine($"--- Компанія: {myCompany.CompanyName} ---\n");
            
            int totalEmployees = myCompany.Staff.Count;
            Console.WriteLine($"1. Загальна кількість співробітників: {totalEmployees}");

            
            decimal totalSalary = myCompany.Staff.Sum(e => e.Salary);
            Console.WriteLine($"2. Загальний фонд зарплати: {totalSalary} грн");

            
            Console.WriteLine("\n3. Аналіз топ-10 за стажем:");
            
            var top10ByExperience = myCompany.Staff
                                             .OrderByDescending(e => e.ExperienceYears)
                                             .Take(10)
                                             .ToList();
            
            var targetEmployee = top10ByExperience
                                 .Where(e => e.HasHigherEducation)
                                 .OrderByDescending(e => e.BirthDate) 
                                 .FirstOrDefault();

            if (targetEmployee != null)
                Console.WriteLine($"   Знайдено: {targetEmployee.Name} ({targetEmployee.Age} років, стаж {targetEmployee.ExperienceYears})");
            else
                Console.WriteLine("   Нікого не знайдено за такими критеріями.");

            
            Console.WriteLine("\n4. Менеджери (наймолодший та найстарший):");
            var managers = myCompany.Staff.OfType<Manager>().ToList();

            if (managers.Any())
            {
                var youngestManager = managers.OrderByDescending(m => m.BirthDate).First();
                var oldestManager = managers.OrderBy(m => m.BirthDate).First();
                Console.WriteLine($"   Наймолодший: {youngestManager.Name} ({youngestManager.Age} років)");
                Console.WriteLine($"   Найстарший: {oldestManager.Name} ({oldestManager.Age} років)");
            }

            
            Console.WriteLine("\n5. Народилися у жовтні (за професіями):");
            var octoberBorn = myCompany.Staff
                                       .Where(e => e.BirthDate.Month == 10)
                                       .GroupBy(e => e.GetType().Name);

            foreach (var group in octoberBorn)
            {
                Console.WriteLine($"   Професія: {group.Key}");
                foreach (var emp in group)
                {
                    Console.WriteLine($"     - {emp.Name} (ДН: {emp.BirthDate.ToShortDateString()})");
                }
            }

            
            Console.WriteLine("\n6. Всі Володимири та премія:");
            var vladimirs = myCompany.Staff.Where(e => e.Name.Contains("Володимир")).ToList();

            foreach (var v in vladimirs)
            {
                Console.WriteLine($"   - {v}");
            }

            if (vladimirs.Any())
            {
                var youngestVlad = vladimirs.OrderByDescending(v => v.BirthDate).First();
                decimal bonus = youngestVlad.Salary / 3;
                youngestVlad.Salary += bonus;

                Console.WriteLine($"\n   ВІТАННЯ! {youngestVlad.Name} отримує премію {bonus:F2} грн.");
                Console.WriteLine($"   Нова зарплата: {youngestVlad.Salary:F2} грн");
            }

            Console.ReadKey();
        }
    }
}