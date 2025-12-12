using BackEnd_S6_L5.Models.Entities;

namespace BackEnd_S6_L5.Services
{
    public interface IClienteServices
    {
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(Cliente cliente);
        Task<bool> UpdateAsync(Cliente cliente);
        Task<bool> DeleteAsync(Cliente cliente);

    }
}
