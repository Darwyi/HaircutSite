using HaircutSite.Domain.Models;

namespace HaircutSite.Application.Interfaces.Services
{
    public interface IHaircutStyleService
    {
        Task<List<HaircutStyles>> GetHaircutStyles();
        Task<HaircutStyles> GetHaircutStyleById(Guid id);
        Task UpdateHaircutStyle(Guid id, HaircutStyles haircutStyles);
        Task CreateHaircutStyle(HaircutStyles haircutStyles);
    }
}
