namespace lb2_1;

public class Firm
{
    public string Name { get; set; }
    public DateTime FoundationDate { get; set; }
    public string BusinessProfile { get; set; }
    public string DirectorName { get; set; }
    public int EmployeeCount { get; set; }
    public string Address { get; set; }
    
    public override string ToString()
    {
        return $"Назва: {Name}, Профіль: {BusinessProfile}, Директор: {DirectorName}, " +
               $"Співробітників: {EmployeeCount}, Адреса: {Address}, " +
               $"Дата заснування: {FoundationDate.ToShortDateString()}";
    }
}
