using Domain.Enum;

namespace Domain.Domain;

public class CustomerStatusRfb
{
    public Guid Id { get; private set; }
    public string Nif { get; private set; }
    public StatusRfbEnum CustomerStatus { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public CustomerStatusRfb(string nif, StatusRfbEnum customerStatus)
    {
        if (String.IsNullOrWhiteSpace(nif))
            throw new ArgumentException("Customer must have a nif.");

        if(nif.Length != 14 && nif.Length != 11)
            throw new ArgumentException("Invalid number of characters for NIF");

        if (!System.Enum.IsDefined(typeof(StatusRfbEnum), customerStatus))
            throw new ArgumentException("Invalid status.");
        
        Id = Guid.NewGuid();
        Nif = nif; 
        CustomerStatus = customerStatus;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}