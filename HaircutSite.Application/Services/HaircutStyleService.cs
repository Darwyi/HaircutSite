using HaircutSite.Application.Interfaces.Services;
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
        public async Task<List<HaircutStyles>> GetHaircutStyles()
        {
            var styles = await _haircutStyleRepository.GetHaircutStyles();
            if (styles == null)
                throw new Exception("No haircut styles found");

            return styles;
        }

        public async Task<HaircutStyles> GetHaircutStyleById(Guid id)
        {
            var styleId = await _haircutStyleRepository.GetHaircutStyleById(id);

            if (id == Guid.Empty)
                throw new Exception("Id can't be empty");

            if (styleId == null)
                throw new Exception("Style doesn't exists");

            return styleId;
        }
        public async Task CreateHaircutStyle(HaircutStyles haircutStyles)
        {
            var styles = await _haircutStyleRepository.GetHaircutStyles();

            if (styles.Any(u => u.Name == haircutStyles.Name))
                throw new Exception("Haircut style name already exists");

            await _haircutStyleRepository.CreateHaircutStyle(haircutStyles);
        }

        public async Task UpdateHaircutStyle(Guid id, HaircutStyles haircut)
        {
            await _haircutStyleRepository.UpdateHaircutStyle(id, haircut);
        }
    }
}
