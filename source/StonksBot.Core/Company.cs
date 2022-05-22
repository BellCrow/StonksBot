namespace StonksBot.Core;

public class Company
{
    public Company(string companyName, int initialValue)
    {
        Name = companyName;
        Value = initialValue;
    }

    public string Name { get; }
    public int Value { get; set; }
}