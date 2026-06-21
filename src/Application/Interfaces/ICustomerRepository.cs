using Domain.Domain;

namespace Application.Interfaces;

public interface ICustomerRepository
{
    Task Save(Customer customer);
}