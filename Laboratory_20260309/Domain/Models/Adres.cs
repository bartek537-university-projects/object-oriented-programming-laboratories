namespace Laboratory_20260309.Domain.Models;

public class Adres
{
    public required string Miasto { get; set; }
    public required string KodPocztowy { get; set; }
    public required string lica { get; set; }
    public int NumerBudynku { get; set; } = 1;
    public int? NumerMieszkania { get; set; }
}
