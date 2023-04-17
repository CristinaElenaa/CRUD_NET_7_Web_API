using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_Net7.Data;
using SuperHeroAPI_Net7.Models;

namespace SuperHeroAPI_Net7.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
       
        private readonly ApplicationDbContext _context;

        public SuperHeroService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero>? GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            return hero;
        }

        public async Task<List<SuperHero>> AddSuperHero(SuperHero hero)
        {
            var superHero = new SuperHero();

            superHero.Name = hero.Name;
            superHero.FirstName = hero.FirstName;
            superHero.LastName = hero.LastName;
            superHero.Place = hero.Place;

            await _context.SuperHeroes.AddAsync(superHero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>>? UpdateSuperHero(int id, SuperHero hero)
        {
            var superHero = await _context.SuperHeroes.FindAsync(id);

            if (superHero == null)
            {
                return null;
            }

            superHero.Name = hero.Name;
            superHero.FirstName = hero.FirstName;
            superHero.LastName = hero.LastName;
            superHero.Place = hero.Place;

            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>>? DeleteSuperHero(int id)
        {
            var superHero = await _context.SuperHeroes.FindAsync(id);
            if (superHero == null)
            {
                return null;
            }

            _context.SuperHeroes.Remove(superHero);
            _context.SaveChanges();

            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
