using Microsoft.AspNetCore.Mvc;
using my_webapi_demo.Models;

namespace my_webapi_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController: ControllerBase
    {
           private static List<SuperHero> heroes = new List<SuperHero> {
                new SuperHero { 
                    Id = 1, 
                    Name = "Spiderman", 
                    FirstName="Peter", 
                    LastName="Parker", 
                    Place="NYC"
                    }
            };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get() {
         
            return Ok(heroes) ;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id) {
            var hero = heroes.Find(h => h.Id == id);
            if(hero == null) {
                return BadRequest("Hero not found");
            }
            return Ok(hero) ;
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero) {
            heroes.Add(hero);
            return Ok(heroes) ;
        }

        [HttpPut]
         public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero req) {
             var hero = heroes.Find(h => h.Id == req.Id);
              if(hero == null) {
                return BadRequest("Hero not found");
            }
            hero.Name = req.Name;
            hero.FirstName = req.FirstName;
            hero.LastName = req.LastName;
            hero.Place = req.Place;
            return Ok(heroes);
        }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SuperHero>>> RemoveHero(int id) {
            var hero = heroes.Find(h => h.Id == id);
            if(hero == null) {
                return BadRequest("Hero not found");
            }
            heroes.Remove(hero);
            return Ok(heroes) ;
        }


    }
}