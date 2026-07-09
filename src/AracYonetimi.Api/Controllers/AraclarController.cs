using Microsoft.AspNetCore.Mvc;
using AracYonetimi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using AracYonetimi.Infrastructure.Data;

namespace AracYonetimi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AraclarController : ControllerBase
{
    private readonly AppDbContext _context;

    public AraclarController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Ekle(Arac arac)
    {
        _context.Araclar.Add(arac);
        await _context.SaveChangesAsync();
        
        return Ok(arac);
    }

    [HttpGet]
    public async Task<IActionResult> Listele()
    {
        var araclar = await _context.Araclar.ToListAsync();
        return Ok(araclar);
    }
}