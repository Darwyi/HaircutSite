using HaircutSite.Domain.Models;

namespace HaircutSite.Domain.Interfaces
{
    public interface IHaircutStyleRepository
    {
        Task<List<HaircutStyles>> GetHaircutStyles();
        Task<HaircutStyles> GetHaircutStyleById(Guid id);
        Task UpdateHaircutStyle(Guid id, HaircutStyles haircutStyles);
        Task CreateHaircutStyle(HaircutStyles haircutStyles);
    }
}
