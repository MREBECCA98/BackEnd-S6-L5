using BackEnd_S6_L5.Models.Entities;

namespace BackEnd_S6_L5.Services
{
    public interface ICameraServices
    {
        Task<List<Camera>> GetAllAsync();
        Task<Camera> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(Camera camera);
        Task<bool> UpdateAsync(Camera camera);
        Task<bool> DeleteAsync(Camera camera);

    }
}
