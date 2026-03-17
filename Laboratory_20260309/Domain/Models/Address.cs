namespace Laboratory_20260309.Domain.Models;

public class Address
{
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public required string Street { get; set; }
    public int BuildingNumber { get; set; } = 1;
    public int? FlatNumber { get; set; }
}
