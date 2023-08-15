namespace Stonksbot.GameModel.CompanyClasses;

public class Stockmarket
{
    private List<Company> _companies = new()
    {
        //default start atm.
        new Company("Teslor",100,250),
        new Company("Macrohard",200,50),
    };        
    
    public IEnumerable<Company> Companies => _companies;
}