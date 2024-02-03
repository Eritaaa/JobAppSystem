using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobAppSystem.Data;
using JobAppSystem.Models;

namespace JobAppSystem.Controllers
{
    public class KonkursiController : Controller
    {
        private readonly IKonkursiRepository _konkursiRepository;

        public KonkursiController(IKonkursiRepository konkursiRepository)
        {
            _konkursiRepository = konkursiRepository;
        }

        // GET: Konkursi
        public async Task<IActionResult> Index()
        {
            var konkursit = await _konkursiRepository.GetAllKonkurset();
            return View(konkursit);
        }

        // GET: Konkursi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konkursi = await _konkursiRepository.GetKonkursiById(id.Value);
            if (konkursi == null)
            {
                return NotFound();
            }

            return View(konkursi);
        }

        // GET: Konkursi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Konkursi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulli,Pozicioni,EksperiencaENevojshme,DataEHapjes,DataEMbylljes")] Konkursi konkursi)
        {
            if (ModelState.IsValid)
            {
                await _konkursiRepository.AddKonkursi(konkursi);
                return RedirectToAction(nameof(Index));
            }
            return View(konkursi);
        }

        // GET: Konkursi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konkursi = await _konkursiRepository.GetKonkursiById(id.Value);
            if (konkursi == null)
            {
                return NotFound();
            }
            return View(konkursi);
        }

        // POST: Konkursi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KonkursiId,Titulli,Pozicioni,EksperiencaENevojshme,DataEHapjes,DataEMbylljes")] Konkursi konkursi)
        {
            if (id != konkursi.KonkursiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _konkursiRepository.UpdateKonkursi(konkursi);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_konkursiRepository.KonkursiExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(konkursi);
        }

        // GET: Konkursi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konkursi = await _konkursiRepository.GetKonkursiById(id.Value);
            if (konkursi == null)
            {
                return NotFound();
            }

            return View(konkursi);
        }

        // POST: Konkursi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _konkursiRepository.DeleteKonkursi(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
