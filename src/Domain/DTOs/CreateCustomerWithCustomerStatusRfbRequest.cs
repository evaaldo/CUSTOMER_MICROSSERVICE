using Domain.Enum;
using Domain.ValueObjects;

namespace Domain.DTOs;

public record CreateCustomerWithCustomerStatusRfbRequest(
    string Name,
    DateTime Birthdate,
    Nif Nif,
    StatusRfbEnum CustomerStatus);