namespace Laboratory_20260323.Domain.Entities;

public class Address
{
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public required string Street { get; set; }
    public required string Building { get; set; }

    public override string ToString()
    {
        return $"{Building} {Street}, {City}, {PostalCode}";
    }
}
