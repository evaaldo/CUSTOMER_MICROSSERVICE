using Domain.Domain;
using Domain.ValueObjects;

namespace Domain.Tests;

public class CustomerTests
{
    private readonly Nif validNif = new Nif("09187881373");
    
    [Fact]
    public void ShouldThrowExceptionWhenAgeIsLessThan18()
    {
        var birthdate = DateTime.Now.AddYears(-17);

        Assert.Throws<ArgumentException>(() => new Customer("Evaldo", birthdate, validNif));
    }

    [Fact]
    public void ShouldThrowExceptionWhenNameIsNull()
    {
        var birthdate = DateTime.Now.AddYears(-18);
        
        Assert.Throws<ArgumentException>(() => new Customer(null, birthdate, validNif));
    }

    [Fact]
    public void ShouldThrowExceptionWhenNameIsEmpty()
    {
        var birthdate = DateTime.Now.AddYears(-18);
        
        Assert.Throws<ArgumentException>(() => new Customer(String.Empty, birthdate, validNif));
    }
    
    [Fact]
    public void ShouldThrowExceptionWhenBirthdateIsAfterCurrentDate()
    {
        var birthdate = DateTime.Now.AddDays(1);
        
        Assert.Throws<ArgumentException>(() => new Customer("Evaldo", birthdate, validNif));
    }
}
