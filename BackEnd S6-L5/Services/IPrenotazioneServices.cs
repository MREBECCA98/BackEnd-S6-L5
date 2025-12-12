using BackEnd_S6_L5.Models.Entities;

namespace BackEnd_S6_L5.Services
{
    public interface IPrenotazioneServices
    {
        Task<List<Prenotazione>> GetAllAsync();
        Task<Prenotazione> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(Prenotazione prenotazione);
        Task<bool> UpdateAsync(Prenotazione prenotazione);
        Task<bool> DeleteAsync(Prenotazione prenotazione);
    }
}
