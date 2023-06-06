namespace StonksBotProject.GameModel
{
    internal class StockMarket
    {
        private List<Company> _companies = new List<Company>
        {
            //default start atm.
            new Company("Teslor",100,250),
            new Company("Macrohard",200,50),
        };        
        
        public IEnumerable<Company> Companies => _companies;
    }
}