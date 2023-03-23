namespace StonksBotProject.GameModel
{
    internal class StockMarket
    {
        #region Private Fields

        private List<Company> _companies = new List<Company>
        {
            //default start atm.
            new Company("Teslor",100,250),
            new Company("Macrohard",200,50),
        };

        #endregion Private Fields

        #region Public Properties

        public IEnumerable<Company> Companies => _companies;

        #endregion Public Properties
    }
}