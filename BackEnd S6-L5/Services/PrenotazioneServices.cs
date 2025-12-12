using Microsoft.EntityFrameworkCore;
using BackEnd_S6_L5.Models.Entities;

namespace BackEnd_S6_L5.Services
{
    public class PrenotazioneServices : IPrenotazioneServices
    {
        private readonly ApplicationDbContext _context;

        public PrenotazioneServices(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET 
        public async Task<Prenotazione> GetByIdAsync(Guid id)
        {
            return await _context.Prenotazioni
                .Include(p => p.Cliente)
                .Include(p => p.Camera)
                .FirstOrDefaultAsync(p => p.IdPrenotazione == id);
        }

        // GET ALL
        public async Task<List<Prenotazione>> GetAllAsync()
        {
            return await _context.Prenotazioni
                .Include(p => p.Cliente)
                .Include(p => p.Camera)
                .ToListAsync();
        }

        // CREATE
        public async Task<bool> CreateAsync(Prenotazione prenotazione)
        {
            try
            {
                await _context.Prenotazioni.AddAsync(prenotazione);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        // UPDATE
        public async Task<bool> UpdateAsync(Prenotazione prenotazione)
        {
            _context.Prenotazioni.Update(prenotazione);
            return await _context.SaveChangesAsync() > 0;
        }

        // DELETE
        public async Task<bool> DeleteAsync(Prenotazione prenotazione)
        {
            _context.Prenotazioni.Remove(prenotazione);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}