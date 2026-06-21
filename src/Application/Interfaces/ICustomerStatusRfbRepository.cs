using Domain.Domain;

namespace Application.Interfaces;

public interface ICustomerStatusRfbRepository
{
    Task Save(CustomerStatusRfb customerStatusRfb);
}