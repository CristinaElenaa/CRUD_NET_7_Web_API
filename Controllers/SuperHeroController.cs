using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI_Net7.Models;
using SuperHeroAPI_Net7.Services.SuperHeroService;

namespace SuperHeroAPI_Net7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }


        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var result = await _superHeroService.GetAllHeroes();

            return Ok(result);
        }


        [HttpGet ("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var result =   await _superHeroService.GetHero(id);
            if(result == null)
            {
                return NotFound("SuperHero not found!");
            }
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddSuperHero(SuperHero hero)
        {
            var result = await _superHeroService.AddSuperHero(hero);

            return Ok(result);

        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(int id, SuperHero hero)
        {
            var result = await _superHeroService.UpdateSuperHero(id, hero);

            if(result == null)
            {
                return NotFound("SuperHero not found!");
            }

            return Ok(result);
        }

        [HttpDelete]

        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            var result = await _superHeroService.DeleteSuperHero(id);

            if(result == null)
            {
                return NotFound("SuperHero not found!");
            }

            return Ok(result);
        }
    }
}
