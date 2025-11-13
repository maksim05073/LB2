namespace lb2_3;

public abstract class Employer
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public int ExperienceYears { get; set; }
    public bool HasHigherEducation { get; set; }
    public decimal Salary { get; set; }

    public int Age => DateTime.Now.Year - BirthDate.Year;

    public override string ToString()
    {
        return $"{Name} ({this.GetType().Name}) | Вік: {Age} | Стаж: {ExperienceYears} | ЗП: {Salary}";
    }
}