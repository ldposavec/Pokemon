using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private static readonly List<PokeDex> _pokemonList = new List<PokeDex>
        {
            new PokeDex { Id = 1, Name = "Bulbasaur", Type = PokeType.Grass },
            new PokeDex { Id = 2, Name = "Charmander", Type = PokeType.Fire },
            new PokeDex { Id = 3, Name = "Squirtle", Type = PokeType.Water }
            // Add more Pokémon here...
        };

        [HttpGet("{id}")]
        public ActionResult<PokeDex> GetPokemonById(int id)
        {
            var pokemon = _pokemonList.Find(p => p.Id == id);
            if (pokemon == null)
            {
                return NotFound("Pokemon not found");
            }

            return Ok(pokemon);
        }

        [HttpPost]
        public ActionResult<PokeDex> CreatePokemon(PokeDex newPokemon)
        {
            // You can add validation logic here (e.g., check if the ID is unique)
            _pokemonList.Add(newPokemon);
            return CreatedAtAction(nameof(GetPokemonById), new { id = newPokemon.Id }, newPokemon);
        }
    }
}
