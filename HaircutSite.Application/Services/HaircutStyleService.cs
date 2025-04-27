using HaircutSite.Application.Interfaces;
using HaircutSite.Domain.Interfaces;
using HaircutSite.Domain.Models;
namespace HaircutSite.Application.Services
{
    public class HaircutStyleService : IHaircutStyleService
    {
        private readonly IHaircutStyleRepository _haircutStyleRepository;
        public HaircutStyleService (IHaircutStyleRepository haircutStyleRepository)
        {
            _haircutStyleRepository = haircutStyleRepository;
        }

        public async Task CreateHaircutStyle(HaircutStyles haircutStyles)
        {
            var styles = await _haircutStyleRepository.GetHaircutStyles();

            if (styles.Any(u => u.Name == haircutStyles.Name))
            {
                throw new Exception("Haircut style name already exists");
            }
            if (styles.Any(u => u.Description == haircutStyles.Description))
            {
                throw new Exception("Haircut style description already exists");
            }

            await _haircutStyleRepository.CreateHaircutStyle(haircutStyles);
        }

        public async Task<HaircutStyles> GetHaircutStyleById(Guid id)
        {
            var hSId = await _haircutStyleRepository.GetHaircutStyleById(id);
            if (hSId == null)
            {
                throw new Exception("Style doesn't exists");
            }

            return hSId;
        }

        public async Task<List<HaircutStyles>> GetHaircutStyles()
        {
            return await _haircutStyleRepository.GetHaircutStyles();
        }

        public async Task UpdateHaircutStyle(Guid id, HaircutStyles haircut)
        {
            await _haircutStyleRepository.UpdateHaircutStyle(id, haircut);
        }
    }
}
