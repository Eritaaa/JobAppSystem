using System.Collections.Generic;
using System.Threading.Tasks;
using JobAppSystem.Models;

public interface IKonkursiRepository
{
    Task<List<Konkursi>> GetAllKonkurset();
    Task<Konkursi> GetKonkursiById(int id);
    Task AddKonkursi(Konkursi konkursi);
    Task UpdateKonkursi(Konkursi konkursi);
    Task DeleteKonkursi(int id);
    bool KonkursiExists(int id);
}
