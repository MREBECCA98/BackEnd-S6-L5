using BackEnd_S6_L5.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_S6_L5.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly ApplicationDbContext _context;

        public ClienteServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET 
        public async Task<Cliente> GetByIdAsync(Guid id)
        {
            return await _context.Clienti.
                Include(c => c.Prenotazioni) // prenotazioni collegate
                .ThenInclude(p => p.Camera) // clienti delle prenotazioni
                .FirstOrDefaultAsync(c => c.IdCliente == id);

        }

        //GETALL
        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Clienti.
                 Include(c => c.Prenotazioni)
                .ThenInclude(p => p.Camera)
                .ToListAsync();
        }

        //CREATE 
        public async Task<bool> CreateAsync(Cliente cliente)
        {
            try
            {
                await _context.Clienti.AddAsync(cliente);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        //UPDATE
        public async Task<bool> UpdateAsync(Cliente cliente)
        {
            _context.Clienti.Update(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

        //DELETED
        public async Task<bool> DeleteAsync(Cliente cliente)
        {
            _context.Clienti.Remove(cliente);
            return await _context.SaveChangesAsync() > 0;

        }

    }
}
