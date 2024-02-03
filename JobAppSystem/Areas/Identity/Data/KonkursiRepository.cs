using Microsoft.EntityFrameworkCore;
using JobAppSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobAppSystem.Data;

public class KonkursiRepository : IKonkursiRepository
{
    private readonly JobAppSystemDbContext _context;

    public KonkursiRepository(JobAppSystemDbContext context)
    {
        _context = context;
    }

    public async Task<List<Konkursi>> GetAllKonkurset()
    {
        return await _context.Konkurset.ToListAsync();
    }

    public async Task<Konkursi> GetKonkursiById(int id)
    {
        return await _context.Konkurset.FirstOrDefaultAsync(m => m.KonkursiId == id);
    }

    public async Task AddKonkursi(Konkursi konkursi)
    {
        _context.Add(konkursi);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateKonkursi(Konkursi konkursi)
    {
        _context.Update(konkursi);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteKonkursi(int id)
    {
        var konkursi = await _context.Konkurset.FindAsync(id);
        if (konkursi != null)
        {
            _context.Konkurset.Remove(konkursi);
            await _context.SaveChangesAsync();
        }
    }

    public bool KonkursiExists(int id)
    {
        return (_context.Konkurset?.Any(e => e.KonkursiId == id)).GetValueOrDefault();
    }
}
