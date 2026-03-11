using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StrojeviController : ControllerBase
{
    private readonly AppDbContext _db;
    public StrojeviController(AppDbContext db) => _db = db;

    [HttpGet]
    public IActionResult GetStrojevi()
    {
        return Ok(_db.Strojevi
                    .OrderBy(s => s.Ime)
                    .ToList());
    }

    [HttpPost]
    public IActionResult DodajStroj(Stroj noviStroj)
    {
        _db.Strojevi.Add(noviStroj);
        _db.SaveChanges();
        return CreatedAtAction(nameof(GetStrojevi), new { id = noviStroj.Id }, noviStroj);
    }

    [HttpGet("{id}")]
    public IActionResult GetStroj(int id)
    {
        var stroj = _db.Strojevi.Find(id);

        if (stroj == null)
            return NotFound();

        return Ok(stroj);
    }

}