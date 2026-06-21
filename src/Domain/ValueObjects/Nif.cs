namespace Domain.ValueObjects;

public class Nif
{
    public string Value { get; }

    public Nif(string value)
    {
        if (String.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Customer must have a NIF");
        
        value = new string(value.Where(char.IsDigit).ToArray());
        
        if(value.Length != 14 && value.Length != 11)
            throw new ArgumentException("Invalid number of characters for NIF");
        
        if(value.Length == 14 && !IsValidCnpj(value))
            throw new ArgumentException("Invalid CNPJ");
        
        if(value.Length == 11 && !IsValidCpf(value))
            throw new ArgumentException("Invalid CPF");
        
        Value = value;
    }
    
    #region Private Methods

    private bool IsValidCpf(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        if (cpf.Length != 11)
            return false;

        if (cpf.All(c => c == cpf[0]))
            return false;

        int[] numbers = cpf.Select(c => int.Parse(c.ToString())).ToArray();

        int sum = 0;
        for (int i = 0; i < 9; i++)
            sum += numbers[i] * (10 - i);

        int firstDigit = sum % 11;
        firstDigit = firstDigit < 2 ? 0 : 11 - firstDigit;

        if (numbers[9] != firstDigit)
            return false;

        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += numbers[i] * (11 - i);

        int secondDigit = sum % 11;
        secondDigit = secondDigit < 2 ? 0 : 11 - secondDigit;

        return numbers[10] == secondDigit;
    }
    
    private bool IsValidCnpj(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
            return false;

        cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

        if (cnpj.Length != 14)
            return false;

        if (cnpj.All(c => c == cnpj[0]))
            return false;

        int[] numbers = cnpj.Select(c => int.Parse(c.ToString())).ToArray();

        int[] weightsFirst = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] weightsSecond = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        int sum = 0;
        for (int i = 0; i < 12; i++)
            sum += numbers[i] * weightsFirst[i];

        int firstDigit = sum % 11;
        firstDigit = firstDigit < 2 ? 0 : 11 - firstDigit;

        if (numbers[12] != firstDigit)
            return false;

        sum = 0;
        for (int i = 0; i < 13; i++)
            sum += numbers[i] * weightsSecond[i];

        int secondDigit = sum % 11;
        secondDigit = secondDigit < 2 ? 0 : 11 - secondDigit;

        return numbers[13] == secondDigit;
    }

    #endregion
}