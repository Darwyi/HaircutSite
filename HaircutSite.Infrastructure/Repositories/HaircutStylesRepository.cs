using HaircutSite.Domain.Interfaces;
using HaircutSite.Domain.Models;
using HaircutSite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using Mono.TextTemplating;
using System.ComponentModel.DataAnnotations;

namespace HaircutSite.Infrastructure.Repositories
{
    public class HaircutStylesRepository : IHaircutStyleRepository
    {
        private readonly ApplicationContext _dbContext;

        public HaircutStylesRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<HaircutStyles>> GetHaircutStyles()
        {
            return await _dbContext.Set<HaircutStyles>().ToListAsync();
        }

        public async Task<HaircutStyles?> GetHaircutStyleById(Guid id)
        {
            return await _dbContext.Set<HaircutStyles>().FindAsync(id);
        }
        public async Task CreateHaircutStyle(HaircutStyles haircutStyles)
        {
            await _dbContext.HairCutStyles.AddAsync(haircutStyles);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateHaircutStyle(Guid id, HaircutStyles haircutStyles)
        {
            var haircutStyle = await GetHaircutStyleById(id);
            haircutStyles.Id = id;

            _dbContext.HairCutStyles.Remove(haircutStyle);
            await _dbContext.SaveChangesAsync();

            await _dbContext.HairCutStyles.AddAsync(haircutStyles);
            await _dbContext.SaveChangesAsync();
        }
    }
}
