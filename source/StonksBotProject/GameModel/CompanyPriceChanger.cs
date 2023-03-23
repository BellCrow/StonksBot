namespace StonksBotProject.GameModel
{
    internal class CompanyPriceChanger
    {
        private readonly IReadOnlyList<Company> _companies;

        public CompanyPriceChanger(IReadOnlyList<Company> companies)
        {
            _companies = companies;
        }

        public void Step()
        {
            foreach (var company in _companies)
            {
                company.UpdatePrice((int)(company.Price * GetPriceMultiplicator()));
            }
        }
        Random _rand = new Random();
        private float GetPriceMultiplicator()
        {
            float multiplier = (float)Math.Min(1d, _rand.NextDouble() + 0.1);
            return multiplier;
        }
    }
}
