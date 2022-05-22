namespace StonksBot.Core;

public class Portfolio
{
    private readonly List<Share> _shares;

    public Portfolio(List<Share> intialShares)
    {
        _shares = intialShares;
    }

    public Share DeductShare(Company company, int amount)
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

    public void AddShare(Share share)
    {
        var possiblyExistingShare = TryGetShare(share.Company);
        if (possiblyExistingShare != null)
            possiblyExistingShare.Merge(share);
        else
            _shares.Add(share);
    }

    public bool HasShareOfType(Company company)
    {
        return TryGetShare(company) != null;
    }

    public Share TryGetShare(Company company)
    {
        return _shares.FirstOrDefault(iterShare => iterShare.Company == company);
    }
}