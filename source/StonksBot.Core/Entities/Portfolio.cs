namespace StonksBot.Core.Entities;

public class Portfolio
{
    private readonly List<Shares> _shares;

    public Portfolio(List<Shares> intialShares)
    {
        _shares = intialShares;
    }

    public IReadOnlyList<Shares> Shares => _shares;

    public Shares DeductShare(Company company, int amount)
    {
        var shareToDeductFrom = TryGetShare(company);
        if (shareToDeductFrom == null)
            throw new ArgumentException(
                $"Cannot find specified share of company {company.Name} in the portfolio");

        if (shareToDeductFrom.ShareCount == amount)
        {
            _shares.Remove(shareToDeductFrom);
            return shareToDeductFrom;
        }

        return shareToDeductFrom.Split(amount);
    }

    public void AddShare(Shares shares)
    {
        var possiblyExistingShare = TryGetShare(shares.Company);
        if (possiblyExistingShare != null)
            possiblyExistingShare.Merge(shares);
        else
            _shares.Add(shares);
    }

    public bool HasShareOfType(Company company)
    {
        return TryGetShare(company) != null;
    }

    public Shares TryGetShare(Company company)
    {
        return _shares.FirstOrDefault(iterShare => iterShare.Company == company);
    }
}