using Domain.Domain;

namespace Domain.Tests;

public class CustomerTests
{
    public static IEnumerable<object[]> InvalidNifs()
    {
        for (int i = 1; i <= 15; i++)
        {
            if (i == 11 || i == 14)
                continue;

            yield return new object[] { new string('1', i) };
        }
    }
    
    [Fact]
    public void ShouldThrowExceptionWhenAgeIsLessThan18()
    {
        var birthdate = DateTime.Now.AddYears(-17);

        Assert.Throws<ArgumentException>(() => new Customer("Evaldo", birthdate, "00000000000"));
    }

    [Fact]
    public void ShouldThrowExceptionWhenNameIsNull()
    {
        var birthdate = DateTime.Now.AddYears(-18);
        
        Assert.Throws<ArgumentException>(() => new Customer(null, birthdate, "00000000000"));
    }

    [Fact]
    public void ShouldThrowExceptionWhenNameIsEmpty()
    {
        var birthdate = DateTime.Now.AddYears(-18);
        
        Assert.Throws<ArgumentException>(() => new Customer(String.Empty, birthdate, "00000000000"));
    }
    
    [Fact]
    public void ShouldThrowExceptionWhenNifIsNull()
    {
        var birthdate = DateTime.Now.AddYears(-18);
        
        Assert.Throws<ArgumentException>(() => new Customer("Evaldo", birthdate, null));
    }

    [Fact]
    public void ShouldThrowExceptionWhenNifIsEmpty()
    {
        var birthdate = DateTime.Now.AddYears(-18);
        
        Assert.Throws<ArgumentException>(() => new Customer("Evaldo", birthdate, String.Empty));
    }
    
    [Theory]
    [InlineData("00000000000")]
    [InlineData("00000000000000")]
    public void ShouldCreateCustomerWhenNifIs14Or11Length(string nif)
    {
        var birthdate = DateTime.Now.AddYears(-18);
        
        var customer = new Customer("Evaldo", birthdate, nif);

        Assert.NotNull(customer);
    }
    
    [Theory]
    [MemberData(nameof(InvalidNifs))]
    public void ShouldThrowExceptionWhenNifIsNot14Or11Length(string nif)
    {
        var birthdate = DateTime.Now.AddYears(-18);

        Assert.Throws<ArgumentException>(() => new Customer("Evaldo", birthdate, nif));
    }
    
    [Fact]
    public void ShouldThrowExceptionWhenBirthdateIsAfterCurrentDate()
    {
        var birthdate = DateTime.Now.AddDays(1);
        
        Assert.Throws<ArgumentException>(() => new Customer("Evaldo", birthdate, "00000000000"));
    }
}
