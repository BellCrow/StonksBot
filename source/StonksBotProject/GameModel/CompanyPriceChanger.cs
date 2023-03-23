namespace StonksBotProject.GameModel
{
    internal class CompanyPriceChanger
    {
        #region Private Fields

        private readonly IReadOnlyList<Company> _companies;

        private Random _rand = new Random();

        #endregion Private Fields

        #region Public Constructors

        public CompanyPriceChanger(IReadOnlyList<Company> companies)
        {
            _companies = companies;
        }

        #endregion Public Constructors

        #region Public Methods

        public void Step()
        {
            foreach(var company in _companies)
            {
                company.UpdatePrice((int)(company.Price * GetPriceMultiplicator()));
            }
        }

        #endregion Public Methods

        #region Private Methods

        private float GetPriceMultiplicator()
        {
            float multiplier = (float)Math.Min(1d, _rand.NextDouble() + 0.1);
            return multiplier;
        }

        #endregion Private Methods
    }
}