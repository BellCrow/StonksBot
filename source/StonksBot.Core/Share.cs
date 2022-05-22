namespace StonksBot.Core;

/// <summary>
///     Represents a single part of a company. One Share object
///     can actually represent multiple shares, which can be
///     split up into more smaller stacks of shares.
/// </summary>
public class Share
{
    public Share(Company issuingCompany, int initialShareCount)
    {
        if (initialShareCount <= 0) throw new ArgumentOutOfRangeException(nameof(initialShareCount));
        Company = issuingCompany ?? throw new ArgumentNullException(nameof(issuingCompany));

        ShareCount = initialShareCount;
    }

    public Company Company { get; }

    public int ShareCount { get; private set; }

    public int Value => Company.Value * ShareCount;

    public Share Split(int count)
    {
        if (count >= ShareCount)
            throw new ArgumentException(
                $"Cannot split {count} amount of shares as that is equal to or" +
                $"more than the amount of available {ShareCount} shares.");

        var ret = new Share(Company, count);
        ShareCount -= count;

        return ret;
    }

    public void Merge(Share toMerge)
    {
        if (toMerge.Company != Company)
            throw new ArgumentException(
                "Can not merge shares from different companies. " +
                $"Tried to merge {Company} and {toMerge.Company}");

        ShareCount += toMerge.ShareCount;
    }
}