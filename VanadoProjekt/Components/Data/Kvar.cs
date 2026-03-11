using System.ComponentModel.DataAnnotations.Schema;

public class Kvar
{
    public int Id { get; set; }
    public int StrojId { get; set; }
    public Stroj? Stroj { get; set; }
    public string? Ime { get; set; }
    public string? Opis { get; set; }
    public DateTime VrijemePocetka { get; set; }
    public DateTime? VrijemeZavrsetka { get; set; }
}
