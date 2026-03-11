using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

[ApiController]
[Route("api/[controller]")]
public class KvaroviController : ControllerBase
{
    private readonly AppDbContext _db;
    public KvaroviController(AppDbContext db) => _db = db;

    [HttpGet]
    public IActionResult GetKvarovi()
    {
        return Ok(_db.Kvarovi
                    .OrderBy(k => k.VrijemePocetka)
                    .Reverse()
                    .ToList());
    }

    [HttpPost("export")]
    public IActionResult ExportKvarove([FromBody]  List<Kvar> odabraniKvarovi)
    {

        ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
        using (var kvar = new ExcelPackage())
        {
            var worksheet = kvar.Workbook.Worksheets.Add("Kvarovi");
            worksheet.Cells["A1"].Value = "ID";
            worksheet.Cells["B1"].Value = "Stroj ID";
            worksheet.Cells["C1"].Value = "Ime";
            worksheet.Cells["D1"].Value = "Opis";
            worksheet.Cells["E1"].Value = "Vrijeme Pocetka";
            worksheet.Cells["F1"].Value = "Vrijeme Zavrsetka";

            for(int i = 0; i < odabraniKvarovi.Count; i++)
            {
                var k = odabraniKvarovi[i];
                worksheet.Cells[i + 2, 1].Value = k.Id;
                worksheet.Cells[i + 2, 2].Value = k.StrojId;
                worksheet.Cells[i + 2, 3].Value = k.Ime;
                worksheet.Cells[i + 2, 4].Value = k.Opis;
                worksheet.Cells[i + 2, 5].Value = k.VrijemePocetka.ToString();
                worksheet.Cells[i + 2, 6].Value = k.VrijemeZavrsetka.ToString();
            }
            var stream = new MemoryStream(kvar.GetAsByteArray());

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "kvarovi.xlsx");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetKvar(int id)
    {
        var kvar = _db.Kvarovi.Find(id);

        if (kvar == null)
            return NotFound();

        return Ok(kvar);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteKvar(int id)
    {
        var kvar = _db.Kvarovi.Find(id);

        if (kvar == null)
            return NotFound();

        _db.Kvarovi.Remove(kvar);
        _db.SaveChanges();

        return NoContent();
    }

    [HttpGet("stroj/{strojId}")]
    public IActionResult GetKvaroviZaStroj(int strojId)
    {
        var kvarovi = _db.Kvarovi
            .Where(k => k.StrojId == strojId)
            .OrderBy(k => k.VrijemePocetka)
            .Reverse()
            .ToList();

        return Ok(kvarovi);
    }
    [HttpPost("stroj/{strojId}")]
    public IActionResult DodajKvar(int strojId, Kvar kvar)
    {
        kvar.StrojId = strojId;
        _db.Kvarovi.Add(kvar);
        _db.SaveChanges();
        return Ok(kvar);
    }

    [HttpPut("{id}")]
    public IActionResult IzmijeniKvar(int id, Kvar izmijenjeniKvar)
    {
        var kvar = _db.Kvarovi.Find(id);

        if (kvar == null)
            return NotFound();

        kvar.Ime = izmijenjeniKvar.Ime;
        kvar.Opis = izmijenjeniKvar.Opis;
        kvar.VrijemePocetka = izmijenjeniKvar.VrijemePocetka;
        kvar.VrijemeZavrsetka = izmijenjeniKvar.VrijemeZavrsetka;

        _db.SaveChanges();
        return Ok(kvar);
    }



}