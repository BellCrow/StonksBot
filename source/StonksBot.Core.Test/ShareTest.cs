namespace StonksBot.Core.Test;

public class ShareTest
{
    private Company _testCompany;

    [SetUp]
    public void SetUp()
    {
        _testCompany = new Company("TestCompany", 1337);
    }

    [Test]
    public void Split_WithEnoughShares_CreatesSplitStackAndReducesOriginal()
    {
        //Arrange
        var sut = new Share(_testCompany, 20);
        //Act
        var result = sut.Split(10);
        //Assert
        Assert.That(result.ShareCount, Is.EqualTo(10));
    }

    [Test]
    public void Split_WithShareAmount_ThrowsArgumentException()
    {
        //Arrange
        var initialShareCount = 20;
        var sut = new Share(_testCompany, initialShareCount);
        //Act/Assert
        Assert.That(() => sut.Split(initialShareCount), Throws.ArgumentException);
    }

    [Test]
    public void Split_WithMoreThanShareAmount_ThrowsArgumentException()
    {
        //Arrange
        var initialShareCount = 20;
        var sut = new Share(_testCompany, initialShareCount);
        //Act/Assert
        Assert.That(() => sut.Split(initialShareCount + 1), Throws.ArgumentException);
    }

    [Test]
    public void Merge_WithTwoSharesOfSameCompany_SuceessAndMergeeHasIncreasedCount()
    {
        //Arrange
        var initialShareCount = 20;
        var sut = new Share(_testCompany, initialShareCount);
        var mergee = new Share(_testCompany, initialShareCount);
        //Act
        sut.Merge(mergee);
        //Assert
        Assert.That(sut.ShareCount, Is.EqualTo(initialShareCount * 2));
    }
}