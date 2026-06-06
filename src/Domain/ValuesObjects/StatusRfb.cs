using Domain.Enums;

namespace Domain.ValuesObjects;

public static class StatusRfb
{
    public static (string status, string statusDescription, string statusRfb) Map(StatusRfbEnum status)
    {
        return status switch
        {
            StatusRfbEnum.Regular => ("ACTIVE", "CUSTOMER IS REGULAR", "REGULAR"),
            StatusRfbEnum.Suspended => ("PARTIAL-BLOCKED", "CUSTOMER HAS A SUSPENDED NIF", "SUSPENDED"),
            StatusRfbEnum.Cancelled => ("FULL-BLOCKED", "CUSTOMER IS HAS A CANCELLED NIF", "CANCELLED"),
            StatusRfbEnum.PassedAway => ("FULL-BLOCKED", "CUSTOMER PASSED AWAY", "PASSED-AWAY"),
            StatusRfbEnum.Null => ("FULL-BLOCKED", "CUSTOMER NIF IS NULL", "NULL"),
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
        };
    }
}