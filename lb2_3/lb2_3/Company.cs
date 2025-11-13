namespace lb2_3;

public class Company
{
    public string CompanyName { get; set; }
    public List<Employer> Staff { get; set; } = new List<Employer>();

    public Company(string name)
    {
        CompanyName = name;
    }
}