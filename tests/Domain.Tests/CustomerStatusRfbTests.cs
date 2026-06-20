using Domain.Domain;
using Domain.Enum;

namespace Domain.Tests;

public class CustomerStatusRfbTests
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
    
    [Theory]
    [InlineData(StatusRfbEnum.Regular)]
    [InlineData(StatusRfbEnum.Suspended)]
    [InlineData(StatusRfbEnum.Pending)]
    [InlineData(StatusRfbEnum.PassedAway)]
    [InlineData(StatusRfbEnum.Null)]
    [InlineData(StatusRfbEnum.Cancelled)]
    public void ShouldAcceptValidStatus(StatusRfbEnum status)
    {
        var exception = Record.Exception(() => 
            new CustomerStatusRfb("09187881373", status));
    
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(6)]
    [InlineData(999)]
    public void ShouldThrowExceptionWhenStatusIsInvalid(int status)
    {
        var invalidStatus = (StatusRfbEnum)status;

        Assert.Throws<ArgumentException>(() => 
            new CustomerStatusRfb("09187881373", invalidStatus));
    }
    
    [Fact]
    public void ShouldThrowExceptionWhenNifIsNull()
    {
        Assert.Throws<ArgumentException>(() => new CustomerStatusRfb(null, StatusRfbEnum.Regular));
    }

    [Fact]
    public void ShouldThrowExceptionWhenNifIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => new CustomerStatusRfb("", StatusRfbEnum.Regular));
    }
    
    [Theory]
    [InlineData("00000000000")]
    [InlineData("00000000000000")]
    public void ShouldCreateCustomerWhenNifIs14Or11Length(string nif)
    {
        var customerStatus = new CustomerStatusRfb(nif, StatusRfbEnum.Regular);

        Assert.NotNull(customerStatus);
    }
    
    [Theory]
    [MemberData(nameof(InvalidNifs))]
    public void ShouldThrowExceptionWhenNifIsNot14Or11Length(string nif)
    {
        Assert.Throws<ArgumentException>(() => new CustomerStatusRfb(nif, StatusRfbEnum.Regular));
    }
}