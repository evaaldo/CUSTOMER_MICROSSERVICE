using Domain.Domain;
using Domain.ValueObjects;

namespace Domain.Tests.ValueObjects;

public class NifTests
{
    [Fact]
    public void ShouldThrowExceptionWhenNifIsNull()
    {        
        Assert.Throws<ArgumentException>(() => new Nif(null));
    }

    [Fact]
    public void ShouldThrowExceptionWhenNifIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => new Nif(String.Empty));
    }
    
    [Theory]
    [MemberData(nameof(InvalidNifs))]
    public void ShouldThrowExceptionWhenLengthIsInvalid(string nif)
    {
        Assert.Throws<ArgumentException>(() => new Nif(nif));
    }
    
    [Theory]
    [InlineData("00000000000")]
    [InlineData("12345678901")]
    public void ShouldThrowExceptionWhenCpfIsInvalid(string nif)
    {
        Assert.Throws<ArgumentException>(() => new Nif(nif));
    }
    
    [Theory]
    [InlineData("00000000000000")]
    [InlineData("12345678000100")]
    public void ShouldThrowExceptionWhenCnpjIsInvalid(string nif)
    {
        Assert.Throws<ArgumentException>(() => new Nif(nif));
    }

    #region IEnumerables
    
    public static IEnumerable<object[]> InvalidNifs()
    {
        for (int i = 1; i <= 15; i++)
        {
            if (i == 11 || i == 14)
                continue;

            yield return new object[] { new string('1', i) };
        }
    }
    
    #endregion
}