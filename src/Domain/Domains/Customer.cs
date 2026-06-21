using Domain.ValueObjects;

namespace Domain.Domain;

public class Customer
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DateTime Birthdate { get; private set; }
    public Nif Nif { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public Customer(string name, DateTime birthdate, Nif nif)
    {
        if (DateTime.Now.Year - birthdate.Year < 18)
            throw new ArgumentException("Customer must be at least 18 years old");
        
        if (String.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Customer must have a name");
        
        Id = Guid.NewGuid();
        Name = name;
        Birthdate = birthdate;
        Nif = nif;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}