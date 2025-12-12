using BackEnd_S6_L5.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace BackEnd_S6_L5.Services
{
    public class CameraServices : ICameraServices
    {
        private readonly ApplicationDbContext _context;

        public CameraServices(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET 
        public async Task<Camera> GetByIdAsync(Guid id)
        {
            return await _context.Camere
                .Include(c => c.Prenotazioni) // tutte le prenotazioni di questa camera
                .ThenInclude(p => p.Cliente)  // includo il cliente di ogni prenotazione
                .FirstOrDefaultAsync(c => c.IdCamera == id);
        }

        // GET ALL
        public async Task<List<Camera>> GetAllAsync()
        {
            return await _context.Camere
                .Include(c => c.Prenotazioni)
                .ThenInclude(p => p.Cliente)
                .ToListAsync();
        }

        // CREATE
        public async Task<bool> CreateAsync(Camera camera)
        {
            try
            {
                await _context.Camere.AddAsync(camera);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        // UPDATE
        public async Task<bool> UpdateAsync(Camera camera)
        {
            _context.Camere.Update(camera);
            return await _context.SaveChangesAsync() > 0;
        }

        // DELETE
        public async Task<bool> DeleteAsync(Camera camera)
        {
            _context.Camere.Remove(camera);
            return await _context.SaveChangesAsync() > 0;
        }
    }

}

