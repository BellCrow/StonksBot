namespace Stonksbot.GameModel.CompanyClasses;

internal class CompanyPriceChanger
{

    private readonly IReadOnlyList<Company> _companies;

    private Random _rand = new Random();

    public CompanyPriceChanger(IReadOnlyList<Company> companies)
    {
        _companies = companies;
    }

    public void Step()
    {
        foreach(var company in _companies)
        {
            company.UpdatePrice((int)(company.Price * GetPriceMultiplicator()));
        }
    }

    private float GetPriceMultiplicator()
    {
        float multiplier = (float)Math.Min(1d, _rand.NextDouble() + 0.1);
        return multiplier;
    }
    
}