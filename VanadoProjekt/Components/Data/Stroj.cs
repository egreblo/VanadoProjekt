using System.ComponentModel.DataAnnotations.Schema;

public class Stroj
{
    public int Id { get; set; }
    public string? Ime { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public KategorijaStroja Kategorija { get; set; }

    public List<Kvar> Kvarovi { get; set; } = new();
}


public enum KategorijaStroja
{
    CNC,
    Brusilica,
    Preša,
    Bušilica,
    Laser,
    Plazma,
    Robot,
    Transport,
    Pakiranje,
    Inspekcija,
    Hladenje,
    Zavarivanje
}


