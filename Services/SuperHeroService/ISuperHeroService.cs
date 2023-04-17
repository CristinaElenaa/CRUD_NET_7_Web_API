using SuperHeroAPI_Net7.Models;

namespace SuperHeroAPI_Net7.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero>? GetHero(int id);
        Task<List<SuperHero>> AddSuperHero(SuperHero hero);
        Task<List<SuperHero>>? UpdateSuperHero(int id, SuperHero hero);
        Task<List<SuperHero>>? DeleteSuperHero(int id);
    }
}
